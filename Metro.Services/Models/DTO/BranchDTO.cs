namespace Metro.Services.Models.DTO
{
    /// <summary>
    /// Модель данных ветви для передачи
    /// </summary>
    public record BranchDTO
    {
        /// <summary>
        /// Идентификатор ветви
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название ветви
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Цвет ветки в формате HEX
        /// </summary>
        public string ColorHex { get; set; } = null!;
    }
}
