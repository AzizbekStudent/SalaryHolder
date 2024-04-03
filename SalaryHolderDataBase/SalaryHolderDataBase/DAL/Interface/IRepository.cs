namespace SalaryHolderDataBase.DAL.Interface
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(int id);

        Task<T?> GetByIdAsync(int id, int recID);

        Task<int> CreateAsync(int id, T entity);

        Task<int> UpdateAsync(int id, T entity);

        Task<int> DeleteAsync(int id, T entity);
    }
}
