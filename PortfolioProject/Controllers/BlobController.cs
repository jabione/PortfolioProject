using Microsoft.AspNetCore.Mvc;
using PortfolioProject.IServices;
using PortfolioProject.Services;

namespace PortfolioProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlobController : ControllerBase
    {
        //private readonly ILogger<BlobController> _logger;
        private readonly IBlobService<BlobService> _blobService;
        private readonly ICosmosService<CosmosService> _cosmosService;

        /// <summary>
        /// Contructor with parameter
        /// </summary>
        /// <param name="blobService">Blob storage Service</param>
        /// <param name="cosmosService">Cosmos DB Service</param>
        public BlobController(IBlobService<BlobService> blobService, ICosmosService<CosmosService> cosmosService)
        {
            _blobService = blobService;
            _cosmosService = cosmosService;
        }

        /// <summary>
        /// Get Photos from path
        /// </summary>
        /// <param name="foldername">Folder Name</param>
        /// <param name="filename">File name</param>
        /// <returns>File</returns>
        [Route("[action]/{foldername}/{filename}")]
        [HttpGet]
        public async Task<IActionResult> GetPhotosAsync(string foldername, string filename)
        {
            //"photos/photography-1.jpg"
            var data = await _blobService.GetBlobAsync(foldername + "/" + filename);

            return File(data.Content, data.ContentType);

        }

        /// <summary>
        /// Get Projects photos from path
        /// </summary>
        /// <param name="foldername">Folder Name</param>
        /// <param name="filename">File name</param>
        /// <returns>File</returns>
        [Route("[action]/{foldername}/{filename}")]
        [HttpGet]
        public async Task<IActionResult> GetProjectAsync(string foldername, string filename)
        {
            var data = await _blobService.GetBlobAsync(foldername + "/" + filename);
            return File(data.Content, data.ContentType);

        }

        /// <summary>
        /// Get Metada from CosmosDB
        /// </summary>
        /// <returns>Metadata</returns>
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetDataAsync()
        {
            var result = await _cosmosService.GetData();
            return Ok(result);
        }

    }
}
