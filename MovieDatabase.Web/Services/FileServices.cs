using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace MovieDatabase.Web.Services
{
    public class FileService : IFileService
    {
        public void Save(IFormFile file, string path)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            using var fileStream = new FileStream(path, FileMode.Create);
            file.CopyTo(fileStream);
        }

        public void Delete(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
