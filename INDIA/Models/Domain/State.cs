namespace INDIA.Models.Domain
{
    public class State
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double AreaInSqrKm { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string? StateImageUrl { get; set; }
        public Guid DistrictId { get; set; }
        public Guid LanguageId { get; set; }

        // Navigation Properties
        public District District { get; set; }
        public Language Language { get; set; }

    }
}
