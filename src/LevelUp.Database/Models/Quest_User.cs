using System;
using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class Quest_User
    {
        public int QuestId { get; set; }
        public int UserId { get; set; }
        public Nullable<System.DateTime> Completed { get; set; }
        public virtual Quest Quest { get; set; }
        public virtual User User { get; set; }
    }
}
