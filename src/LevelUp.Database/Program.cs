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
            foreach (var tag in new[]
                {
                    "Dev",
                    "Test",
                    "Training",
                    "Tools/Tech",
                    "Hackday",
                    "Community Involvement",
                    "Helping Others",
                    "Recruitment",
                    "Oops",
                    "Awesome",
                    "Anniversary",
                    "Other",
                    "Team",
                    "Team Building",
                    "Civic",
                    "Benefits",
                    "Organization"
                })
            {
                db.Tags.AddOrUpdate(new Tag {Name = tag});
            }

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
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Dev"));
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
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Test"));
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
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Training"));
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
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Tools/Tech"));
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
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Community Involvement"));
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
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Hackday"));
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
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Helping Others"));
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
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Recruitment"));
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
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Oops"));
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "Everything is Awesome!", Description = "Be nominated by someone for the trophy of awesome"},

                    new Achievement {Title = "It's an action figure, not a doll!", Description = "Win the trophy of awesome"}
        
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Awesome"));
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
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Anniversary"));
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    
                    new Achievement {Title = "This is a story all about how my life got flipped turned upside down", Description = "lesh out a user story with full description, acceptance cases, tasks and tests"},
                    new Achievement {Title = "That's clearly photoshopped", Description = "Generate a mock up/wireframe for a ui change"}
        
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Other"));
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }


            foreach (var achievement in new[]
                {
                    new Achievement {Title = "Maple leaf of Absence", Description = "Physically attend a meeting in Seattle and Toronto within 24 hours"},
                    new Achievement {Title = "Around the World in 80 Days", Description = "Attend a meeting on 3 continents within 80 days."},
                    new Achievement {Title = "Almost Infinity Miles Per Gallon", Description = "ride your bike to work."}
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Organization"));
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "The 1%", Description = "Participate in the 401(k)"},
                    new Achievement {Title = "I wouldn't say I was missing it Bob", Description = "End your year with no Vacation or PTO left"},
                    new Achievement {Title = "Perfect Attendance", Description = "Take NO vacation, PTO, or sick leave in a year"},
                    new Achievement {Title = "Outbroken", Description = "You got your flu shot"}
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Benefits"));
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }

            foreach (var achievement in new[]
                {
                    new Achievement {Title = "The Beatings will Continue", Description = "suggest a morale event"},
                    new Achievement {Title = "Until Morale Improves", Description = "Attend a Morale Event"},
                    new Achievement {Title = "I am Invincible", Description = "win a morale event or team building competition"},
                    new Achievement {Title = "Boss Monster", Description = "Defeat a VP in a morale or company event competition"},
                    new Achievement {Title = "Mini-Boss", Description = "Defeat a manager in a morale or company event competition"},
                    new Achievement {Title = "No Beer Steve", Description = "Keep Steve Sober at a morale event"},
                    new Achievement {Title = "3 Beer Steve", Description = "A quire an extra drink ticket at a morale event"},
                    new Achievement {Title = "Teetotaler", Description = "go one year without drinking at a morale event"}
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Team Building"));
                db.Achievements.AddOrUpdate(a => a.Title, achievement);

            }


            foreach (var achievement in new[]
                {
                    new Achievement {Title = "Vampire Victim", Description = "Donate Blood"},
                    new Achievement {Title = "Civically Minded", Description = "Voted"},
                    new Achievement {Title = "You want me to work for free", Description = "Volunteer"},
                    new Achievement {Title = "I'd like to teach the world to sing", Description = "Entire Team or Engineering Org volunteers together"}
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Civic"));
                db.Achievements.AddOrUpdate(a => a.Title, achievement);
            }
            foreach (var achievement in new[]
                {
                    new Achievement {Title = "That's Quality", Description = "No Hotfixes for two releases"},
                    new Achievement {Title = "That's it, thank you, we're done", Description = "Complete a Planned release on the originally estimated time"},
                    new Achievement {Title = "I feel the need, the need for speed", Description = "beat your average velocity for an iteration (or 2, or a release)"},
                    new Achievement {Title = "We can rebuild it, make it stronger", Description = "form a new team"},
                    new Achievement {Title = "Fib…..onacci", Description = "horribly underpoint a story"},
                    new Achievement {Title = "Drano", Description = "no stories blocked during an iteration"},
                })
            {
                achievement.Type = "Personal";
                achievement.Tags.Add(db.Tags.First(t => t.Name == "Team"));
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
