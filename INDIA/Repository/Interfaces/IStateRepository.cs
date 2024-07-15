using INDIA.Models.Domain;

namespace INDIA.Repository.Interfaces
{
    public interface IStateRepository
    {
        Task<List<State>> GetAllStatesAsync();
        Task<State?> GetStateByIdAsync(Guid id);
        Task<State> CreateStateAsync(State state);
        Task<State?> UpdateStateAsync(Guid id, State state);
        Task<State?> DeleteStateByIdAsync(Guid id);
    }
}
