using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LevelUp.Database.Models.Mapping
{
    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            // Primary Key
            this.HasKey(t => t.Tag1);

            // Properties
            this.Property(t => t.Tag1)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Tag");
            this.Property(t => t.Tag1).HasColumnName("Tag");
        }
    }
}
