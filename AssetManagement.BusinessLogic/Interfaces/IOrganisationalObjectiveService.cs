using AssetManagement.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagement.BusinessLogic.Interfaces
{
    public interface IOrganisationalObjectiveService
    {
        Task<List<OrganisationalObjective>> GetAll();
        Task<OrganisationalObjective?> GetById(int id);
        Task Add(OrganisationalObjective objective);
        Task Update(OrganisationalObjective objective);
        Task Delete(int id);
    }
}
