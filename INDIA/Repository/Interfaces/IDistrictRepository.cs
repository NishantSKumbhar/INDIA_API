using INDIA.Models.Domain;

namespace INDIA.Repository.Interfaces
{
    public interface IDistrictRepository
    {
        Task<List<District>> GetAllDistrictsAsync();
        Task<District?> GetDistrictByIdAsync(Guid id);
        Task<District> CreateDistrictAsync(District district);
        Task<District?> UpdateDistrictAsync(Guid id, District district);
        Task<District?> DeleteDistrictByIdAsync(Guid id);
    }
}
