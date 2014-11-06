using System;
using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class User_Achievement
    {
        public int UserId { get; set; }
        public int AchievementId { get; set; }
        public Nullable<System.DateTime> Completed { get; set; }
        public virtual Achievement Achievement { get; set; }
        public virtual User User { get; set; }
    }
}
