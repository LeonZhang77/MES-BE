/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Sys_Role_YDTService与ISys_Role_YDTService中编写
 */
using iMES.Custom.IRepositories;
using iMES.Custom.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Custom.Services
{
    public partial class Sys_Role_YDTService : ServiceBase<Sys_Role_YDT, ISys_Role_YDTRepository>
    , ISys_Role_YDTService, IDependency
    {
    public Sys_Role_YDTService(ISys_Role_YDTRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static ISys_Role_YDTService Instance
    {
      get { return AutofacContainerModule.GetService<ISys_Role_YDTService>(); } }
    }
 }
