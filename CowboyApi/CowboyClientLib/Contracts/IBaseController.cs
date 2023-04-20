
namespace CowboyApi.Contracts
{
    public interface IBaseController<T> 
    {
   
        public Task Add(T entity);
        public Task AddRange(IEnumerable<T> entity);
        public Task<T> Single(Guid id);
        public Task<IEnumerable<T>> List();
        public Task<bool> Remove(Guid id);
        public Task<T> Update(T entity);
        Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entity);


    }
}
