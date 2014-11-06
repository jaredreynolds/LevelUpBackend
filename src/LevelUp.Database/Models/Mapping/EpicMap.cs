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

            // Table & Column Mappings
            this.ToTable("Epic");
            this.Property(t => t.EpicId).HasColumnName("EpicId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasMany(t => t.Quests)
                .WithMany(t => t.Epics)
                .Map(m =>
                    {
                        m.ToTable("Epic_Quest");
                        m.MapLeftKey("EpicId");
                        m.MapRightKey("QuestId");
                    });

            this.HasMany(t => t.Tags)
                .WithMany(t => t.Epics)
                .Map(m =>
                    {
                        m.ToTable("Epic_Tag");
                        m.MapLeftKey("EpicId");
                        m.MapRightKey("Tag");
                    });


        }
    }
}
