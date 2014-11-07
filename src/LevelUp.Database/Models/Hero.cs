using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class Hero
    {
        public Hero()
        {
            Epics = new List<Epic>();
            Parties = new List<Party>();
            Quests = new List<Quest>();
            Achievements = new List<Achievement>();
        }

        public int HeroId { get; set; }
        public string Name { get; set; }
        public string GravatarUrl { get; set; }
        public virtual ICollection<Epic> Epics { get; set; }
        public virtual ICollection<Party> Parties { get; set; }
        public virtual ICollection<Quest> Quests { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}
