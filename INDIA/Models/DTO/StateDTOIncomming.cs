using System.ComponentModel.DataAnnotations;

namespace INDIA.Models.DTO
{
    public class StateDTOIncomming
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double AreaInSqrKm { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        
        public string? StateImageUrl { get; set; }
        [Required]
        public Guid DistrictId { get; set; }
        [Required]
        public Guid LanguageId { get; set; }
    }
}
