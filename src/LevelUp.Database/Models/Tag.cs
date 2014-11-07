using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class Tag
    {
        public Tag()
        {
            Achievements = new List<Achievement>();
            Epics = new List<Epic>();
            Quests = new List<Quest>();
        }

        public string Name { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Epic> Epics { get; set; }
        public virtual ICollection<Quest> Quests { get; set; }
    }
}
