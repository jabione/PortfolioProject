using Azure.Storage.Blobs;
using PortfolioProject.IServices;
using PortfolioProject.Models;

namespace PortfolioProject.Services
{
    /// <summary>
    /// Blob Service 
    /// </summary>
    public class BlobService : IBlobService<BlobService>
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="blobServiceClient">Blob Service</param>
        /// <param name="config">Configuration</param>
        public BlobService(BlobServiceClient blobServiceClient, IConfiguration config)
        {
            _blobServiceClient = blobServiceClient;
            _containerName = config.GetValue<string>("BlobStorage:ContainerName");
        }

        /// <summary>
        /// Get Blob by Filename
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>BlobInfo object</returns>
        public async Task<BlobInfo> GetBlobAsync(string filename)
        {
            // Get container object client
            var container = _blobServiceClient.GetBlobContainerClient(_containerName);
            // Get Blob object client
            var file = container.GetBlobClient(filename);
            // Download the blob oject
            var blobDownload = await file.DownloadAsync();

            return new BlobInfo(blobDownload.Value.Content, blobDownload.Value.ContentType);
        }


    }
}
