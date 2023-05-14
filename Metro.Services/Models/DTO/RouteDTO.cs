namespace Metro.Services.Models.DTO
{
    /// <summary>
    /// Моель пути для передачи данных
    /// </summary>
    public record RouteDTO
    {
        /// <summary>
        /// Идентификатор пути
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Станция начала пути
        /// </summary>
        public StationDTO StartStation { get; set; } = null!;
        /// <summary>
        /// Станция конца пути 
        /// </summary>
        public StationDTO FinishStation { get; set; } = null!;
        /// <summary>
        /// Время в пути
        /// </summary>
        public double Time { get; set; }
        /// <summary>
        /// Длинна в пути
        /// </summary>
        public double Length { get; set; }
    }
}
