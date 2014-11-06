using System;

namespace LevelUp.Database.Models
{
    public partial class Epic_Hero
    {
        public int EpicId { get; set; }
        public int HeroId { get; set; }
        public DateTime? Completed { get; set; }
        public virtual Epic Epic { get; set; }
        public virtual Hero Hero { get; set; }
    }
}
