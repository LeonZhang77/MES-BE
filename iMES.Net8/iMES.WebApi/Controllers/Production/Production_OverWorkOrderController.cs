/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Production_OverWorkOrderController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Production.IServices;
namespace iMES.Production.Controllers
{
    [Route("api/Production_OverWorkOrder")]
    [PermissionTable(Name = "Production_OverWorkOrder")]
    public partial class Production_OverWorkOrderController : ApiBaseController<IProduction_OverWorkOrderService>
    {
        public Production_OverWorkOrderController(IProduction_OverWorkOrderService service)
        : base(service)
        {
        }
    }
}

