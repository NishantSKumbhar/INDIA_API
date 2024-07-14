using INDIA.Data;
using INDIA.Models.Domain;
using INDIA.Models.DTO;
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

        public DistrictsController(IndiaDbContext indiaDbContext)
        {
            this.indiaDbContext = indiaDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDistricts()
        {
            var districts = await this.indiaDbContext.Districts.ToListAsync();
            var districtsDTOS = new List<DistrictDTOOutgoing>();
            foreach(var district in districts)
            {
                districtsDTOS.Add(new DistrictDTOOutgoing
                {
                    Id = district.Id,
                    Name = district.Name,
                    Code = district.Code,
                    AreaInSqrKm = district.AreaInSqrKm,
                    DistrictImageUrl = district.DistrictImageUrl
                });
            }
            return Ok(districtsDTOS);

            //var districts = new List<District>
            //{
            //    new District
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Satara",
            //        Code = "STRA",
            //        DistrictImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b2/Ajinkyatara_Fort_Satara_City.jpg/1280px-Ajinkyatara_Fort_Satara_City.jpg",
            //        AreaInSqrKm = 10484
            //    },
            //    new District
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Pune",
            //        Code = "PNQ",
            //        DistrictImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/05/Chatru_srungi_devasthan-city_view.JPG/1280px-Chatru_srungi_devasthan-city_view.JPG",
            //        AreaInSqrKm = 15643
            //    }
            //};
            //return Ok(districts);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetDistrictById([FromRoute] Guid id)
        {
            var districtDomainModel = await this.indiaDbContext.Districts.FirstOrDefaultAsync(x => x.Id == id);
            if(districtDomainModel == null)
            {
                return NotFound();
            }

            var districtDTO = new DistrictDTOOutgoing
            {
                Id = districtDomainModel.Id,
                Name = districtDomainModel.Name,
                Code = districtDomainModel.Code,
                AreaInSqrKm = districtDomainModel.AreaInSqrKm,
                DistrictImageUrl = districtDomainModel.DistrictImageUrl
            };
            return Ok(districtDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostDistrict([FromBody] DistrictDTOIncoming districtDTOIncoming)
        {
            var DistrictDomainModel = new District
            {
                Name = districtDTOIncoming.Name,
                Code = districtDTOIncoming.Code,
                AreaInSqrKm = districtDTOIncoming.AreaInSqrKm,
                DistrictImageUrl = districtDTOIncoming.DistrictImageUrl
            };

            await this.indiaDbContext.Districts.AddAsync(DistrictDomainModel);
            await this.indiaDbContext.SaveChangesAsync();
            var DistrictDTO = new DistrictDTOOutgoing
            {
                Id = DistrictDomainModel.Id,
                Name = DistrictDomainModel.Name,
                Code = DistrictDomainModel.Code,
                AreaInSqrKm = DistrictDomainModel.AreaInSqrKm,
                DistrictImageUrl = DistrictDomainModel.DistrictImageUrl
            };
            return CreatedAtAction(nameof(GetDistrictById), new {id = DistrictDTO.Id}, DistrictDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateDistrictById([FromRoute] Guid id, [FromBody] DistrictDTOIncoming districtDTOIncoming)
        {
            var DistrictModel = await this.indiaDbContext.Districts.FirstOrDefaultAsync(x => x.Id == id);
            if(DistrictModel == null)
            {
                return NotFound();
            }
            DistrictModel.Code = districtDTOIncoming.Code;
            DistrictModel.Name = districtDTOIncoming.Name;
            DistrictModel.AreaInSqrKm = districtDTOIncoming.AreaInSqrKm;
            DistrictModel.DistrictImageUrl = districtDTOIncoming.DistrictImageUrl;

            await this.indiaDbContext.SaveChangesAsync();
            //map
            var DistrictDTO = new DistrictDTOOutgoing
            {
                Id = DistrictModel.Id,
                Code = DistrictModel.Code,
                Name = DistrictModel.Name,
                AreaInSqrKm = DistrictModel.AreaInSqrKm,
                DistrictImageUrl = DistrictModel.DistrictImageUrl
            };
            return Ok(DistrictDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteDistrictById([FromRoute] Guid id)
        {
            var DistrictModel = await indiaDbContext.Districts.FirstOrDefaultAsync(x => x.Id == id);
            if(DistrictModel == null)
            {
                return NotFound(id);
            }

            this.indiaDbContext.Districts.Remove(DistrictModel);
            await this.indiaDbContext.SaveChangesAsync();
            var DistrictDTO = new DistrictDTOOutgoing
            {
                Id = DistrictModel.Id,
                Code = DistrictModel.Code,
                Name = DistrictModel.Name,
                AreaInSqrKm = DistrictModel.AreaInSqrKm,
                DistrictImageUrl = DistrictModel.DistrictImageUrl
            };
            return Ok(DistrictDTO);
        }
    }
}
