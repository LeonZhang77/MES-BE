using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Production_OverWorkOrderMapConfig : EntityMappingConfiguration<Production_OverWorkOrder>
    {
        public override void Map(EntityTypeBuilder<Production_OverWorkOrder>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

