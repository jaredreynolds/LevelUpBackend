using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LevelUp.Database.Models.Mapping
{
    public class Quest_UserMap : EntityTypeConfiguration<Quest_User>
    {
        public Quest_UserMap()
        {
            // Primary Key
            this.HasKey(t => new { t.QuestId, t.UserId });

            // Properties
            this.Property(t => t.QuestId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Quest_User");
            this.Property(t => t.QuestId).HasColumnName("QuestId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Completed).HasColumnName("Completed");

            // Relationships
            this.HasRequired(t => t.Quest)
                .WithMany(t => t.Quest_User)
                .HasForeignKey(d => d.QuestId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Quest_User)
                .HasForeignKey(d => d.UserId);

        }
    }
}
