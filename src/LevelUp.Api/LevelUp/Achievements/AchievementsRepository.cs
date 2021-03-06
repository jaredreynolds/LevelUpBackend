﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LevelUp.Database.Models;

namespace LevelUp.Api.LevelUp.Achievements
{
    public class AchievementsRepository
    {
        private readonly LevelUpContext _levelUpContext;

        public AchievementsRepository(LevelUpContext levelUpContext)
        {
            _levelUpContext = levelUpContext;
        }

        public IEnumerable<Achievement> RetrieveAll()
        {
            DbSet<Database.Models.Achievement> dbSet = _levelUpContext.Achievements;
            if (dbSet == null)
            {
                return Enumerable.Empty<Achievement>();
            }

            return dbSet.Select(MapAchievement);
        }

        public IEnumerable<Achievement> RetrieveByHero(int heroId)
        {
            return _levelUpContext
                .Heroes
                .First(h => h.HeroId == heroId)
                .Achievements.Select(MapAchievement);
        }

        private static Achievement MapAchievement(Database.Models.Achievement a)
        {
            return new Achievement
            {
                AchievementId = a.AchievementId,
                Description = a.Description,
                Image = a.Image,
                ImageUrl = a.ImageUrl,
                Points = a.Points,
                QRCodeText = a.QRCodeText,
                Title = a.Title,
                Type = a.Type
            };
        }
    }
}