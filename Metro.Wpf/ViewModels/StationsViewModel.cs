using AutoMapper;
using Metro.Services.Interfaces;
using Metro.Services.Models.DTO;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;

namespace Metro.Wpf.ViewModels
{
    /// <summary>
    /// Модель представления для отображения списка станций
    /// </summary>
    internal class StationsViewModel : BindableBase
    {
        private readonly IStationsService _stationServices;
        private readonly IMapper _mapper;   
        private IRegionManager _regionManager;

        public StationsViewModel(IStationsService stationServices, IMapper mapper, IRegionManager regionManager)
        {
            _stationServices = stationServices;
            _mapper = mapper;
            _stations = _mapper.Map<IEnumerable<StationDTO>, IEnumerable<StationViewModel>>(_stationServices.GetStations());
            _regionManager = regionManager;

        }

        private IEnumerable<StationViewModel> _stations;
        /// <summary>
        /// Список станций
        /// </summary>
        public IEnumerable<StationViewModel> Stations 
        {
            get => _stations;
            set => SetProperty(ref _stations, value);
        }
        
        /// <summary>
        /// Выбранная станция
        /// </summary>
        private StationViewModel _selectedStation;

        public StationViewModel SelectedStation 
        {
            get => _selectedStation;
            set 
            {
                SetProperty(ref _selectedStation, value);
                NavigationParameters parametrs = new NavigationParameters();
                parametrs.Add("station", value);
                _regionManager.RequestNavigate("StationPathRegion", "StationsPathControlRegion", parametrs);
            }
        }
    }
}
