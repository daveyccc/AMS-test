using AssetManagement.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Interfaces
{
    public interface IInformationSystemService
    {
        Task<List<InformationSystem>> GetAll();
        Task<InformationSystem?> GetById(int id);
        Task Add(InformationSystem informationSystem);
        Task Update(InformationSystem informationSystem);
        Task Delete(int id);
    }
}
