namespace PortfolioProject.IServices
{
    public interface ICosmosService<T>
    {
        Task<dynamic> GetData();
    }
}
