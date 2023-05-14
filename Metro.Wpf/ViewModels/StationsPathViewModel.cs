using AutoMapper;
using Metro.Services.Interfaces;
using Metro.Services.Models.DTO;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;

namespace Metro.Wpf.ViewModels
{
    /// <summary>
    /// Модель представления для отображения пути
    /// </summary>
    internal class StationsPathViewModel : BindableBase, INavigationAware
    {
        private readonly IRoutingService _routingService;
        private readonly IMapper _mapper;

        public StationsPathViewModel(IRoutingService routingService, IMapper mapper)
        {
            _routingService = routingService;
            _mapper = mapper;
        }

        /// <summary>
        /// Список станций кратчайшего пути
        /// </summary>
        private List<StationViewModel>? _stationsPath;
        public List<StationViewModel>? StationsPath 
        {
            get => _stationsPath;
            set => SetProperty(ref _stationsPath, value);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            StationViewModel? station = navigationContext.Parameters["station"] as StationViewModel;
            if (station != null) 
            {
                StationsPath = _mapper.Map<List<StationDTO>, List<StationViewModel>>(_routingService.MinTimeForAllBranch(station.Id));
            }
        }
    }
}
