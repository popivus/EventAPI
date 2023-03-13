using EventAPI.Services.Interfaces;

namespace EventAPI.Services
{
    public class SpaceService : ISpaceService
    {
        public bool SpaceExists(Guid idSpace)
        {
            //Логика проверки существования
            return true;
        }
    }
}
