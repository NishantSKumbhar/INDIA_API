namespace INDIA.Models.DTO
{
    public class StateDTOOutgoing
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double AreaInSqrKm { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string? StateImageUrl { get; set; }
        //public Guid DistrictId { get; set; }
        //public Guid LanguageId { get; set; }

        //Navigation Properties
        public DistrictDTOOutgoing District { get; set; }
        public LanguageDTO Language { get; set; }
    }
}
