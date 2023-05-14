using Metro.Data.Entities;
using Metro.Services.Interfaces;
using Metro.Services.Models.DTO;

namespace Metro.Services.Models.Factories
{
    /// <summary>
    /// Класс для конвертации данных между <see cref="StationDTO"/> и <see cref="Station"/>
    /// </summary>
    public class StationFastory : IFactory<Station, StationDTO>
    {
        private readonly IFactory<Branch, BranchDTO> _branchFactory;

        public StationFastory(IFactory<Branch, BranchDTO> branchFactory)
        {
            _branchFactory = branchFactory;
        }

        /// <summary>
        /// Создает новую модель <see cref="Station"/>
        /// </summary>
        /// <param name="val">модель базы данных <see cref="StationDTO"/></param>
        /// <returns></returns>
        public StationDTO ConvertTo(Station val)
        {
            return new StationDTO
            {
                Id = val.Id,
                Name = val.Name,
                Branch = _branchFactory.ConvertTo(val.Branch),
            };
        }

        /// <summary>
        /// Создает новую модель <see cref="StationDTO"/>
        /// </summary>
        /// <param name="val">модель базы данных <see cref="Station"/></param>
        /// <returns></returns>
        public Station ConvertTo(StationDTO val)
        {
            return new Station
            {
                Id = val.Id,
                Name = val.Name,
                Branch = _branchFactory.ConvertTo(val.Branch),
                BranchId = val.Id
            };
        }
    }
}
