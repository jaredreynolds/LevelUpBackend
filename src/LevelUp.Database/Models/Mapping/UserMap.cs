using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace LevelUp.Database.Models.Mapping
{
    public class HeroMap : EntityTypeConfiguration<Hero>
    {
        public HeroMap()
        {
            // Primary Key
            this.HasKey(t => t.HeroId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.GravatarUrl)
                .HasMaxLength(1024);

            // Table & Column Mappings
            this.ToTable("Hero");
            this.Property(t => t.HeroId).HasColumnName("HeroId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.GravatarUrl).HasColumnName("GravatarUrl");
        }
    }
}
