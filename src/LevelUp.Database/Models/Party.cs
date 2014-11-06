using System;
using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class Party
    {
        public int PartyId { get; set; }
        public int QuestId { get; set; }
        public int UserId { get; set; }
        public virtual Quest Quest { get; set; }
        public virtual User User { get; set; }
    }
}
