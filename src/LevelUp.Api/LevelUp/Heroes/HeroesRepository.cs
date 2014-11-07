using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LevelUp.Database.Models;

namespace LevelUp.Api.LevelUp.Heroes
{
    public class HeroesRepository
    {
        private readonly LevelUpContext _levelUpContext;

        public HeroesRepository(LevelUpContext levelUpContext)
        {
            _levelUpContext = levelUpContext;
        }

        public IEnumerable<Hero> RetrieveAll()
        {
            DbSet<Database.Models.Hero> dbSet = _levelUpContext.Heroes;
            if (dbSet == null)
            {
                return Enumerable.Empty<Hero>();
            }

            return dbSet.Select(h =>
                    new Hero
                        {
                            HeroId = h.HeroId,
                            GravatarUrl = h.GravatarUrl,
                            Name = h.Name
                        }
                );
        }
    }
}