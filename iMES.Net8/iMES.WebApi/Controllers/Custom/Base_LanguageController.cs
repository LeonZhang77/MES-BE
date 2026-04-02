/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Base_LanguageController编写
 */
using Microsoft.AspNetCore.Mvc;
using iMES.Core.Controllers.Basic;
using iMES.Entity.AttributeManager;
using iMES.Custom.IServices;
namespace iMES.Custom.Controllers
{
    [Route("api/Base_Language")]
    [PermissionTable(Name = "Base_Language")]
    public partial class Base_LanguageController : ApiBaseController<IBase_LanguageService>
    {
        public Base_LanguageController(IBase_LanguageService service)
        : base(service)
        {
        }
    }
}

