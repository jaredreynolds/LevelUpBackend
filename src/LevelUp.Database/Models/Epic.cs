using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class Epic
    {
        public Epic()
        {
            Achievements = new List<Achievement>();
            Quests = new List<Quest>();
            Tags = new List<Tag>();
        }

        public int EpicId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Quest> Quests { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
