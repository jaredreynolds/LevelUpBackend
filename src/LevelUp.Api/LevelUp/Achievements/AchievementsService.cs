using System.Collections.Generic;
using ServiceStack;

namespace LevelUp.Api.LevelUp.Achievements
{
    public class AchievementsService: IService
    {
        public object Get(AchievementsRequest request)
        {
            return new List<Achievement>
                {
                    new Achievement
                        {
                            AchievementId = 1,
                            Title = "Create an API!",
                            Points = 12,
                            Description = "Using Service Stack1"
                        },
                      new Achievement
                        {
                            AchievementId = 2,
                            Title = "Use an API!",
                            Points = 15,
                            Description = "Using ng resource!"
                        }  
                };
        }
    }
}