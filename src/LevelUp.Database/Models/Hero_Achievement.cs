using System;
using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class Hero_Achievement
    {
        public int HeroId { get; set; }
        public int AchievementId { get; set; }
        public DateTime? Completed { get; set; }
        public virtual Achievement Achievement { get; set; }
        public virtual Hero Hero { get; set; }
    }
}
