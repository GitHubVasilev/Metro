namespace Metro.Data.Entities
{
    /// <summary>
    /// Модель станции
    /// </summary>
    public class Station
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
        /// Ветвь на которой находится станция
        /// </summary>
        public Branch Branch { get; set; } = null!;
        /// <summary>
        /// Идентификатор станции
        /// </summary>
        public int BranchId { get; set; }
    }
}
