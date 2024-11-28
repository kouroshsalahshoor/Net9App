namespace Application.Repository.IRepository;

public interface IRepository<T> where T : class
{
    Task<IReadOnlyList<T>> Get();
    Task<T> Get(int id);
    Task<T> Create(T model);
    Task Update(T model);
    Task Delete(int id);
}
