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

            // Table & Column Mappings
            this.ToTable("Achievement");
            this.Property(t => t.AchievementId).HasColumnName("AchievementId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.ImageUrl).HasColumnName("ImageUrl");
            this.Property(t => t.QRCodeText).HasColumnName("QRCodeText");

            // Relationships
            this.HasMany(t => t.Tags)
                .WithMany(t => t.Achievements)
                .Map(m =>
                    {
                        m.ToTable("Achievement_Tag");
                        m.MapLeftKey("AchievementId");
                        m.MapRightKey("Tag");
                    });

            this.HasMany(t => t.Epics)
                .WithMany(t => t.Achievements)
                .Map(m =>
                    {
                        m.ToTable("Epic_Achievement");
                        m.MapLeftKey("AchievementId");
                        m.MapRightKey("EpicId");
                    });

            this.HasMany(t => t.Quests)
                .WithMany(t => t.Achievements)
                .Map(m =>
                    {
                        m.ToTable("Quest_Achievement");
                        m.MapLeftKey("AchievementId");
                        m.MapRightKey("QuestId");
                    });


        }
    }
}
