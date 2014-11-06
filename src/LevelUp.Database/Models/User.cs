using System;
using System.Collections.Generic;

namespace LevelUp.Database.Models
{
    public partial class User
    {
        public User()
        {
            this.Epic_User = new List<Epic_User>();
            this.Parties = new List<Party>();
            this.Quest_User = new List<Quest_User>();
            this.User_Achievement = new List<User_Achievement>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Gravatar { get; set; }
        public virtual ICollection<Epic_User> Epic_User { get; set; }
        public virtual ICollection<Party> Parties { get; set; }
        public virtual ICollection<Quest_User> Quest_User { get; set; }
        public virtual ICollection<User_Achievement> User_Achievement { get; set; }
    }
}
