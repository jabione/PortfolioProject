using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;

namespace PortfolioProject.Utility
{
   
    public interface ICosmosConnection
    {
        Task<DocumentClient> InitializeAsync();
    }
}
