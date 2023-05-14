namespace Metro.Data.Entities
{
    /// <summary>
    /// Модель станции
    /// </summary>
    public class Branch
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
        /// Цвет ветки
        /// </summary>
        public string? ColorHex { get; set; } = null!;
    }
}
