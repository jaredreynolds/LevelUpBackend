using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LevelUp.Database.Models.Mapping
{
    public class QuestMap : EntityTypeConfiguration<Quest>
    {
        public QuestMap()
        {
            // Primary Key
            this.HasKey(t => t.QuestId);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Quest");
            this.Property(t => t.QuestId).HasColumnName("QuestId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasMany(t => t.Tags)
                .WithMany(t => t.Quests)
                .Map(m =>
                    {
                        m.ToTable("Quest_Tag");
                        m.MapLeftKey("QuestId");
                        m.MapRightKey("Tag");
                    });


        }
    }
}
