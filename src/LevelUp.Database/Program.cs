using System;
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

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "Assert(true)", Description = "Write an automated test"},
                    new Achievement {Title = "Before it all began", Description = "Develop a BVT/DVT"},
                    new Achievement {Title = "Bugs!", Description = "Write your first bug"},
                    new Achievement {Title = "Mix and Match", Description = "Pair with a dev to finish a story"},
                    new Achievement {Title = "WOMM", Description = "Repro an issu for a dev that they can't repro on their machine"}
        
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(tagTest);
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "Yes Sensei!", Description = "Take an internal daptiv training"},
                    new Achievement {Title = "Cognoooooo", Description = "Take an internal cognos report training"},
                    new Achievement {Title = "Certifiable", Description = "Complete a certification"},
                    new Achievement {Title = "Now I am the master", Description = "Develop a training curriculum"},
                    new Achievement {Title = "Professor", Description = "Conduct an interal training for fellow employees"},
                    new Achievement {Title = "Got Git?", Description = "Completed Git training/become a Git master"},
                    new Achievement {Title = "Le Cordon Bleu", Description = "Completed Chef training"},
                    new Achievement {Title = "We built this city", Description = "Completed Team City training"},
                    new Achievement {Title = "Table Flipper", Description = "Completed SQL training"},
                    new Achievement {Title = "Oh, that’s how you manage a project,", Description = "Received a PMP certification"},
                    new Achievement {Title = "The Taskmaster", Description = "Become a certified SCRUM master or professional"},
                    new Achievement {Title = "Letterman's Jacket", Description = "Completed an ISTQB certification"},
                    new Achievement {Title = "Project Runway", Description = "Completed CSS training"},
                    new Achievement {Title = "Starbucked", Description = "Completed Javascript training"},
                    new Achievement {Title = "See Hashtag?", Description = "Completed C# training"},
                    new Achievement {Title = "Geometry Wars", Description = "Completed Angular.js training"}
        
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(tagTraining);
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "Trailblazer", Description = "Lead the way to a new technology/tool/versions of software"},
                    new Achievement {Title = "Forager", Description = "Find a new tool for Daptiv to use"},
                    new Achievement {Title = "Cooking with gas", Description = "Write a chef recipe"},
                    new Achievement {Title = "Terraformed", Description = "Improved test coverage in a previously under-tested/covered area of the code base"},
                    new Achievement {Title = "They call me Bruce", Description = "Write production queries to gather data, so Bruce doesn’t have to."}
        
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(tagTools);
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "The eighth and final rule of Fight Club", Description = "Attend a meet-up"},
                    new Achievement {Title = "The Con", Description = "Attend a conference"},
                    new Achievement {Title = "Put a bird on it", Description = "Posted an engineering tweet"},
                    new Achievement {Title = "Prose is the architecture", Description = "Posted on the engineering blog"},
                    new Achievement {Title = "Is this thing on?", Description = "Participated in a podcast"}
        
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(tagCommunity);
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "Pitch Perfect", Description = "Pitch an idea for hack day"},
                    new Achievement {Title = "Participation trophy", Description = "Participate on a hackday team"},
                    new Achievement {Title = "24(times 2)", Description = "Pitch, Participate on a team, and Demo a hackday project (all within 1 hackday period)"}
        
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(tagHackday);
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "Lend a hand", Description = "Help another team finish/ship their release"},
                    new Achievement {Title = "To infinity, and beyond!", Description = "Go above and beyond for your team or the org"},
                    new Achievement {Title = "Hey kid, I'm a computer", Description = "Solve a tech support/hardware/software issue for a teammate without going to the IT team"},
                    new Achievement {Title = "I need somebody!", Description = "Tested help changes for Scott/Documentation"},

                    new Achievement {Title = "Pay no attention to the man behind the curtain", Description = "Attend a meeting remotely"}
        
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(tagHelping);
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "What would you say you do here?", Description = "Participate in an interview loop"},
                    new Achievement {Title = "Come with me if you want to live", Description = "Refer a new hire to the company"},
                    new Achievement {Title = "Transformer", Description = "Change your career role/path within Changepoint"},
                    new Achievement {Title = "What... is the air-speed velocity of an unladen swallow", Description = "Completed an automated tech screen for management"},
                    new Achievement {Title = "You're getting good at this", Description = "Complete 5 automated tech screens for management"},

                    new Achievement {Title = "Time for your interview", Description = "Completed all automated tech screens for management"},
                    new Achievement {Title = "Look at the bones", Description = "Worked during the Christmas/End of year holiday season"}
        
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(tagRecruitment);
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "I'm a PC", Description = "Forgot your work macbook at home"},
                    new Achievement {Title = "Oops, I did it again", Description = "Checked in while the build was broken"},
                    new Achievement {Title = "You'll shoot your eye out, kid", Description = "Accidentally shoot a co-worker with a nerf dart"},
                    new Achievement {Title = "We don't need to show you no stinking badges", Description = "Forgot your badge at home"},
                    new Achievement {Title = "Steve-o noooooo", Description = "Do something embarrassing/inappropriate in front of HR without realizing it"}
        
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(tagOops);
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "Everything is Awesome!", Description = "Be nominated by someone for the trophy of awesome"},

                    new Achievement {Title = "It's an action figure, not a doll!", Description = "Win the trophy of awesome"}
        
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(tagAwesome);
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "First years", Description = "Complete 1 year at Changepoint"},
                    new Achievement {Title = "I get an extra what???", Description = "Complete 3 years at Changepoint"},
                    new Achievement {Title = "5 by 5", Description = "Complete 5 years at Changepoint"},
                    new Achievement {Title = "Where's my sabbatical?", Description = "Complete 7 years at Changepoint"},
                    new Achievement {Title = "Tenure", Description = "Complete 10 years at Changepoint"}
        
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(tagAnniversary);
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    
                    new Achievement {Title = "This is a story all about how my life got flipped turned upside down", Description = "lesh out a user story with full description, acceptance cases, tasks and tests"},
                    new Achievement {Title = "That's clearly photoshopped", Description = "Generate a mock up/wireframe for a ui change"}
        
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(tagOther);
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }
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
