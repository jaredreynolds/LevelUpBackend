using System;
using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class Epic
    {
        public Epic()
        {
            this.Epic_User = new List<Epic_User>();
            this.Achievements = new List<Achievement>();
            this.Quests = new List<Quest>();
            this.Tags = new List<Tag>();
        }

        public int EpicId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Epic_User> Epic_User { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Quest> Quests { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
