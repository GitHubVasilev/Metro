using Metro.Services.Models.DTO;

namespace Metro.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для расчета пути
    /// </summary>
    public interface IRoutingService
    {
        /// <summary>
        /// Вовзращает минимальный путь для обхода всех веток метро
        /// "Ветка считается пройденой, если была посещена хотя бы одна станция"
        /// </summary>
        /// <param name="startStation">Идентификатор станции для начала пути</param>
        /// <returns>Связанный список станций проложенного пути</returns>
        List<StationDTO> MinTimeForAllBranch(int startStation);
    }
}
