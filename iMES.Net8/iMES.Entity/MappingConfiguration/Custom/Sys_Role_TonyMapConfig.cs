using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Sys_Role_TonyMapConfig : EntityMappingConfiguration<Sys_Role_Tony>
    {
        public override void Map(EntityTypeBuilder<Sys_Role_Tony>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

