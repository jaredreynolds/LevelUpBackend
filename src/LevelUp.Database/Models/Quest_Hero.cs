using System;

namespace LevelUp.Database.Models
{
    public partial class Quest_Hero
    {
        public int QuestId { get; set; }
        public int HeroId { get; set; }
        public DateTime? Completed { get; set; }
        public virtual Quest Quest { get; set; }
        public virtual Hero Hero { get; set; }
    }
}
