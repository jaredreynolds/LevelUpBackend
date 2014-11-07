using System.Collections.Generic;
using ServiceStack;

namespace LevelUp.Api.LevelUp.Heroes
{
    [Route("/heroes", Verbs = "GET")]
    public class HeroesRequest: IReturn<IEnumerable<Hero>>
    {
        
    }
}