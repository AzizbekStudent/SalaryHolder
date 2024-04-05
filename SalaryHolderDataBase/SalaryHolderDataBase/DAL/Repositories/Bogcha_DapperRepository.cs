using Dapper;
using SalaryHolderDataBase.DAL.Interface;
using SalaryHolderDataBase.DAL.Models;
using System.Data.SqlClient;
using System.Data;
using Humanizer;

namespace SalaryHolderDataBase.DAL.Repositories
{
    public class Bogcha_DapperRepository : IRepository<Bogcha>
    {
        private readonly string _connStr;

        public int UserIdentificationNo = 1;

        public Bogcha_DapperRepository(string connStr)
        {
            _connStr = connStr;
        }

        public async Task<int> CreateAsync(int id, Bogcha entity)
        {
            using var conn = new SqlConnection(_connStr);
            entity.UserID = UserIdentificationNo;
            var parameters = new
            {
                entity.Title,
                entity.Description,
                entity.HireDate,
                entity.FireDate,
                entity.Salary,
                entity.IsWorking,
                entity.GroupAmount,
                entity.ZavName,
                entity.UserID
            };

            return await conn.ExecuteAsync(
                "udp_Bogcha_Insert",
                parameters,
                commandType: CommandType.StoredProcedure
                );
        }

        public async Task<int> DeleteAsync(int id, Bogcha entity)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new DynamicParameters();

            entity.UserID = UserIdentificationNo;
            parameters.Add("@userID", entity.UserID);
            parameters.Add("@BogCha_ID", entity.BogCha_ID);

            return await conn.ExecuteAsync(
                "udp_Bogcha_Delete",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Bogcha>> GetAllAsync(int id)
        {
            using var conn = new SqlConnection(_connStr);

            var bogchList = await conn.QueryAsync<Bogcha>(
                "udp_Bogcha_GetAll",
                new { userID = id},
                commandType: CommandType.StoredProcedure);

            return bogchList;
        }

        public async Task<Bogcha?> GetByIdAsync(int id, int recID)
        {
            using var conn = new SqlConnection(_connStr);

            var bogcha = await conn.QueryFirstOrDefaultAsync<Bogcha>(
                "udp_Bogcha_GetByID",
                new { userID = id, BogCha_ID = recID},
                commandType: CommandType.StoredProcedure
                );
            if (bogcha != null)
                return bogcha;

            return null;
        }

        public async Task<int> UpdateAsync(int id, Bogcha entity)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new DynamicParameters();

            entity.UserID = UserIdentificationNo;

            parameters.Add("@BogCha_ID", entity.BogCha_ID);
            parameters.Add("@Title", entity.Title);
            parameters.Add("@Description", entity.Description);
            parameters.Add("@HireDate", entity.HireDate);
            parameters.Add("@FireDate", entity.FireDate);
            parameters.Add("@Salary", entity.Salary);
            parameters.Add("@IsWorking", entity.IsWorking);
            parameters.Add("@GroupAmount", entity.GroupAmount);
            parameters.Add("@ZavName", entity.ZavName);
            parameters.Add("@UserID", entity.UserID);

            return await conn.ExecuteAsync(
                "udp_Bogcha_Update",
                parameters,
                commandType: CommandType.StoredProcedure
                );
        }
    }
}
