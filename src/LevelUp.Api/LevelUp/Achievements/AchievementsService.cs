using ServiceStack;

namespace LevelUp.Api.LevelUp.Achievements
{
    public class AchievementsService : IService
    {
        private readonly AchievementsRepository _achievementsRepository;

        public AchievementsService(AchievementsRepository achievementsRepository)
        {
            _achievementsRepository = achievementsRepository;
        }

        public object Get(AchievementsRequest request)
        {
            return _achievementsRepository.RetrieveAll(); 
        }
    }
}