/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Production_OverWorkOrder",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using iMES.Entity.DomainModels;
using iMES.Production.IServices;
using iMES.Production.IRepositories;
using iMES.Core.ManageUser;

namespace iMES.Production.Controllers
{
    public partial class Production_OverWorkOrderController
    {
        private readonly IProduction_OverWorkOrderService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProduction_OverWorkOrderRepository _overWorkOrderRepository;

        [ActivatorUtilitiesConstructor]
        public Production_OverWorkOrderController(
            IProduction_OverWorkOrderService service,
            IHttpContextAccessor httpContextAccessor,
            IProduction_OverWorkOrderRepository overWorkOrderRepository
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _overWorkOrderRepository = overWorkOrderRepository;
        }

        /// <summary>
        /// 工单状态变更
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet, Route("changeUpdate")]
        public string ChangeUpdate(int overWorkOrder_Id, string status)
        {
            UserInfo userInfo = UserContext.Current.UserInfo;
            Production_OverWorkOrder overWorkOrder = new Production_OverWorkOrder()
            {
                OverWorkOrder_Id = overWorkOrder_Id,
                Status = Convert.ToInt32(status),
                ApproverDate = DateTime.Now,
                ApproverUserName = userInfo.UserTrueName
            };
            _overWorkOrderRepository.Update(overWorkOrder, x => new { x.Status, x.ApproverDate, x.ApproverUserName }, true);
            return "变更成功！";
        }
    }
}
