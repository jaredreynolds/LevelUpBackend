using System;
using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class Hero
    {
        public Hero()
        {
            Epic_Hero = new List<Epic_Hero>();
            Parties = new List<Party>();
            Quest_Hero = new List<Quest_Hero>();
            Hero_Achievement = new List<Hero_Achievement>();
        }

        public int HeroId { get; set; }
        public string Name { get; set; }
        public string GravatarUrl { get; set; }
        public virtual ICollection<Epic_Hero> Epic_Hero { get; set; }
        public virtual ICollection<Party> Parties { get; set; }
        public virtual ICollection<Quest_Hero> Quest_Hero { get; set; }
        public virtual ICollection<Hero_Achievement> Hero_Achievement { get; set; }
    }
}
