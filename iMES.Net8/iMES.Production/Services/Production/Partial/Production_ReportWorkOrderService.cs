/*
 *所有关于Production_ReportWorkOrder类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Production_ReportWorkOrderService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;
using System.Linq;
using iMES.Core.Utilities;
using System.Linq.Expressions;
using iMES.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Production.IRepositories;
using System.Collections.Generic;
using iMESSystem = iMES.System.IRepositories;
using iMES.Custom.IRepositories;
using System;
using iMES.Core.ManageUser;
using iMES.Core.DBManager;

namespace iMES.Production.Services
{
    public partial class Production_ReportWorkOrderService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProduction_ReportWorkOrderRepository _repository;//访问数据库
        private readonly iMESSystem.ISys_UserRepository _userRepository;
        private readonly IBase_ProcessRepository _processRepository;
        private readonly IProduction_WorkOrderRepository _workOrderRepository;
        private readonly IProduction_WorkOrderListRepository _workOrderListRepository;
        private readonly IProduction_OverWorkOrderRepository _overWorkOrderRepository;
        private readonly IBase_ProcessLineListRepository _processLineListRepository;

        [ActivatorUtilitiesConstructor]
        public Production_ReportWorkOrderService(
            IProduction_ReportWorkOrderRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            iMESSystem.ISys_UserRepository userRepository,
            IBase_ProcessRepository processRepository,
            IProduction_WorkOrderRepository workOrderRepository,
           IProduction_OverWorkOrderRepository overWorkOrderRepository,
           IProduction_WorkOrderListRepository workOrderListRepository,
           IBase_ProcessLineListRepository processLineListRepository
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _userRepository = userRepository;
            _processRepository = processRepository;
            _workOrderRepository = workOrderRepository;
            _overWorkOrderRepository = overWorkOrderRepository;
            _workOrderListRepository = workOrderListRepository;
            _processLineListRepository = processLineListRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
        WebResponseContent webResponse = new WebResponseContent();
        //查询
        public override PageGridData<Production_ReportWorkOrder> GetPageData(PageDataOptions options)
        {
            //查询完成后，在返回页面前可对查询的数据进行操作
            GetPageDataOnExecuted = (PageGridData<Production_ReportWorkOrder> grid) =>
            {
                //可对查询的结果的数据操作
                List<Production_ReportWorkOrder> list = grid.rows;
                for (int i = 0; i < list.Count; i++)
                {
                    var userTrueName = _userRepository.FindAsIQueryable(x => x.User_Id == list[i].ProductUser.GetInt())
                            .OrderByDescending(x => x.CreateDate)
                            .Select(s => s.UserTrueName)
                            .FirstOrDefault();
                    var processName = _processRepository.FindAsIQueryable(x => x.Process_Id == list[i].Process_Id.GetInt())
                           .OrderByDescending(x => x.CreateDate)
                           .Select(s => s.ProcessName)
                           .FirstOrDefault();
                    var workOrderCode = _workOrderRepository.FindAsIQueryable(x => x.WorkOrder_Id == list[i].WorkOrder_Id.GetInt())
                         .OrderByDescending(x => x.CreateDate)
                         .Select(s => s.WorkOrderCode)
                         .FirstOrDefault();
                    list[i].ProductUserName = userTrueName == null ? "" : userTrueName.ToString();
                    list[i].ProcessName = processName == null ? "" : processName.ToString();
                    list[i].WorkOrderCode = workOrderCode == null ? "" : workOrderCode.ToString();
                }
            };
            return base.GetPageData(options);
        }
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            //此处saveModel是从前台提交的原生数据，可对数据进修改过滤
            AddOnExecuting = (Production_ReportWorkOrder reportWorkOrder, object list) =>
            {
                List<Production_ReportWorkOrderList> reportLists = list as List<Production_ReportWorkOrderList>;
                UserInfo userInfo = UserContext.Current.UserInfo;
                if (reportWorkOrder.NoGoodQty != null  &&  reportWorkOrder.NoGoodQty != 0 && reportLists== null)
                {
                    return webResponse.Error("有不良品请填写不良品项");
                }
                
                List<Production_OverWorkOrder> orderListNext = new List<Production_OverWorkOrder>();
                Production_OverWorkOrder entity = new Production_OverWorkOrder();

                var workOrderCode = _workOrderListRepository.FindAsIQueryable(x => x.WorkOrder_Id == reportWorkOrder.WorkOrder_Id.GetInt())
                                               .OrderByDescending(x => x.CreateDate)
                                               .Select(s => new
                                               {
                                                   s.ProcessLine_Id,
                                                   s.ProcessLine_Approve
                                               })
                                               .FirstOrDefault();
                if (workOrderCode.ProcessLine_Approve == 1)
                {
                    var lineId = _workOrderListRepository.FindAsIQueryable(x => x.WorkOrder_Id == reportWorkOrder.WorkOrder_Id.GetInt())
                                             .OrderByDescending(x => x.CreateDate)
                                             .Select(s => new
                                             {
                                                 s.ProcessLine_Id
                                             })
                                             .FirstOrDefault();
                    string woSql = " select * from Base_ProcessLineList where  ProcessLine_Id=@processLineId order by sequence asc";
                    List<Base_ProcessLineList> listProcess = DBServerProvider.SqlDapper.QueryList<Base_ProcessLineList>(woSql, new { processLineId = lineId.ProcessLine_Id });
                    int index = 0;
                    for (int i = 0; i < listProcess.Count; i++)
                    {
                        if (listProcess[i].Process_Id == reportWorkOrder.Process_Id)
                        {
                            index = i;
                            break;
                        }
                    }
                    if (index == 0)
                    {
                        entity.Process_Id = reportWorkOrder.Process_Id;
                        var process = _processRepository.FindAsIQueryable(x => x.Process_Id == reportWorkOrder.Process_Id.GetInt())
                               .OrderByDescending(x => x.CreateDate)
                               .Select(s => new
                                   {
                                       s.ProcessCode,
                                       s.ProcessName
                                   })
                               .FirstOrDefault();
                        entity.ProcessName = process.ProcessName;
                    
                        entity.ProcessCode = process.ProcessCode;
                        entity.ProcessLine_Id = workOrderCode.ProcessLine_Id;
                        entity.WorkOrder_Id = reportWorkOrder.WorkOrder_Id.GetInt();
                        var wo = _workOrderRepository.FindAsIQueryable(x => x.WorkOrder_Id == reportWorkOrder.WorkOrder_Id.GetInt())
                             .OrderByDescending(x => x.CreateDate)
                             .Select(s => new
                             {
                                 s.WorkOrderCode
                             })
                             .FirstOrDefault();
                        entity.WorkOrderCode = wo.WorkOrderCode;
                        entity.CreateID = userInfo.User_Id;
                        entity.Creator = userInfo.UserTrueName;
                        entity.CreateDate = DateTime.Now;
                        orderListNext.Add(entity);
                    }
                    else
                    { 
                        var over = _overWorkOrderRepository.FindAsIQueryable(x => x.WorkOrder_Id == reportWorkOrder.WorkOrder_Id.GetInt() && x.Process_Id == listProcess[index-1].Process_Id)
                                 .OrderByDescending(x => x.CreateDate)
                                 .Select(s => new
                                 {
                                     s.WorkOrder_Id,
                                     s.WorkOrderCode,
                                     s.Process_Id,
                                     s.ProcessLine_Id,
                                     s.Status
                                 })
                                 .FirstOrDefault();
                        if (over != null && over.Status == 1)
                        {
                            entity.Process_Id = reportWorkOrder.Process_Id;
                            var pc = _processRepository.FindAsIQueryable(x => x.Process_Id == reportWorkOrder.Process_Id.GetInt())
                               .OrderByDescending(x => x.CreateDate)
                               .Select(s => new
                               {
                                   s.ProcessCode,
                                   s.ProcessName
                               })
                               .FirstOrDefault();
                            entity.ProcessName = pc.ProcessName;
                            entity.ProcessCode = pc.ProcessCode;
                            entity.ProcessLine_Id = workOrderCode.ProcessLine_Id;
                            entity.WorkOrder_Id = reportWorkOrder.WorkOrder_Id.GetInt();
                            var wo = _workOrderRepository.FindAsIQueryable(x => x.WorkOrder_Id == reportWorkOrder.WorkOrder_Id.GetInt())
                             .OrderByDescending(x => x.CreateDate)
                             .Select(s => new
                             {
                                 s.WorkOrderCode
                             })
                             .FirstOrDefault();
                            entity.WorkOrderCode = wo.WorkOrderCode;
                            entity.CreateID = userInfo.User_Id;
                            entity.Creator = userInfo.UserTrueName;
                            entity.CreateDate = DateTime.Now;
                            orderListNext.Add(entity);
                        }
                        else
                        {
                            return webResponse.Error("该工艺路线需要审批通过之后才能进行报工！");
                        }
                    }
                    _overWorkOrderRepository.AddRange(orderListNext, true);
                }
                return webResponse.OK();
            };
            return base.Add(saveDataModel);
        }
        /// <summary>
        /// 编辑操作
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveModel)
        {
            //编辑方法保存数据库前处理
            UpdateOnExecuting = (Production_ReportWorkOrder reportWorkOrder, object addList, object updateList, List<object> delKeys) =>
            {
                List<Production_ReportWorkOrderList> addListS = addList as List<Production_ReportWorkOrderList>;
                List<Production_ReportWorkOrderList> updateLists = updateList as List<Production_ReportWorkOrderList>;
                if (reportWorkOrder.NoGoodQty != null && reportWorkOrder.NoGoodQty != 0 && (addListS.Count == 0 && updateLists == null))
                {
                    return webResponse.Error("有不良品请填写不良品项");
                };
                return webResponse.OK();
            };
            return base.Update(saveModel);
        }
    }
}
