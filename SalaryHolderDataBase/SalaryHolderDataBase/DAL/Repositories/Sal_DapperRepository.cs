using Dapper;
using SalaryHolderDataBase.DAL.Interface;
using SalaryHolderDataBase.DAL.Models;
using System.Data.SqlClient;
using System.Data;
using System;

namespace SalaryHolderDataBase.DAL.Repositories
{
    public class Sal_DapperRepository : IRepository<SalTable>
    {
        private readonly string _connStr;

        public int UserIdentificationNo = 1;

        public Sal_DapperRepository(string connStr)
        {
            _connStr = connStr;
        }

        // Create
        public async Task<int> CreateAsync(int id, SalTable entity)
        {
            using var conn = new SqlConnection(_connStr);
            entity.UserID = UserIdentificationNo;
            var parameters = new
            {
                entity.SalaryDate,
                entity.SalaryAmount,
                entity.Description,
                entity.BogCha_ID,
                entity.UserID
            };

            return await conn.ExecuteAsync(
                "udp_SalTable_Insert",
                parameters,
                commandType: CommandType.StoredProcedure
                );
        }

        // delete
        public async Task<int> DeleteAsync(int id, SalTable entity)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new DynamicParameters();

            entity.UserID = UserIdentificationNo;
            parameters.Add("@userID", entity.UserID);
            parameters.Add("@Sal_ID", entity.Sal_ID);

            return await conn.ExecuteAsync(
                "udp_SalTable_Delete",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        // Get all
        public async  Task<IEnumerable<SalTable>> GetAllAsync(int id)
        {
            using var conn = new SqlConnection(_connStr);

            var sal_List = await conn.QueryAsync<SalTable>(
                "udp_SalTable_GetAll",
                new { userID = id },
                commandType: CommandType.StoredProcedure);

            return sal_List;
        }

        // Get by id
        public async  Task<SalTable?> GetByIdAsync(int id, int recID)
        {
            using var conn = new SqlConnection(_connStr);

            var salary = await conn.QueryFirstOrDefaultAsync<SalTable>(
                "udp_SalTable_GetByID",
                new { userID = id, Sal_ID = recID },
                commandType: CommandType.StoredProcedure
                );
            if (salary != null)
                return salary;

            return null;
        }

        // Update
        public async Task<int> UpdateAsync(int id, SalTable entity)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new DynamicParameters();

            entity.UserID = UserIdentificationNo;

            parameters.Add("@Sal_ID", entity.Sal_ID);
            parameters.Add("@SalaryDate", entity.SalaryDate);
            parameters.Add("@SalaryAmount", entity.SalaryAmount);
            parameters.Add("@Description", entity.Description);
            parameters.Add("@BogCha_ID", entity.BogCha_ID);
            parameters.Add("@UserID", entity.UserID);

            return await conn.ExecuteAsync(
                "udp_SalTable_Update",
                parameters,
                commandType: CommandType.StoredProcedure
                );
        }
    }
}
