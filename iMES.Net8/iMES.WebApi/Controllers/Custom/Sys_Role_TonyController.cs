/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Sys_Role_TonyController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Custom.IServices;
namespace iMES.Custom.Controllers
{
    [Route("api/Sys_Role_Tony")]
    [PermissionTable(Name = "Sys_Role_Tony")]
    public partial class Sys_Role_TonyController : ApiBaseController<ISys_Role_TonyService>
    {
        public Sys_Role_TonyController(ISys_Role_TonyService service)
        : base(service)
        {
        }
    }
}

