using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TrainingPortal.Entities;
using TrainingPortal.WebPL.Interfaces;

namespace TrainingPortal.WebPL.Services
{
    public class AzureService : IAzureService
    {
        private readonly AzureSettings azureSettings;

        public AzureService(IOptions<AzureSettings> azureSettings)
        {
            this.azureSettings = azureSettings.Value;
        }

        public async Task<List<string>> GetImagesUrls()
        {
            List<string> imageUrls = new List<string>();
            BlobServiceClient blobServiceClient = new BlobServiceClient(azureSettings.ConnectionString);
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(azureSettings.ImageContainerName);

            if (blobContainerClient.Exists())
            {
                foreach (BlobItem blobitem in blobContainerClient.GetBlobs())
                {
                    imageUrls.Add(blobContainerClient.Uri + "/" + blobitem.Name);
                }
            }

            return await Task.FromResult(imageUrls);
        }

        public async Task<bool> UploadFileToStorage(Stream fileStream, string filename)
        {
            BlobClient blobClient = new BlobClient(azureSettings.ConnectionString, azureSettings.ImageContainerName, filename);
            await blobClient.UploadAsync(fileStream);

            return await Task.FromResult(true);
        }
    }
}