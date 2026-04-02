/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Sys_Role_TonyService与ISys_Role_TonyService中编写
 */
using iMES.Custom.IRepositories;
using iMES.Custom.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Custom.Services
{
    public partial class Sys_Role_TonyService : ServiceBase<Sys_Role_Tony, ISys_Role_TonyRepository>
    , ISys_Role_TonyService, IDependency
    {
    public Sys_Role_TonyService(ISys_Role_TonyRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ISys_Role_TonyService Instance
    {
      get { return AutofacContainerModule.GetService<ISys_Role_TonyService>(); } }
    }
 }
