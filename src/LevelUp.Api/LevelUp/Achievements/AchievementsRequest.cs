using System.Collections.Generic;
using ServiceStack;

namespace LevelUp.Api.LevelUp.Achievements
{
    [Route("/achievements", Verbs = "GET")]
    public class AchievementsRequest: IReturn<IList<Achievement>>
    {
        
    }
}