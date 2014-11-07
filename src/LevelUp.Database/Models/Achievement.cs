using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class Achievement
    {
        public Achievement()
        {
            Tags = new List<Tag>();
            Epics = new List<Epic>();
            Heroes = new List<Hero>();
            Quests = new List<Quest>();
        }

        public int AchievementId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Points { get; set; }
        public byte[] Image { get; set; }
        public string ImageUrl { get; set; }
        public string QRCodeText { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Epic> Epics { get; set; }
        public virtual ICollection<Hero> Heroes { get; set; } 
        public virtual ICollection<Quest> Quests { get; set; }
    }
}
