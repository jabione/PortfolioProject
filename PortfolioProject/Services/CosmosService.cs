using Microsoft.Azure.Documents.Client;
using PortfolioProject.IServices;

namespace PortfolioProject.Services
{
    /// <summary>
    /// Cosmos Service
    /// </summary>
    public class CosmosService : ICosmosService<CosmosService>
    {
        //Client CosmosDB
        private readonly DocumentClient _client;
        //Connection parameters
        private readonly string _accountUrl;
        private readonly string _primarykey;
        private readonly string _databaseName;
        private readonly string _containerName;

        /// <summary>
        /// Contructor with parameter
        /// </summary>
        /// <param name="config">Configuration parameter</param>
        public CosmosService(IConfiguration config)
        {
            //Connection values
            _accountUrl = config.GetValue<string>("CosmosDb:Account");
            _primarykey = config.GetValue<string>("CosmosDb:Key");
            _databaseName = config.GetValue<string>("CosmosDb:DatabaseName");
            _containerName = config.GetValue<string>("CosmosDb:ContainerName");

            // Instance New Client DB
            _client = new DocumentClient(new Uri(_accountUrl), _primarykey);
        }

        /// <summary>
        /// Get Metadata
        /// </summary>
        /// <returns>Dynamic object of Metadata</returns>
        public async Task<dynamic> GetData()
        {
            try
            {
                //Geat all data from Metadata
               return await _client.ReadDocumentFeedAsync(UriFactory.CreateDocumentCollectionUri(_databaseName, _containerName));
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
