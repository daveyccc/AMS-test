using AssetManagement.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Services
{
    public interface IAssetService
    {
        Task<List<Asset>> GetAssets();
        Task<Asset> GetAsset(int id);
        Task AddAsset(Asset asset);
        Task UpdateAsset(Asset asset);
        Task DeleteAsset(int id);
    }
}
