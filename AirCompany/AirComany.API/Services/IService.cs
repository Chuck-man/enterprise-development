namespace AirCompany.API.Services;

/// <summary>
/// Интерфейс для сервисов сущностей
/// </summary>
/// <typeparam name="PDT">Тип сущности Dto</typeparam>
/// <typeparam name="GDT">Тип сущности полная-Dto</typeparam>
public interface IService<PDT, GDT>
{
    /// <summary>
    /// Получение всех сущностей
    /// </summary>
    /// <returns>Список сущностей</returns>
    public IEnumerable<GDT> GetAll();

    /// <summary>
    /// Получение сущности по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <returns>Сущность с выбранным идентификатором</returns>
    public GDT? GetById(int id);

    /// <summary>
    /// Добавление сущности
    /// </summary>
    /// <param name="entity">Новая сущность</param>
    /// <returns>Добавленная сущность</returns>
    public GDT? Post(PDT entity);

    /// <summary>
    /// Обновляет сущность по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <param name="entity">Новая сущность</param>
    /// <returns>Результат операции</returns>
    public bool Put(int id, PDT entity);

    /// <summary>
    /// Удаляет сущность по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <returns>Результат операции</returns>
    public bool Delete(int id);
}