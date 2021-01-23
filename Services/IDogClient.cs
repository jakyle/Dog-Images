using System.Threading.Tasks;

namespace WebApplication3.Services
{
    public interface IDogClient
    {
        Task<DogBreedImagesResponse> GetBreedImages(string breed = "hound");
    }

}
