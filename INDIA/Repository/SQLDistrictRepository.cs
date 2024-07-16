using INDIA.Data;
using INDIA.Models.Domain;
using INDIA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace INDIA.Repository
{
    public class SQLDistrictRepository:IDistrictRepository
    {
        private readonly IndiaDbContext indiaDbContext;

        public SQLDistrictRepository(IndiaDbContext indiaDbContext)
        {
            this.indiaDbContext = indiaDbContext;
        }

        public async Task<District> CreateDistrictAsync(District district)
        {
            await this.indiaDbContext.Districts.AddAsync(district);
            await this.indiaDbContext.SaveChangesAsync();
            return district;
        }

        public async Task<District?> DeleteDistrictByIdAsync(Guid id)
        {
            var district = await this.indiaDbContext.Districts.FirstOrDefaultAsync(x => x.Id == id);
            if(district == null)
            {
                return null;
            }
            this.indiaDbContext.Districts.Remove(district);
            await this.indiaDbContext.SaveChangesAsync();
            return district;
        }

        public async Task<List<District>> GetAllDistrictsAsync(string? filterOn = null, string? filterQuery=null)
        {
            var districts = this.indiaDbContext.Districts.AsQueryable();

            // Filtering
            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    districts = districts.Where(x => x.Name.Contains(filterQuery));
                }
            }
            return await districts.ToListAsync();
        }

        public async Task<District?> GetDistrictByIdAsync(Guid id)
        {
            return await this.indiaDbContext.Districts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<District?> UpdateDistrictAsync(Guid id, District district)
        {
            var dist = await this.indiaDbContext.Districts.FirstOrDefaultAsync(x => x.Id == id);
            if(dist == null)
            {
                return null;
            }
            //dist.Id = district.Id;
            dist.Name = district.Name;
            dist.Code = district.Code;
            dist.AreaInSqrKm = district.AreaInSqrKm;
            dist.DistrictImageUrl = district.DistrictImageUrl;

            await this.indiaDbContext.SaveChangesAsync();
            return dist;
        }
    }
}
