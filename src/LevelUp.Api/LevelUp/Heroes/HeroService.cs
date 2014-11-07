using ServiceStack;

namespace LevelUp.Api.LevelUp.Heroes
{
    public class HeroService : IService
    {
        private readonly HeroesRepository _heroesRepository;

        public HeroService(HeroesRepository heroesRepository)
        {
            _heroesRepository = heroesRepository;
        }

        public object Get(HeroesRequest request)
        {
            return _heroesRepository.RetrieveAll(); 
        }
    }
}