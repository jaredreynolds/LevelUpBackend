using System;
using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class Tag
    {
        public Tag()
        {
            this.Achievements = new List<Achievement>();
            this.Epics = new List<Epic>();
            this.Quests = new List<Quest>();
        }

        public string Tag1 { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Epic> Epics { get; set; }
        public virtual ICollection<Quest> Quests { get; set; }
    }
}
