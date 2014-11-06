using System.Data.Entity;
using LevelUp.Database.Models.Mapping;

namespace LevelUp.Database.Models
{
    public partial class LevelUpContext : DbContext
    {
        static LevelUpContext()
        {
            System.Data.Entity.Database.SetInitializer<LevelUpContext>(null);
        }

        public LevelUpContext()
            : base("Name=LevelUpContext")
        {
        }

        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Epic> Epics { get; set; }
        public DbSet<Epic_User> Epic_User { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Quest_User> Quest_User { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_Achievement> User_Achievement { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AchievementMap());
            modelBuilder.Configurations.Add(new EpicMap());
            modelBuilder.Configurations.Add(new Epic_UserMap());
            modelBuilder.Configurations.Add(new PartyMap());
            modelBuilder.Configurations.Add(new QuestMap());
            modelBuilder.Configurations.Add(new Quest_UserMap());
            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new User_AchievementMap());
        }
    }
}
