using AutoMapper;
using Metro.Services.Models.DTO;
using Metro.Wpf.ViewModels;

namespace Metro.Wpf.Infrastricture.Mapper
{
    internal class BranchMapperConfiguration : Profile
    {
        public BranchMapperConfiguration() 
        {
            CreateMap<BranchDTO, BranchViewModel>();
            CreateMap<BranchViewModel, BranchDTO>();
        }
    }
}
