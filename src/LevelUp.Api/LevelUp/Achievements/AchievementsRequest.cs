using System.Collections.Generic;
using ServiceStack;

namespace LevelUp.Api.LevelUp.Achievements
{
    [Route("/achievements", Verbs = "GET")]
    public class AchievementsRequest: IReturn<IEnumerable<Achievement>>
    {
        
    }

    [Route("/achievements/{HeroId}", Verbs = "GET")]
    public class AchievementByHeroRequest : IReturn<IEnumerable<Achievement>>
    {
         [ApiMember(
            Name = "HeroId",
            Description = "string key get the settings by",
            ParameterType = "path",
            DataType = "string",
            IsRequired = true)]
        public int HeroId { get; set; }
    }
}