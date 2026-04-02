using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Base_LanguageMapConfig : EntityMappingConfiguration<Base_Language>
    {
        public override void Map(EntityTypeBuilder<Base_Language>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

