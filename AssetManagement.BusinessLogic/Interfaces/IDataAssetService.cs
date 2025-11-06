using AssetManagement.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Interfaces
{
    public interface IDataAssetService
    {
        Task<List<DataAsset>> GetAll();
        Task<DataAsset?> GetById(int id);
        Task Add(DataAsset dataAsset);
        Task Update(DataAsset dataAsset);
        Task Delete(int id);
    }
}
