using System;
using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class Quest
    {
        public Quest()
        {
            this.Parties = new List<Party>();
            this.Quest_Hero = new List<Quest_Hero>();
            this.Epics = new List<Epic>();
            this.Achievements = new List<Achievement>();
            this.Tags = new List<Tag>();
        }

        public int QuestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Party> Parties { get; set; }
        public virtual ICollection<Quest_Hero> Quest_Hero { get; set; }
        public virtual ICollection<Epic> Epics { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
