using System.ComponentModel.DataAnnotations;

namespace INDIA.Models.DTO
{
    public class DistrictDTOIncoming
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(3,ErrorMessage ="Code has to be minimum 3 Character.")]
        public string Code { get; set; }
        [Required]
        public double AreaInSqrKm { get; set; }
        public string? DistrictImageUrl { get; set; }
    }
}
