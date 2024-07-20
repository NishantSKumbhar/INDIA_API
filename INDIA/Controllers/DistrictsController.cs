using AutoMapper;
using INDIA.Data;
using INDIA.Models.Domain;
using INDIA.Models.DTO;
using INDIA.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INDIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] // now any method inside this controller can not be accessed publicaly i.e. has to be accessed by an authenticated person,
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

        // /api/District/?filterOn=Name&filterQuery=Sangali&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAllDistricts([FromQuery] string? filterOn, 
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 1000)
        {
            var districts = await this.districtRepository.GetAllDistrictsAsync(filterOn,filterQuery,sortBy,isAscending ?? true,pageNumber,pageSize);
            var districtsDTOS = mapper.Map<List<DistrictDTOOutgoing>>(districts);
            return Ok(districtsDTOS);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
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
        [Authorize(Roles = "Writer")]
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
        [Authorize(Roles = "Writer")]
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
        [Authorize(Roles = "Writer")]
        //  [Authorize(Roles = "Writer,Reader")]
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
