/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Base_LanguageService与IBase_LanguageService中编写
 */
using iMES.Custom.IRepositories;
using iMES.Custom.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Custom.Services
{
    public partial class Base_LanguageService : ServiceBase<Base_Language, IBase_LanguageRepository>
    , IBase_LanguageService, IDependency
    {
    public Base_LanguageService(IBase_LanguageRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IBase_LanguageService Instance
    {
      get { return AutofacContainerModule.GetService<IBase_LanguageService>(); } }
    }
 }
