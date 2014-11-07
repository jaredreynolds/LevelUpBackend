using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using LevelUp.Database.Models;
using Configuration = LevelUp.Database.Migrations.Configuration;

namespace LevelUp.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<LevelUpContext, Configuration>());

                using (var db = new LevelUpContext())
                {
                    var mode = GetMode(db);

                    if (mode != Mode.Skip)
                    {
                        db.Database.CreateIfNotExists();

                        SeedData(db);

                        db.SaveChanges();
                    }
                }

                Console.WriteLine("Creation/migration complete!");
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
            }
        }

        private static void SeedData(LevelUpContext db)
        {
            var tagDev = new Tag { Name = "Dev" };
            var tagTest = new Tag { Name = "Test" };
            var tagTraining = new Tag {Name = "Training"};
            var tagTools = new Tag {Name = "Tools/Tech"};
            var tagHackday = new Tag {Name = "Hackday"};
            var tagCommunity = new Tag {Name = "Community Involvement"};
            var tagHelping = new Tag {Name = "Helping Others"};
            var tagRecruitment = new Tag {Name = "Recruitment"};
            var tagOops = new Tag {Name = "Oops"};
            var tagAwesome = new Tag {Name = "Awesome"};
            var tagAnniversary = new Tag {Name = "Anniversary"};
            var tagOther = new Tag {Name = "Other"};
            var tagTeam = new Tag {Name = "Team"};
            var tagTeamBuilding = new Tag {Name = "Team Building"};
            var tagCivic = new Tag {Name = "Civic"};
            var tagBenefits = new Tag {Name = "Benefits"};
            var tagOrganization = new Tag {Name = "Organization"};
            db.Tags.AddOrUpdate(t => t.Name,
                tagDev,
                tagTest,
                tagTraining,
                tagTools,
                tagHackday,
                tagCommunity,
                tagHelping,
                tagRecruitment,
                tagOops,
                tagAwesome,
                tagAnniversary,
                tagOther,
                tagTeam,
                tagTeamBuilding,
                tagCivic,
                tagBenefits,
                tagOrganization
            );

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "Pull!", Description = "Complete first pull request."},
                    new Achievement {Title = "2 Thumbs Up", Description = "Complete x number of code reviews within 24 hours."},
                    new Achievement {Title = "Assert(true)", Description = "Write an automated test."},
                    new Achievement {Title = "Next Topic", Description = "Present a dev meeting topic."},
                    new Achievement {Title = "A Pair of Pears", Description = "Pair on every story in an iteration/release."},
                    new Achievement {Title = "Bug Bashed", Description = "Participate in a bug bash and log a bug!"}
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(tagDev);
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            SeedHeroes(db);
        }

        private static void SeedHeroes(LevelUpContext db)
        {
            db.Heroes.AddOrUpdate(
                h => h.Name,
                new Hero { Name = "Aaron Schmitt" },
                new Hero { Name = "Brian Lenihan" },
                new Hero { Name = "Cliff Burger" },
                new Hero { Name = "Jared Reynolds" },
                new Hero { Name = "Jon Schnur" },
                new Hero { Name = "Stephen Fowler" }
                );
        }

        private static Mode GetMode(LevelUpContext db)
        {
            if (db.Database.Exists())
            {
                Console.WriteLine("Do you want to migrate your LevelUp database to the latest version? [y/N] ");
                if (Console.ReadKey(true).KeyChar.ToString(CultureInfo.InvariantCulture).ToLower() == "y")
                {
                    Console.WriteLine("Migrating...");
                    return Mode.Migrate;
                }
                return Mode.Skip;
            }

            Console.WriteLine("Creating database...");

            return Mode.Create;
        }

        private static void HandleException(Exception ex)
        {
            Console.WriteLine(ex);

            var validationException = ex as DbEntityValidationException;
            if (validationException == null) return;

            foreach (var error in validationException.EntityValidationErrors.SelectMany(entity => entity.ValidationErrors))
            {
                Console.WriteLine("{0}: {1}", error.PropertyName, error.ErrorMessage);
            }
        }

        private enum Mode
        {
            Create,
            Migrate,
            Skip
        }
    }
}
