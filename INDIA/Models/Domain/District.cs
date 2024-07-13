namespace INDIA.Models.Domain
{
    public class District
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double AreaInSqrKm { get; set; }
        public string? DistrictImageUrl { get; set; }
    }
}
