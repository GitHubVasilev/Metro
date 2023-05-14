using Metro.Data.Entities;
using Metro.Data.Interfaces;
using Metro.Services.Interfaces;
using Metro.Services.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Metro.Services.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы со списком станций
    /// </summary>
    internal class StationsService : IStationsService
    {
        private readonly IRepository<Station> _stationRepository;
        private readonly IFactory<Station, StationDTO> _stationFactory;

        public StationsService(IUnitOfWork unitOfWork,
            IFactory<Station, StationDTO> stationsFactory)
        {
            _stationRepository = unitOfWork.GetRepository<Station>();
            _stationFactory = stationsFactory;
        }
        /// <summary>
        /// Возвращает список станций
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StationDTO> GetStations()
        {
            List<StationDTO> result = new List<StationDTO>();

            foreach (Station station in _stationRepository.GetAll().Include(m => m.Branch)) 
            {
                result.Add(_stationFactory.ConvertTo(station));
            }

            return result;
        }
    }
}
