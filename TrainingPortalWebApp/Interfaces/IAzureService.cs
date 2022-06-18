using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TrainingPortal.WebPL.Interfaces
{
    public interface IAzureService
    {
        public Task<bool> UploadFileToStorage(Stream fileStream, string filename);

        public Task<List<string>> GetImagesUrls();
    }
}