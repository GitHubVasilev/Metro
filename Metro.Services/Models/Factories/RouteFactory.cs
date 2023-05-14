using Metro.Data.Entities;
using Metro.Services.Interfaces;
using Metro.Services.Models.DTO;

namespace Metro.Services.Models.Factories
{
    /// <summary>
    /// Класс для конвертации данных между <see cref="RouteDTO"/> и <see cref="Route"/>
    /// </summary>
    public class RouteFactory : IFactory<Route, RouteDTO>
    {
        private readonly IFactory<Station, StationDTO> _factoryStations;
        public RouteFactory(IFactory<Station, StationDTO> factoryStations)
        {
            _factoryStations = factoryStations;
        }
        /// <summary>
        /// Создает новую модель <see cref="RouteDTO"/>
        /// </summary>
        /// <param name="val">модель базы данных <see cref="Route"/></param>
        /// <returns></returns>
        public Route ConvertTo(RouteDTO val)
        {
            return new Route
            {
                Id = val.Id,
                StartStation = _factoryStations.ConvertTo(val.StartStation),
                FinishStation = _factoryStations.ConvertTo(val.FinishStation),
                StartStationId = val.StartStation.Id,
                FinishStationId = val.FinishStation.Id,
                Length = val.Length,
                Time = val.Time,
            };
        }

        /// <summary>
        /// Создает новую модель <see cref="RouteDTO"/>
        /// </summary>
        /// <param name="val">модель базы данных <see cref="Route"/></param>
        /// <returns></returns>
        public RouteDTO ConvertTo(Route val)
        {
            return new RouteDTO
            {
                Id = val.Id,
                StartStation = _factoryStations.ConvertTo(val.StartStation),
                FinishStation = _factoryStations.ConvertTo(val.FinishStation),
                Length = val.Length,
                Time = val.Time
            };
        }
    }
}
