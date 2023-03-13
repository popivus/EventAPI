using EventAPI.Services.Interfaces;

namespace EventAPI.Services
{
    public class ImageService : IImageService
    {
        public bool ImageExists(Guid idImage)
        {
            //Логика проверки существования
            return true;
        }
    }
}
