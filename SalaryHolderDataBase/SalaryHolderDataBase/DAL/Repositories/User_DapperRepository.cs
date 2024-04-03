using Dapper;
using SalaryHolderDataBase.DAL.Interface;
using SalaryHolderDataBase.DAL.Models;
using System.Data;
using System.Data.SqlClient;

namespace SalaryHolderDataBase.DAL.Repositories
{
    public class User_DapperRepository : I_User_Repo
    {
        private readonly string _connStr;

        public User_DapperRepository(string connStr)
        {
            _connStr = connStr;
        }

        public async Task<int> CreateAsync(UserList entity)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new
            {
                entity.UserName,
                entity.UserPassword
            };

            return await conn.ExecuteAsync(
                "udp_User_Insert",
                parameters,
                commandType: CommandType.StoredProcedure
                );
        }

        public async Task<int> DeleteAsync(UserList entity)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new
            {
                userID = entity.UserID
            };

            return await conn.ExecuteAsync(
                "udp_User_Delete",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<UserList>> GetAllAsync()
        {
            using var conn = new SqlConnection(_connStr);

            var userlist = await conn.QueryAsync<UserList>(
                "udp_User_GetAll",
                commandType: CommandType.StoredProcedure);

            return userlist;
        }

        public async Task<UserList?> GetByIdAsync(int recID)
        {
            using var conn = new SqlConnection(_connStr);

            var user = await conn.QueryFirstOrDefaultAsync<UserList>(
                "udp_User_GetById",
                new { userID = recID },
                commandType: CommandType.StoredProcedure
                );
            if (user != null)
                return user;

            return null;
        }

        public async Task<int> UpdateAsync(UserList entity)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new DynamicParameters();

            parameters.Add("@User_ID", entity.UserID);
            parameters.Add("@User_Name", entity.UserName);
            parameters.Add("@User_Password", entity.UserPassword);

            return await conn.ExecuteAsync(
                "udp_User_Update",
                parameters,
                commandType: CommandType.StoredProcedure
                );
        }
    }
}
