using AutoMapper;
using INDIA.Models.Domain;
using INDIA.Models.DTO;

namespace INDIA.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<District, DistrictDTOOutgoing>().ReverseMap();
            CreateMap<DistrictDTOIncoming, District>().ReverseMap();
            CreateMap<State, StateDTOOutgoing>().ReverseMap();
            CreateMap<StateDTOIncomming,State>().ReverseMap();
            CreateMap<Language, LanguageDTO>().ReverseMap(); 
        }
    }
}
