using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LevelUp.Database.Models.Mapping
{
    public class Epic_UserMap : EntityTypeConfiguration<Epic_User>
    {
        public Epic_UserMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EpicId, t.UserId });

            // Properties
            this.Property(t => t.EpicId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Epic_User");
            this.Property(t => t.EpicId).HasColumnName("EpicId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Completed).HasColumnName("Completed");

            // Relationships
            this.HasRequired(t => t.Epic)
                .WithMany(t => t.Epic_User)
                .HasForeignKey(d => d.EpicId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Epic_User)
                .HasForeignKey(d => d.UserId);

        }
    }
}
