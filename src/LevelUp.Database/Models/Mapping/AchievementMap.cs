using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LevelUp.Database.Models.Mapping
{
    public class AchievementMap : EntityTypeConfiguration<Achievement>
    {
        public AchievementMap()
        {
            // Primary Key
            this.HasKey(t => t.AchievementId);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ImageUrl)
                .HasMaxLength(1024);

            this.Property(t => t.QRCodeText)
                .HasMaxLength(2000);
        }
    }
}
