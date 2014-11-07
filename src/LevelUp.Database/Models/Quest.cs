using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class Quest
    {
        public Quest()
        {
            Parties = new List<Party>();
            Heroes = new List<Hero>();
            Epics = new List<Epic>();
            Achievements = new List<Achievement>();
            Tags = new List<Tag>();
        }

        public int QuestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Party> Parties { get; set; }
        public virtual ICollection<Hero> Heroes { get; set; }
        public virtual ICollection<Epic> Epics { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
