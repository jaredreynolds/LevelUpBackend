using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LevelUp.Database.Models.Mapping
{
    public class Quest_HeroMap : EntityTypeConfiguration<Quest_Hero>
    {
        public Quest_HeroMap()
        {
            // Primary Key
            this.HasKey(t => new { t.QuestId, t.HeroId });

            // Properties
            this.Property(t => t.QuestId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.HeroId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Quest_Hero");
            this.Property(t => t.QuestId).HasColumnName("QuestId");
            this.Property(t => t.HeroId).HasColumnName("HeroId");
            this.Property(t => t.Completed).HasColumnName("Completed");

            // Relationships
            this.HasRequired(t => t.Quest)
                .WithMany(t => t.Quest_Hero)
                .HasForeignKey(d => d.QuestId);
            this.HasRequired(t => t.Hero)
                .WithMany(t => t.Quest_Hero)
                .HasForeignKey(d => d.HeroId);

        }
    }
}
