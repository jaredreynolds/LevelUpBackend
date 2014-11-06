namespace LevelUp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedUsertoHero : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Epic_User", "EpicId", "dbo.Epic");
            DropForeignKey("dbo.Quest_User", "QuestId", "dbo.Quest");
            DropForeignKey("dbo.Quest_User", "UserId", "dbo.User");
            DropForeignKey("dbo.Party", "UserId", "dbo.User");
            DropForeignKey("dbo.User_Achievement", "AchievementId", "dbo.Achievement");
            DropForeignKey("dbo.User_Achievement", "UserId", "dbo.User");
            DropForeignKey("dbo.Epic_User", "UserId", "dbo.User");
            DropIndex("dbo.Epic_User", new[] { "EpicId" });
            DropIndex("dbo.Epic_User", new[] { "UserId" });
            DropIndex("dbo.Party", new[] { "UserId" });
            DropIndex("dbo.Quest_User", new[] { "QuestId" });
            DropIndex("dbo.Quest_User", new[] { "UserId" });
            DropIndex("dbo.User_Achievement", new[] { "UserId" });
            DropIndex("dbo.User_Achievement", new[] { "AchievementId" });
            CreateTable(
                "dbo.Epic_Hero",
                c => new
                    {
                        EpicId = c.Int(nullable: false),
                        HeroId = c.Int(nullable: false),
                        Completed = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.EpicId, t.HeroId })
                .ForeignKey("dbo.Epic", t => t.EpicId, cascadeDelete: true)
                .ForeignKey("dbo.Hero", t => t.HeroId, cascadeDelete: true)
                .Index(t => t.EpicId)
                .Index(t => t.HeroId);
            
            CreateTable(
                "dbo.Hero",
                c => new
                    {
                        HeroId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        GravatarUrl = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.HeroId);
            
            CreateTable(
                "dbo.Hero_Achievement",
                c => new
                    {
                        HeroId = c.Int(nullable: false),
                        AchievementId = c.Int(nullable: false),
                        Completed = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.HeroId, t.AchievementId })
                .ForeignKey("dbo.Achievement", t => t.AchievementId, cascadeDelete: true)
                .ForeignKey("dbo.Hero", t => t.HeroId, cascadeDelete: true)
                .Index(t => t.HeroId)
                .Index(t => t.AchievementId);
            
            CreateTable(
                "dbo.Quest_Hero",
                c => new
                    {
                        QuestId = c.Int(nullable: false),
                        HeroId = c.Int(nullable: false),
                        Completed = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.QuestId, t.HeroId })
                .ForeignKey("dbo.Hero", t => t.HeroId, cascadeDelete: true)
                .ForeignKey("dbo.Quest", t => t.QuestId, cascadeDelete: true)
                .Index(t => t.QuestId)
                .Index(t => t.HeroId);
            
            AddColumn("dbo.Party", "HeroId", c => c.Int(nullable: false));
            CreateIndex("dbo.Party", "HeroId");
            AddForeignKey("dbo.Party", "HeroId", "dbo.Hero", "HeroId", cascadeDelete: true);
            DropColumn("dbo.Party", "UserId");
            DropTable("dbo.Epic_User");
            DropTable("dbo.User");
            DropTable("dbo.Quest_User");
            DropTable("dbo.User_Achievement");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User_Achievement",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        AchievementId = c.Int(nullable: false),
                        Completed = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.UserId, t.AchievementId });
            
            CreateTable(
                "dbo.Quest_User",
                c => new
                    {
                        QuestId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Completed = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.QuestId, t.UserId });
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Gravatar = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Epic_User",
                c => new
                    {
                        EpicId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Completed = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.EpicId, t.UserId });
            
            AddColumn("dbo.Party", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Epic_Hero", "HeroId", "dbo.Hero");
            DropForeignKey("dbo.Quest_Hero", "QuestId", "dbo.Quest");
            DropForeignKey("dbo.Quest_Hero", "HeroId", "dbo.Hero");
            DropForeignKey("dbo.Party", "HeroId", "dbo.Hero");
            DropForeignKey("dbo.Hero_Achievement", "HeroId", "dbo.Hero");
            DropForeignKey("dbo.Hero_Achievement", "AchievementId", "dbo.Achievement");
            DropForeignKey("dbo.Epic_Hero", "EpicId", "dbo.Epic");
            DropIndex("dbo.Quest_Hero", new[] { "HeroId" });
            DropIndex("dbo.Quest_Hero", new[] { "QuestId" });
            DropIndex("dbo.Party", new[] { "HeroId" });
            DropIndex("dbo.Hero_Achievement", new[] { "AchievementId" });
            DropIndex("dbo.Hero_Achievement", new[] { "HeroId" });
            DropIndex("dbo.Epic_Hero", new[] { "HeroId" });
            DropIndex("dbo.Epic_Hero", new[] { "EpicId" });
            DropColumn("dbo.Party", "HeroId");
            DropTable("dbo.Quest_Hero");
            DropTable("dbo.Hero_Achievement");
            DropTable("dbo.Hero");
            DropTable("dbo.Epic_Hero");
            CreateIndex("dbo.User_Achievement", "AchievementId");
            CreateIndex("dbo.User_Achievement", "UserId");
            CreateIndex("dbo.Quest_User", "UserId");
            CreateIndex("dbo.Quest_User", "QuestId");
            CreateIndex("dbo.Party", "UserId");
            CreateIndex("dbo.Epic_User", "UserId");
            CreateIndex("dbo.Epic_User", "EpicId");
            AddForeignKey("dbo.Epic_User", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.User_Achievement", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.User_Achievement", "AchievementId", "dbo.Achievement", "AchievementId", cascadeDelete: true);
            AddForeignKey("dbo.Party", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Quest_User", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Quest_User", "QuestId", "dbo.Quest", "QuestId", cascadeDelete: true);
            AddForeignKey("dbo.Epic_User", "EpicId", "dbo.Epic", "EpicId", cascadeDelete: true);
        }
    }
}
