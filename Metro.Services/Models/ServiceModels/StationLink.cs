using Metro.Data.Entities;

namespace Metro.Services.Models.ServiceModels
{
    /// <summary>
    /// Модель односвязного списка для использования сервисом. Необходимая для расчета пути по графу метро
    /// </summary>
    public record StationLink
    {
        /// <summary>
        /// Предыдушая станция
        /// </summary>
        public StationLink? Prev { get; set; }
        /// <summary>
        /// Станция, на которой находится указатель
        /// </summary>
        public Station Current { get; set; } = null!;
        /// <summary>
        /// Список посещенных ветвей
        /// </summary>
        public HashSet<Branch> VisitedBranches { get; set; } = null!;
        /// <summary>
        /// Список посещенных станций
        /// </summary>
        public HashSet<Station> VisitedStation { get; set; } = null!;
        /// <summary>
        /// Длинна пути
        /// </summary>
        public double WayLangth { get; set; }
    }
}
