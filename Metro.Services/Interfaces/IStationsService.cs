using Metro.Services.Models.DTO;

namespace Metro.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы со списком станций
    /// </summary>
    public interface IStationsService
    {
        /// <summary>
        /// Возвращает список станций
        /// </summary>
        /// <returns></returns>
        IEnumerable<StationDTO> GetStations();
    }
}
