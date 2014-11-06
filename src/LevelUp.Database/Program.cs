using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelUp.Database.Models;

namespace LevelUp.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new LevelUpContext())
            {
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
