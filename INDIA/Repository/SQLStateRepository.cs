using INDIA.Data;
using INDIA.Models.Domain;
using INDIA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace INDIA.Repository
{
    public class SQLStateRepository : IStateRepository
    {
        private readonly IndiaDbContext indiaDbContext;

        public SQLStateRepository(IndiaDbContext indiaDbContext)
        {
            this.indiaDbContext = indiaDbContext;
        }
        public async Task<State> CreateStateAsync(State state)
        {
            await this.indiaDbContext.States.AddAsync(state);
            await this.indiaDbContext.SaveChangesAsync();
            return state;
        }

        public async Task<State?> DeleteStateByIdAsync(Guid id)
        {
            var state = await this.indiaDbContext.States.FirstOrDefaultAsync(x => x.Id == id);
            if (state == null)
            {
                return null;
            }
            this.indiaDbContext.States.Remove(state);
            await this.indiaDbContext.SaveChangesAsync();
            return state;
        }

        public async Task<List<State>> GetAllStatesAsync()
        {
            return await this.indiaDbContext.States.Include("District").Include("Language").ToListAsync();
        }

        public async Task<State?> GetStateByIdAsync(Guid id)
        {
            var state = await this.indiaDbContext.States.Include("District").Include("Language").FirstOrDefaultAsync(x => x.Id == id);
           
            return state;
        }

        public async Task<State?> UpdateStateAsync(Guid id, State state)
        {
            var newstate = await this.indiaDbContext.States.FirstOrDefaultAsync(x => x.Id == id);
            if (newstate == null)
            {
                return null;
            }
            newstate.Name = state.Name;
            newstate.Code = state.Code;
            newstate.Description = state.Description;
            newstate.AreaInSqrKm = state.AreaInSqrKm;
            newstate.StateImageUrl = state.StateImageUrl;
            newstate.DistrictId = state.DistrictId;
            newstate.LanguageId = state.LanguageId;

            await this.indiaDbContext.SaveChangesAsync();
            return newstate;
        }
    }
}
