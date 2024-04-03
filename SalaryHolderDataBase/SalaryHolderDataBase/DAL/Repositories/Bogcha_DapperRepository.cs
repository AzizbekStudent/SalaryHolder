using Dapper;
using SalaryHolderDataBase.DAL.Interface;
using SalaryHolderDataBase.DAL.Models;

namespace SalaryHolderDataBase.DAL.Repositories
{
    public class Bogcha_DapperRepository : IRepository<Bogcha>
    {
        private readonly string _connStr;

        public Bogcha_DapperRepository(string connStr)
        {
            _connStr = connStr;
        }

        public Task<int> CreateAsync(int id, Bogcha entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id, Bogcha entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bogcha>> GetAllAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Bogcha?> GetByIdAsync(int id, int recID)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, Bogcha entity)
        {
            throw new NotImplementedException();
        }
    }
}
