using PortfolioProject.Models;

namespace PortfolioProject.IServices
{
    public interface IBlobService<T>
    {
        Task<BlobInfo> GetBlobAsync(string name);

    }
}
