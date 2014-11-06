using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LevelUp.Database.Models.Mapping
{
    public class Hero_AchievementMap : EntityTypeConfiguration<Hero_Achievement>
    {
        public Hero_AchievementMap()
        {
            // Primary Key
            this.HasKey(t => new { t.HeroId, t.AchievementId });

            // Properties
            this.Property(t => t.HeroId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AchievementId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Hero_Achievement");
            this.Property(t => t.HeroId).HasColumnName("HeroId");
            this.Property(t => t.AchievementId).HasColumnName("AchievementId");
            this.Property(t => t.Completed).HasColumnName("Completed");

            // Relationships
            this.HasRequired(t => t.Achievement)
                .WithMany(t => t.Hero_Achievement)
                .HasForeignKey(d => d.AchievementId);
            this.HasRequired(t => t.Hero)
                .WithMany(t => t.Hero_Achievement)
                .HasForeignKey(d => d.HeroId);

        }
    }
}
