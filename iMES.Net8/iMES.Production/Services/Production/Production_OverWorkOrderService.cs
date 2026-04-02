/*
 *Author：COCO
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Production_OverWorkOrderService与IProduction_OverWorkOrderService中编写
 */
using iMES.Production.IRepositories;
using iMES.Production.IServices;
using iMES.Core.BaseProvider;
using iMES.Core.Extensions.AutofacManager;
using iMES.Entity.DomainModels;

namespace iMES.Production.Services
{
    public partial class Production_OverWorkOrderService : ServiceBase<Production_OverWorkOrder, IProduction_OverWorkOrderRepository>
    , IProduction_OverWorkOrderService, IDependency
    {
    public Production_OverWorkOrderService(IProduction_OverWorkOrderRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IProduction_OverWorkOrderService Instance
    {
      get { return AutofacContainerModule.GetService<IProduction_OverWorkOrderService>(); } }
    }
 }
