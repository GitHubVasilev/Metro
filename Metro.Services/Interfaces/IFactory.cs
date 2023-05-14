namespace Metro.Services.Interfaces
{
    /// <summary>
    /// Интерфейс фабрики для создания сущностей
    /// </summary>
    /// <typeparam name="T">Тип с данными</typeparam>
    /// <typeparam name="K">Тип создаваемой сущности</typeparam>
    public interface IFactory<T, K>
    {
        /// <summary>
        /// Создает новую сущность типа <typeparamref name="T"/> из сущности <typeparamref name="T"/>
        /// </summary>
        T ConvertTo(K val);

        /// <summary>
        /// Создает новую сущность типа <typeparamref name="K"/> из сущности <typeparamref name="T"/>
        /// </summary>
        K ConvertTo(T val);
    }
}
