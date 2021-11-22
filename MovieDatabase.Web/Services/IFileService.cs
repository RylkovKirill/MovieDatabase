using Microsoft.AspNetCore.Http;

namespace MovieDatabase.Web.Services
{
    public interface IFileService
    {
        void Save(IFormFile file, string path);
        void Delete(string path);
    }
}
