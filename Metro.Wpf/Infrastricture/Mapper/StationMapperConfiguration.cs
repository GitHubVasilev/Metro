using AutoMapper;
using Metro.Services.Models.DTO;
using Metro.Wpf.ViewModels;

namespace Metro.Wpf.Infrastricture.Mapper
{
    internal class StationMapperConfiguration : Profile
    {
        public StationMapperConfiguration() 
        {
            CreateMap<StationDTO, StationViewModel>();
            CreateMap<StationViewModel, StationDTO>();
        }
    }
}
