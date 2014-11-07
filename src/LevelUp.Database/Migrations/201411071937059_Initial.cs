namespace LevelUp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        AchievementId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                        Type = c.String(nullable: false, maxLength: 50),
                        Points = c.Int(nullable: false),
                        Image = c.Binary(),
                        ImageUrl = c.String(maxLength: 1024),
                        QRCodeText = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.AchievementId);
            
            CreateTable(
                "dbo.Epics",
                c => new
                    {
                        EpicId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                        Hero_HeroId = c.Int(),
                    })
                .PrimaryKey(t => t.EpicId)
                .ForeignKey("dbo.Heroes", t => t.Hero_HeroId)
                .Index(t => t.Hero_HeroId);
            
            CreateTable(
                "dbo.Quests",
                c => new
                    {
                        QuestId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.QuestId);
            
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        HeroId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        GravatarUrl = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.HeroId);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        PartyId = c.Int(nullable: false, identity: true),
                        QuestId = c.Int(nullable: false),
                        HeroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartyId)
                .ForeignKey("dbo.Heroes", t => t.HeroId, cascadeDelete: true)
                .ForeignKey("dbo.Quests", t => t.QuestId, cascadeDelete: true)
                .Index(t => t.QuestId)
                .Index(t => t.HeroId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.EpicAchievements",
                c => new
                    {
                        Epic_EpicId = c.Int(nullable: false),
                        Achievement_AchievementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Epic_EpicId, t.Achievement_AchievementId })
                .ForeignKey("dbo.Epics", t => t.Epic_EpicId, cascadeDelete: true)
                .ForeignKey("dbo.Achievements", t => t.Achievement_AchievementId, cascadeDelete: true)
                .Index(t => t.Epic_EpicId)
                .Index(t => t.Achievement_AchievementId);
            
            CreateTable(
                "dbo.QuestAchievements",
                c => new
                    {
                        Quest_QuestId = c.Int(nullable: false),
                        Achievement_AchievementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Quest_QuestId, t.Achievement_AchievementId })
                .ForeignKey("dbo.Quests", t => t.Quest_QuestId, cascadeDelete: true)
                .ForeignKey("dbo.Achievements", t => t.Achievement_AchievementId, cascadeDelete: true)
                .Index(t => t.Quest_QuestId)
                .Index(t => t.Achievement_AchievementId);
            
            CreateTable(
                "dbo.QuestEpics",
                c => new
                    {
                        Quest_QuestId = c.Int(nullable: false),
                        Epic_EpicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Quest_QuestId, t.Epic_EpicId })
                .ForeignKey("dbo.Quests", t => t.Quest_QuestId, cascadeDelete: true)
                .ForeignKey("dbo.Epics", t => t.Epic_EpicId, cascadeDelete: true)
                .Index(t => t.Quest_QuestId)
                .Index(t => t.Epic_EpicId);
            
            CreateTable(
                "dbo.HeroAchievements",
                c => new
                    {
                        Hero_HeroId = c.Int(nullable: false),
                        Achievement_AchievementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hero_HeroId, t.Achievement_AchievementId })
                .ForeignKey("dbo.Heroes", t => t.Hero_HeroId, cascadeDelete: true)
                .ForeignKey("dbo.Achievements", t => t.Achievement_AchievementId, cascadeDelete: true)
                .Index(t => t.Hero_HeroId)
                .Index(t => t.Achievement_AchievementId);
            
            CreateTable(
                "dbo.HeroQuests",
                c => new
                    {
                        Hero_HeroId = c.Int(nullable: false),
                        Quest_QuestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hero_HeroId, t.Quest_QuestId })
                .ForeignKey("dbo.Heroes", t => t.Hero_HeroId, cascadeDelete: true)
                .ForeignKey("dbo.Quests", t => t.Quest_QuestId, cascadeDelete: true)
                .Index(t => t.Hero_HeroId)
                .Index(t => t.Quest_QuestId);
            
            CreateTable(
                "dbo.TagAchievements",
                c => new
                    {
                        Tag_Name = c.String(nullable: false, maxLength: 150),
                        Achievement_AchievementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Name, t.Achievement_AchievementId })
                .ForeignKey("dbo.Tags", t => t.Tag_Name, cascadeDelete: true)
                .ForeignKey("dbo.Achievements", t => t.Achievement_AchievementId, cascadeDelete: true)
                .Index(t => t.Tag_Name)
                .Index(t => t.Achievement_AchievementId);
            
            CreateTable(
                "dbo.TagEpics",
                c => new
                    {
                        Tag_Name = c.String(nullable: false, maxLength: 150),
                        Epic_EpicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Name, t.Epic_EpicId })
                .ForeignKey("dbo.Tags", t => t.Tag_Name, cascadeDelete: true)
                .ForeignKey("dbo.Epics", t => t.Epic_EpicId, cascadeDelete: true)
                .Index(t => t.Tag_Name)
                .Index(t => t.Epic_EpicId);
            
            CreateTable(
                "dbo.TagQuests",
                c => new
                    {
                        Tag_Name = c.String(nullable: false, maxLength: 150),
                        Quest_QuestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Name, t.Quest_QuestId })
                .ForeignKey("dbo.Tags", t => t.Tag_Name, cascadeDelete: true)
                .ForeignKey("dbo.Quests", t => t.Quest_QuestId, cascadeDelete: true)
                .Index(t => t.Tag_Name)
                .Index(t => t.Quest_QuestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagQuests", "Quest_QuestId", "dbo.Quests");
            DropForeignKey("dbo.TagQuests", "Tag_Name", "dbo.Tags");
            DropForeignKey("dbo.TagEpics", "Epic_EpicId", "dbo.Epics");
            DropForeignKey("dbo.TagEpics", "Tag_Name", "dbo.Tags");
            DropForeignKey("dbo.TagAchievements", "Achievement_AchievementId", "dbo.Achievements");
            DropForeignKey("dbo.TagAchievements", "Tag_Name", "dbo.Tags");
            DropForeignKey("dbo.HeroQuests", "Quest_QuestId", "dbo.Quests");
            DropForeignKey("dbo.HeroQuests", "Hero_HeroId", "dbo.Heroes");
            DropForeignKey("dbo.Parties", "QuestId", "dbo.Quests");
            DropForeignKey("dbo.Parties", "HeroId", "dbo.Heroes");
            DropForeignKey("dbo.Epics", "Hero_HeroId", "dbo.Heroes");
            DropForeignKey("dbo.HeroAchievements", "Achievement_AchievementId", "dbo.Achievements");
            DropForeignKey("dbo.HeroAchievements", "Hero_HeroId", "dbo.Heroes");
            DropForeignKey("dbo.QuestEpics", "Epic_EpicId", "dbo.Epics");
            DropForeignKey("dbo.QuestEpics", "Quest_QuestId", "dbo.Quests");
            DropForeignKey("dbo.QuestAchievements", "Achievement_AchievementId", "dbo.Achievements");
            DropForeignKey("dbo.QuestAchievements", "Quest_QuestId", "dbo.Quests");
            DropForeignKey("dbo.EpicAchievements", "Achievement_AchievementId", "dbo.Achievements");
            DropForeignKey("dbo.EpicAchievements", "Epic_EpicId", "dbo.Epics");
            DropIndex("dbo.TagQuests", new[] { "Quest_QuestId" });
            DropIndex("dbo.TagQuests", new[] { "Tag_Name" });
            DropIndex("dbo.TagEpics", new[] { "Epic_EpicId" });
            DropIndex("dbo.TagEpics", new[] { "Tag_Name" });
            DropIndex("dbo.TagAchievements", new[] { "Achievement_AchievementId" });
            DropIndex("dbo.TagAchievements", new[] { "Tag_Name" });
            DropIndex("dbo.HeroQuests", new[] { "Quest_QuestId" });
            DropIndex("dbo.HeroQuests", new[] { "Hero_HeroId" });
            DropIndex("dbo.HeroAchievements", new[] { "Achievement_AchievementId" });
            DropIndex("dbo.HeroAchievements", new[] { "Hero_HeroId" });
            DropIndex("dbo.QuestEpics", new[] { "Epic_EpicId" });
            DropIndex("dbo.QuestEpics", new[] { "Quest_QuestId" });
            DropIndex("dbo.QuestAchievements", new[] { "Achievement_AchievementId" });
            DropIndex("dbo.QuestAchievements", new[] { "Quest_QuestId" });
            DropIndex("dbo.EpicAchievements", new[] { "Achievement_AchievementId" });
            DropIndex("dbo.EpicAchievements", new[] { "Epic_EpicId" });
            DropIndex("dbo.Parties", new[] { "HeroId" });
            DropIndex("dbo.Parties", new[] { "QuestId" });
            DropIndex("dbo.Epics", new[] { "Hero_HeroId" });
            DropTable("dbo.TagQuests");
            DropTable("dbo.TagEpics");
            DropTable("dbo.TagAchievements");
            DropTable("dbo.HeroQuests");
            DropTable("dbo.HeroAchievements");
            DropTable("dbo.QuestEpics");
            DropTable("dbo.QuestAchievements");
            DropTable("dbo.EpicAchievements");
            DropTable("dbo.Tags");
            DropTable("dbo.Parties");
            DropTable("dbo.Heroes");
            DropTable("dbo.Quests");
            DropTable("dbo.Epics");
            DropTable("dbo.Achievements");
        }
    }
}
