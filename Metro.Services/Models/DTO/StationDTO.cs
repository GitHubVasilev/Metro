namespace Metro.Services.Models.DTO
{
    /// <summary>
    /// Модель станции для передачи
    /// </summary>
    public record StationDTO
    {
        /// <summary>
        /// Идентификатор станции
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название станции
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Ветвь на которой станция находится
        /// </summary>
        public BranchDTO Branch { get; set; } = null!;
    }
}
