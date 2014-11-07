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
        }
    }
}
