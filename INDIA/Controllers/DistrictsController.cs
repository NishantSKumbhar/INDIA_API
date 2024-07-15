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
        public async Task<IActionResult> GetAllDistricts()
        {
            var districts = await this.districtRepository.GetAllDistrictsAsync();
            //var districtsDTOS = new List<DistrictDTOOutgoing>();
            //foreach(var district in districts)
            //{
            //    districtsDTOS.Add(new DistrictDTOOutgoing
            //    {
            //        Id = district.Id,
            //        Name = district.Name,
            //        Code = district.Code,
            //        AreaInSqrKm = district.AreaInSqrKm,
            //        DistrictImageUrl = district.DistrictImageUrl
            //    });
            //}

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

            //var districtDTO = new DistrictDTOOutgoing
            //{
            //    Id = districtDomainModel.Id,
            //    Name = districtDomainModel.Name,
            //    Code = districtDomainModel.Code,
            //    AreaInSqrKm = districtDomainModel.AreaInSqrKm,
            //    DistrictImageUrl = districtDomainModel.DistrictImageUrl
            //};

            var districtDTO = mapper.Map<DistrictDTOOutgoing>(districtDomainModel);
            return Ok(districtDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostDistrict([FromBody] DistrictDTOIncoming districtDTOIncoming)
        {
            //var DistrictDomainModel = new District
            //{
            //    Name = districtDTOIncoming.Name,
            //    Code = districtDTOIncoming.Code,
            //    AreaInSqrKm = districtDTOIncoming.AreaInSqrKm,
            //    DistrictImageUrl = districtDTOIncoming.DistrictImageUrl
            //};

            var DistrictDomainModel = mapper.Map<District>(districtDTOIncoming);

            var CreatedDistrict = await this.districtRepository.CreateDistrictAsync(DistrictDomainModel);

            //var DistrictDTO = new DistrictDTOOutgoing
            //{
            //    Id = CreatedDistrict.Id,
            //    Name = CreatedDistrict.Name,
            //    Code = CreatedDistrict.Code,
            //    AreaInSqrKm = CreatedDistrict.AreaInSqrKm,
            //    DistrictImageUrl = CreatedDistrict.DistrictImageUrl
            //};

            var DistrictDTO = mapper.Map<DistrictDTOOutgoing>(CreatedDistrict);
            return CreatedAtAction(nameof(GetDistrictById), new {id = DistrictDTO.Id}, DistrictDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateDistrictById([FromRoute] Guid id, [FromBody] DistrictDTOIncoming districtDTOIncoming)
        {
            //var distModel = new District
            //{
            //    Name = districtDTOIncoming.Name,
            //    Code = districtDTOIncoming.Code,
            //    AreaInSqrKm = districtDTOIncoming.AreaInSqrKm,
            //    DistrictImageUrl = districtDTOIncoming.DistrictImageUrl
            //};

            var distModel = mapper.Map<District>(districtDTOIncoming);
            var DistrictModel = await this.districtRepository.UpdateDistrictAsync(id, distModel);
            if(DistrictModel == null)
            {
                return NotFound();
            }
            
            //map
            //var DistrictDTO = new DistrictDTOOutgoing
            //{
            //    Id = DistrictModel.Id,
            //    Code = DistrictModel.Code,
            //    Name = DistrictModel.Name,
            //    AreaInSqrKm = DistrictModel.AreaInSqrKm,
            //    DistrictImageUrl = DistrictModel.DistrictImageUrl
            //};
            var DistrictDTO = mapper.Map<DistrictDTOOutgoing>(DistrictModel);
            return Ok(DistrictDTO);
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
            //var DistrictDTO = new DistrictDTOOutgoing
            //{
            //    Id = DistrictModel.Id,
            //    Code = DistrictModel.Code,
            //    Name = DistrictModel.Name,
            //    AreaInSqrKm = DistrictModel.AreaInSqrKm,
            //    DistrictImageUrl = DistrictModel.DistrictImageUrl
            //};
            var DistrictDTO = mapper.Map<DistrictDTOOutgoing>(DistrictModel);
            return Ok(DistrictDTO);
        }
    }
}
