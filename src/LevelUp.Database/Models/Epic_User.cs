using System;
using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class Epic_User
    {
        public int EpicId { get; set; }
        public int UserId { get; set; }
        public Nullable<System.DateTime> Completed { get; set; }
        public virtual Epic Epic { get; set; }
        public virtual User User { get; set; }
    }
}
