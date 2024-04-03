using SalaryHolderDataBase.DAL.Models;

namespace SalaryHolderDataBase.DAL.Interface
{
    public interface I_User_Repo
    {
        Task<IEnumerable<UserList>> GetAllAsync();

        Task<UserList?> GetByIdAsync(int recID);

        Task<int> CreateAsync( UserList entity);

        Task<int> UpdateAsync( UserList entity);

        Task<int> DeleteAsync( UserList entity);
    }
}
