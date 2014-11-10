using System.Collections.Generic;

namespace LevelUp.Api.LevelUp.Achievements
{
    public class AchievementResponseObject
    {
        public IEnumerable<Achievement> Achievements { get; set; }
    }
}