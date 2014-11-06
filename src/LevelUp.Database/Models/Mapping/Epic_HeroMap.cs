using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LevelUp.Database.Models.Mapping
{
    public class Epic_HeroMap : EntityTypeConfiguration<Epic_Hero>
    {
        public Epic_HeroMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EpicId, t.HeroId });

            // Properties
            this.Property(t => t.EpicId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.HeroId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Epic_Hero");
            this.Property(t => t.EpicId).HasColumnName("EpicId");
            this.Property(t => t.HeroId).HasColumnName("HeroId");
            this.Property(t => t.Completed).HasColumnName("Completed");

            // Relationships
            this.HasRequired(t => t.Epic)
                .WithMany(t => t.Epic_Hero)
                .HasForeignKey(d => d.EpicId);
            this.HasRequired(t => t.Hero)
                .WithMany(t => t.Epic_Hero)
                .HasForeignKey(d => d.HeroId);

        }
    }
}
