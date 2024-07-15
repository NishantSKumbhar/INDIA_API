using AutoMapper;
using INDIA.Models.Domain;
using INDIA.Models.DTO;
using INDIA.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INDIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStateRepository stateRepository;
        private readonly IMapper mapper;

        public StatesController(IStateRepository stateRepository,IMapper mapper)
        {
            this.stateRepository = stateRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStates()
        {
            var states = await this.stateRepository.GetAllStatesAsync();

            var StatesDTO = mapper.Map<List<StateDTOOutgoing>>(states);
            return Ok(StatesDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetStateById([FromRoute] Guid id)
        {
            var state = await this.stateRepository.GetStateByIdAsync(id);
            if(state == null)
            {
                return NotFound();
            }
            var StateDTO = mapper.Map<StateDTOOutgoing>(state);
            return Ok(StateDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostState([FromBody] StateDTOIncomming stateDTOIncomming)
        {
            var state = mapper.Map<State>(stateDTOIncomming);
            var upstate = await this.stateRepository.CreateStateAsync(state);
            
            var StateDTO = mapper.Map<StateDTOOutgoing>(upstate);
            return CreatedAtAction(nameof(GetStateById), new { StateDTO.Id }, StateDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateState([FromRoute] Guid id, [FromBody] StateDTOIncomming stateDTOIncomming)
        {
            var stateModel = mapper.Map<State>(stateDTOIncomming);
            var updatedState = await this.stateRepository.UpdateStateAsync(id, stateModel);
            if (updatedState == null)
            {
                return NotFound();
            }
            var StateDTO = mapper.Map<StateDTOOutgoing>(updatedState);
            return Ok(StateDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteStateById([FromRoute] Guid id)
        {
            var state = await this.stateRepository.DeleteStateByIdAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            var StateDTO = mapper.Map<StateDTOOutgoing>(state);
            return Ok(StateDTO);
        }
    }
}
