using AutoMapper;
using INDIA.Data;
using INDIA.Models.Domain;
using INDIA.Models.DTO;
using INDIA.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INDIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IndiaDbContext indiaDbContext;
        private readonly IDistrictRepository districtRepository;
        private readonly IMapper mapper;

        public DistrictsController(IndiaDbContext indiaDbContext, 
            IDistrictRepository districtRepository,
            IMapper mapper)
        {
            this.indiaDbContext = indiaDbContext;
            this.districtRepository = districtRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDistricts([FromQuery] string? filterOn, 
            [FromQuery] string? filterQuery)
        {
            var districts = await this.districtRepository.GetAllDistrictsAsync();
            var districtsDTOS = mapper.Map<List<DistrictDTOOutgoing>>(districts);
            return Ok(districtsDTOS);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetDistrictById([FromRoute] Guid id)
        {
            var districtDomainModel = await this.districtRepository.GetDistrictByIdAsync(id);
            if(districtDomainModel == null)
            {
                return NotFound();
            }

            var districtDTO = mapper.Map<DistrictDTOOutgoing>(districtDomainModel);
            return Ok(districtDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostDistrict([FromBody] DistrictDTOIncoming districtDTOIncoming)
        {
            if (ModelState.IsValid)
            {
                var DistrictDomainModel = mapper.Map<District>(districtDTOIncoming);

                var CreatedDistrict = await this.districtRepository.CreateDistrictAsync(DistrictDomainModel);

                var DistrictDTO = mapper.Map<DistrictDTOOutgoing>(CreatedDistrict);
                return CreatedAtAction(nameof(GetDistrictById), new { id = DistrictDTO.Id }, DistrictDTO);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateDistrictById([FromRoute] Guid id, [FromBody] DistrictDTOIncoming districtDTOIncoming)
        {
            if (ModelState.IsValid)
            {
                var distModel = mapper.Map<District>(districtDTOIncoming);
                var DistrictModel = await this.districtRepository.UpdateDistrictAsync(id, distModel);
                if (DistrictModel == null)
                {
                    return NotFound();
                }

                var DistrictDTO = mapper.Map<DistrictDTOOutgoing>(DistrictModel);
                return Ok(DistrictDTO);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteDistrictById([FromRoute] Guid id)
        {
            var DistrictModel = await this.districtRepository.DeleteDistrictByIdAsync(id);
            if(DistrictModel == null)
            {
                return NotFound(id);
            }
           
            var DistrictDTO = mapper.Map<DistrictDTOOutgoing>(DistrictModel);
            return Ok(DistrictDTO);
        }
    }
}
