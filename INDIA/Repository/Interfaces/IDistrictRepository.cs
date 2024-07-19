using INDIA.Models.Domain;

namespace INDIA.Repository.Interfaces
{
    public interface IDistrictRepository
    {
        Task<List<District>> GetAllDistrictsAsync(string? filterOn = null, 
            string? filterQuery = null,
            string? sortBy=null,
            bool isAscending=true,
            int pageNumber = 1,
            int pageSize = 1000);
        Task<District?> GetDistrictByIdAsync(Guid id);
        Task<District> CreateDistrictAsync(District district);
        Task<District?> UpdateDistrictAsync(Guid id, District district);
        Task<District?> DeleteDistrictByIdAsync(Guid id);
    }
}
