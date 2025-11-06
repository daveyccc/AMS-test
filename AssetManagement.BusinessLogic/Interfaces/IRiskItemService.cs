using AssetManagement.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Interfaces
{
    public interface IRiskItemService
    {
        Task<List<RiskItem>> GetAll();
        Task<RiskItem?> GetById(int id);
        Task Add(RiskItem riskItem);
        Task Update(RiskItem riskItem);
        Task Delete(int id);
    }
}
