using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LevelUp.Database.Models.Mapping
{
    public class PartyMap : EntityTypeConfiguration<Party>
    {
        public PartyMap()
        {
            // Primary Key
            this.HasKey(t => t.PartyId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Party");
            this.Property(t => t.PartyId).HasColumnName("PartyId");
            this.Property(t => t.QuestId).HasColumnName("QuestId");
            this.Property(t => t.HeroId).HasColumnName("HeroId");

            // Relationships
            this.HasRequired(t => t.Quest)
                .WithMany(t => t.Parties)
                .HasForeignKey(d => d.QuestId);
            this.HasRequired(t => t.Hero)
                .WithMany(t => t.Parties)
                .HasForeignKey(d => d.HeroId);

        }
    }
}
