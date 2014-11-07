using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LevelUp.Database.Models.Mapping
{
    public class EpicMap : EntityTypeConfiguration<Epic>
    {
        public EpicMap()
        {
            // Primary Key
            this.HasKey(t => t.EpicId);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
