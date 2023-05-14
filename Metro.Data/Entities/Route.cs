namespace Metro.Data.Entities
{
    /// <summary>
    /// Модель пути между станциями
    /// </summary>
    public class Route
    {
        /// <summary>
        /// Идентификатор пути
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Станция начала пути
        /// </summary>
        public Station StartStation { get; set; } = null!;
        /// <summary>
        /// Идентификатор станции начала пути
        /// </summary>
        public int StartStationId { get; set; }
        /// <summary>
        /// Станция конца пути
        /// </summary>
        public Station FinishStation { get; set; } = null!;
        /// <summary>
        /// Идентификатор станции конца пути
        /// </summary>
        public int FinishStationId { get; set; }
        /// <summary>
        /// Время в пути между станциями
        /// </summary>
        public double Time { get; set; }
        /// <summary>
        /// Расстояния между станциями
        /// </summary>
        public double Length { get; set; }
    }
}
