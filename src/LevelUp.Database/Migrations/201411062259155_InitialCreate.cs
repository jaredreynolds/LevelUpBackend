namespace LevelUp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievement",
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
                "dbo.Epic",
                c => new
                    {
                        EpicId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.EpicId);
            
            CreateTable(
                "dbo.Epic_User",
                c => new
                    {
                        EpicId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Completed = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.EpicId, t.UserId })
                .ForeignKey("dbo.Epic", t => t.EpicId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.EpicId)
                .Index(t => t.UserId);
            
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
                "dbo.Party",
                c => new
                    {
                        PartyId = c.Int(nullable: false, identity: true),
                        QuestId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartyId)
                .ForeignKey("dbo.Quest", t => t.QuestId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.QuestId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Quest",
                c => new
                    {
                        QuestId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.QuestId);
            
            CreateTable(
                "dbo.Quest_User",
                c => new
                    {
                        QuestId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Completed = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.QuestId, t.UserId })
                .ForeignKey("dbo.Quest", t => t.QuestId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.QuestId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Tag = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Tag);
            
            CreateTable(
                "dbo.User_Achievement",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        AchievementId = c.Int(nullable: false),
                        Completed = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.UserId, t.AchievementId })
                .ForeignKey("dbo.Achievement", t => t.AchievementId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AchievementId);
            
            CreateTable(
                "dbo.Quest_Tag",
                c => new
                    {
                        QuestId = c.Int(nullable: false),
                        Tag = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => new { t.QuestId, t.Tag })
                .ForeignKey("dbo.Quest", t => t.QuestId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.Tag, cascadeDelete: true)
                .Index(t => t.QuestId)
                .Index(t => t.Tag);
            
            CreateTable(
                "dbo.Epic_Quest",
                c => new
                    {
                        EpicId = c.Int(nullable: false),
                        QuestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EpicId, t.QuestId })
                .ForeignKey("dbo.Epic", t => t.EpicId, cascadeDelete: true)
                .ForeignKey("dbo.Quest", t => t.QuestId, cascadeDelete: true)
                .Index(t => t.EpicId)
                .Index(t => t.QuestId);
            
            CreateTable(
                "dbo.Epic_Tag",
                c => new
                    {
                        EpicId = c.Int(nullable: false),
                        Tag = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => new { t.EpicId, t.Tag })
                .ForeignKey("dbo.Epic", t => t.EpicId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.Tag, cascadeDelete: true)
                .Index(t => t.EpicId)
                .Index(t => t.Tag);
            
            CreateTable(
                "dbo.Epic_Achievement",
                c => new
                    {
                        AchievementId = c.Int(nullable: false),
                        EpicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AchievementId, t.EpicId })
                .ForeignKey("dbo.Achievement", t => t.AchievementId, cascadeDelete: true)
                .ForeignKey("dbo.Epic", t => t.EpicId, cascadeDelete: true)
                .Index(t => t.AchievementId)
                .Index(t => t.EpicId);
            
            CreateTable(
                "dbo.Quest_Achievement",
                c => new
                    {
                        AchievementId = c.Int(nullable: false),
                        QuestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AchievementId, t.QuestId })
                .ForeignKey("dbo.Achievement", t => t.AchievementId, cascadeDelete: true)
                .ForeignKey("dbo.Quest", t => t.QuestId, cascadeDelete: true)
                .Index(t => t.AchievementId)
                .Index(t => t.QuestId);
            
            CreateTable(
                "dbo.Achievement_Tag",
                c => new
                    {
                        AchievementId = c.Int(nullable: false),
                        Tag = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => new { t.AchievementId, t.Tag })
                .ForeignKey("dbo.Achievement", t => t.AchievementId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.Tag, cascadeDelete: true)
                .Index(t => t.AchievementId)
                .Index(t => t.Tag);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Achievement_Tag", "Tag", "dbo.Tag");
            DropForeignKey("dbo.Achievement_Tag", "AchievementId", "dbo.Achievement");
            DropForeignKey("dbo.Quest_Achievement", "QuestId", "dbo.Quest");
            DropForeignKey("dbo.Quest_Achievement", "AchievementId", "dbo.Achievement");
            DropForeignKey("dbo.Epic_Achievement", "EpicId", "dbo.Epic");
            DropForeignKey("dbo.Epic_Achievement", "AchievementId", "dbo.Achievement");
            DropForeignKey("dbo.Epic_Tag", "Tag", "dbo.Tag");
            DropForeignKey("dbo.Epic_Tag", "EpicId", "dbo.Epic");
            DropForeignKey("dbo.Epic_Quest", "QuestId", "dbo.Quest");
            DropForeignKey("dbo.Epic_Quest", "EpicId", "dbo.Epic");
            DropForeignKey("dbo.Epic_User", "UserId", "dbo.User");
            DropForeignKey("dbo.User_Achievement", "UserId", "dbo.User");
            DropForeignKey("dbo.User_Achievement", "AchievementId", "dbo.Achievement");
            DropForeignKey("dbo.Party", "UserId", "dbo.User");
            DropForeignKey("dbo.Party", "QuestId", "dbo.Quest");
            DropForeignKey("dbo.Quest_Tag", "Tag", "dbo.Tag");
            DropForeignKey("dbo.Quest_Tag", "QuestId", "dbo.Quest");
            DropForeignKey("dbo.Quest_User", "UserId", "dbo.User");
            DropForeignKey("dbo.Quest_User", "QuestId", "dbo.Quest");
            DropForeignKey("dbo.Epic_User", "EpicId", "dbo.Epic");
            DropIndex("dbo.Achievement_Tag", new[] { "Tag" });
            DropIndex("dbo.Achievement_Tag", new[] { "AchievementId" });
            DropIndex("dbo.Quest_Achievement", new[] { "QuestId" });
            DropIndex("dbo.Quest_Achievement", new[] { "AchievementId" });
            DropIndex("dbo.Epic_Achievement", new[] { "EpicId" });
            DropIndex("dbo.Epic_Achievement", new[] { "AchievementId" });
            DropIndex("dbo.Epic_Tag", new[] { "Tag" });
            DropIndex("dbo.Epic_Tag", new[] { "EpicId" });
            DropIndex("dbo.Epic_Quest", new[] { "QuestId" });
            DropIndex("dbo.Epic_Quest", new[] { "EpicId" });
            DropIndex("dbo.Quest_Tag", new[] { "Tag" });
            DropIndex("dbo.Quest_Tag", new[] { "QuestId" });
            DropIndex("dbo.User_Achievement", new[] { "AchievementId" });
            DropIndex("dbo.User_Achievement", new[] { "UserId" });
            DropIndex("dbo.Quest_User", new[] { "UserId" });
            DropIndex("dbo.Quest_User", new[] { "QuestId" });
            DropIndex("dbo.Party", new[] { "UserId" });
            DropIndex("dbo.Party", new[] { "QuestId" });
            DropIndex("dbo.Epic_User", new[] { "UserId" });
            DropIndex("dbo.Epic_User", new[] { "EpicId" });
            DropTable("dbo.Achievement_Tag");
            DropTable("dbo.Quest_Achievement");
            DropTable("dbo.Epic_Achievement");
            DropTable("dbo.Epic_Tag");
            DropTable("dbo.Epic_Quest");
            DropTable("dbo.Quest_Tag");
            DropTable("dbo.User_Achievement");
            DropTable("dbo.Tag");
            DropTable("dbo.Quest_User");
            DropTable("dbo.Quest");
            DropTable("dbo.Party");
            DropTable("dbo.User");
            DropTable("dbo.Epic_User");
            DropTable("dbo.Epic");
            DropTable("dbo.Achievement");
        }
    }
}
