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
        }
    }
}
