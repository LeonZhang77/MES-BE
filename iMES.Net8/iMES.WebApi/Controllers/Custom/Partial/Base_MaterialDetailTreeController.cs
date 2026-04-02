/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Base_MaterialDetailTree",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Custom.IServices;
using iMES.Core.Filters;
using iMES.Core.Enums;
using iMES.Custom.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using iMES.Core.Extensions;
using iMES.Warehouse.IRepositories;
using iMES.Warehouse.Services;
using iMES.Custom.IRepositories;

namespace iMES.Custom.Controllers
{
    public partial class Base_MaterialDetailTreeController
    {
        private readonly IBase_MaterialDetailTreeService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWare_OutWareHouseBillRepository _outWareHouseBillRepository;
        private readonly IBase_NumberRuleRepository _numberRuleRepository;//自定义编码规则访问数据库
        private readonly IWare_OutWareHouseBillListRepository _outWareHouseBillListRepository;

        [ActivatorUtilitiesConstructor]
        public Base_MaterialDetailTreeController(
            IBase_MaterialDetailTreeService service,
            IHttpContextAccessor httpContextAccessor,
            IWare_OutWareHouseBillRepository outWareHouseBillRepository,
            IBase_NumberRuleRepository numberRuleRepository,
            IWare_OutWareHouseBillListRepository outWareHouseBillListRepository
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _numberRuleRepository = numberRuleRepository;
            _outWareHouseBillRepository = outWareHouseBillRepository;
            _outWareHouseBillListRepository = outWareHouseBillListRepository;
        }
        public override ActionResult GetPageData([FromBody] PageDataOptions loadData)
        {
            //没有查询条件显示所有一级节点数据
            if (loadData.Value.GetInt() == 1)
            {
                return GetCatalogRootData(loadData);
            }
            //有查询条件使用框架默认的查询方法
            return base.GetPageData(loadData);
        }

        /// treetable 获取根节点数据
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("getCatalogRootData")]
        [ApiActionPermission(ActionPermissionOptions.Search)]
        public ActionResult GetCatalogRootData([FromBody] PageDataOptions options)
        {
            //页面加载(一级)根节点数据条件x => x.ParentId==null,自己根据需要设置
            var query = Base_MaterialDetailTreeRepository.Instance.FindAsIQueryable(x => x.ParentId == null);

            var rows = query.TakeOrderByPage(options.Page, options.Rows)
                .OrderBy(x => x.ProductName).Select(s => new
                {
                    s.MaterialDetailTree_Id,
                    s.ProductCode,
                    s.ProductName,
                    s.ProductStandard,
                    s.Unit_Id,
                    s.QuantityPer,
                    s.ParentId,
                    s.CreateID,
                    s.Creator,
                    s.CreateDate,
                    s.ModifyID,
                    s.Modifier,
                    s.ModifyDate,
                    hasChildren = true
                }).ToList();
            return JsonNormal(new { total = query.Count(), rows });
        }

        /// <summary>
        ///treetable 获取子节点数据
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("getChildrenData")]
        [ApiActionPermission(ActionPermissionOptions.Search)]
        public async Task<ActionResult> GetChildrenData(Guid materialDetailTreeId)
        {
            //点击节点时，加载子节点数据
            var roleRepository = Base_MaterialDetailTreeRepository.Instance.FindAsIQueryable(x => 1 == 1);

            var rows = await roleRepository.Where(x => x.ParentId == materialDetailTreeId)
                .Select(s => new
                {
                    s.MaterialDetailTree_Id,
                    s.ProductCode,
                    s.ProductName,
                    s.ProductStandard,
                    s.Unit_Id,
                    s.QuantityPer,
                    s.ParentId,
                    s.CreateID,
                    s.Creator,
                    s.CreateDate,
                    s.ModifyID,
                    s.Modifier,
                    s.ModifyDate,
                    hasChildren = roleRepository.Any(x => x.ParentId == s.MaterialDetailTree_Id)
                }).ToListAsync();
            return JsonNormal(new { rows });
        }
        ///// <summary>
        /////bom批量出库
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost, Route("bomOut")]
        //[ApiActionPermission(ActionPermissionOptions.Search)]
        //public async Task<ActionResult> BomOut(Guid materialDetailTreeId,string qty,string remark)
        //{
        //    //点击节点时，加载子节点数据
        //    var roleRepository = Base_MaterialDetailTreeRepository.Instance.FindAsIQueryable(x => 1 == 1);

        //    var rows = await roleRepository.Where(x => x.ParentId == materialDetailTreeId)
        //        .Select(s => new
        //        {
        //            s.MaterialDetailTree_Id,
        //            s.ProductCode,
        //            s.ProductName,
        //            s.ProductStandard,
        //            s.Unit_Id,
        //            s.QuantityPer,
        //            s.ParentId,
        //            s.CreateID,
        //            s.Creator,
        //            s.CreateDate,
        //            s.ModifyID,
        //            s.Modifier,
        //            s.ModifyDate,
        //            hasChildren = roleRepository.Any(x => x.ParentId == s.MaterialDetailTree_Id)
        //        }).ToListAsync();
        //    if (rows.Count == 0)
        //    {
        //        return JsonNormal(new { rows });
        //    };
        //    //生成出库单主表
        //    var outBill = new List<Ware_OutWareHouseBill>();
        //    outBill.Add(new Ware_OutWareHouseBill
        //    {
        //        OutWareHouseBillCode = GetOutWareHouseBillCode(),
        //        OutWareHouseBillType = "commonOut",
        //        OutWareHouseDate = DateTime.Now,
        //        Remark = remark,
        //        AuditStatus = 0,
        //        CreateDate = DateTime.Now,
        //        CreateID = 1,
        //        Creator = "系统生成",
        //    });
        //    //新增
        //    _outWareHouseBillRepository.AddRange(outBill, true);
        //    //生成出库单明细表
        //    var proRepository = Base_ProductRepository.Instance.FindAsIQueryable(x => 1 == 1);
            
        //    var outBillList = new List<Ware_OutWareHouseBillList>();
        //    for (int i = 0; i < rows.Count; i++)
        //    {
        //        var product = await proRepository.Where(x => x.ProductCode == rows[i].ProductCode)
        //           .Select(s => new
        //           {
        //               s.Product_Id,
        //               s.ProductCode,
        //               s.ProductName,
        //               s.ProductStandard,
        //               s.Unit_Id,
        //               s.CreateID,
        //               s.Creator,
        //               s.CreateDate
        //           }).ToListAsync();
        //        outBillList.Add(new Ware_OutWareHouseBillList
        //        {
        //            OutWareHouseBill_Id = outBill[0].OutWareHouseBill_Id,
        //            ProductCode = rows[i].ProductCode,
        //            ProductName = rows[i].ProductName,
        //            Unit_Id = rows[i].Unit_Id.ToInt(),
        //            ProductStandard = rows[i].ProductStandard,
        //            OutStoreQty = rows[i].QuantityPer * Convert.ToInt32(qty),
        //            Product_Id = product[0].Product_Id,
        //            CreateDate = DateTime.Now,
        //            CreateID = 1,
        //            Creator = "系统生成",
        //        });
        //    }
        //    //生成出库单明细表
        //    _outWareHouseBillListRepository.AddRange(outBillList, true);
        //    return JsonNormal(new { rows });
        //}
        ///// <summary>
        ///// 自动生成工序编号
        ///// </summary>
        ///// <returns></returns>
        //public string GetOutWareHouseBillCode()
        //{
        //    DateTime dateNow = (DateTime)DateTime.Now.ToString("yyyy-MM-dd").GetDateTime();
        //    //查询当天最新的订单号
        //    string defectItemCode = _outWareHouseBillRepository.FindAsIQueryable(x => x.CreateDate > dateNow && x.OutWareHouseBillCode.Length > 8)
        //        .OrderByDescending(x => x.OutWareHouseBillCode)
        //        .Select(s => s.OutWareHouseBillCode)
        //        .FirstOrDefault();
        //    Base_NumberRule numberRule = _numberRuleRepository.FindAsIQueryable(x => x.FormCode == "OutStoreForm")
        //        .OrderByDescending(x => x.CreateDate)
        //        .FirstOrDefault();
        //    if (numberRule != null)
        //    {
        //        string rule = numberRule.Prefix + DateTime.Now.ToString(numberRule.SubmitTime.Replace("hh", "HH"));
        //        if (string.IsNullOrEmpty(defectItemCode))
        //        {
        //            rule += "1".PadLeft(numberRule.SerialNumber, '0');
        //        }
        //        else
        //        {
        //            rule += (defectItemCode.Substring(defectItemCode.Length - numberRule.SerialNumber).GetInt() + 1).ToString("0".PadLeft(numberRule.SerialNumber, '0'));
        //        }
        //        return rule;
        //    }
        //    else //如果自定义序号配置项不存在，则使用日期生成
        //    {
        //        return DateTime.Now.ToString("yyyyMMddHHmmssffff");
        //    }
        //}
    }
}
