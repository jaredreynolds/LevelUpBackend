using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LevelUp.Database.Models.Mapping
{
    public class User_AchievementMap : EntityTypeConfiguration<User_Achievement>
    {
        public User_AchievementMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.AchievementId });

            // Properties
            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AchievementId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("User_Achievement");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.AchievementId).HasColumnName("AchievementId");
            this.Property(t => t.Completed).HasColumnName("Completed");

            // Relationships
            this.HasRequired(t => t.Achievement)
                .WithMany(t => t.User_Achievement)
                .HasForeignKey(d => d.AchievementId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.User_Achievement)
                .HasForeignKey(d => d.UserId);

        }
    }
}
