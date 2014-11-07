using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
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

                        db.Achievements.Add(new Achievement {Title = "Write some code", Type = "Personal", Points = 1});
                        db.SaveChanges();
                    }
                }

                Console.WriteLine("Creation/migration complete!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
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

        private enum Mode
        {
            Create,
            Migrate,
            Skip
        }
    }
}
