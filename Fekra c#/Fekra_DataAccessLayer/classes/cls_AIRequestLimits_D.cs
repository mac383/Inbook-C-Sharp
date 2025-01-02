using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.classes
{
    public class cls_AIRequestLimits_D
    {
        public static async Task<bool> CheckIfLimitExistsAsync(int userId)
        {
            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[AIRequestLimits_FUN_CheckIfLimitExists](@UserId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = userId });

                        await connection.OpenAsync();

                        var result = await command.ExecuteScalarAsync();
                        return Convert.ToInt32(result) == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams(() => userId);

                await cls_Errors_D.LogErrorAsync(new md_NewError
                (
                    ex.Message,
                    "Data Access Layer",
                    ex.Source ?? "null",
                    "cls_AIRequestLimits_D",
                    "CheckIfLimitExistsAsync",
                    ex.StackTrace ?? "null",
                    null,
                    Params
                ));

                return false;
            }
        }

        public static async Task<bool> ResetLimitAsync(int userId)
        {
            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string procedureName = @"AIRequestLimits_SP_ResetLimit";

                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = userId });

                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams(() => userId);

                await cls_Errors_D.LogErrorAsync(new md_NewError
                (
                    ex.Message,
                    "Data Access Layer",
                    ex.Source ?? "null",
                    "cls_AIRequestLimits_D",
                    "ResetLimitAsync",
                    ex.StackTrace ?? "null",
                    null,
                    Params
                ));

                return false;
            }
        }

        public static async Task<bool> DecrementRemainingRequestsAsync(int userId)
        {
            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string procedureName = @"AIRequestLimits_SP_DecrementRemainingRequests";

                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = userId });

                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams(() => userId);

                await cls_Errors_D.LogErrorAsync(new md_NewError
                (
                    ex.Message,
                    "Data Access Layer",
                    ex.Source ?? "null",
                    "cls_AIRequestLimits_D",
                    "DecrementRemainingRequestsAsync",
                    ex.StackTrace ?? "null",
                    null,
                    Params
                ));

                return false;
            }
        }

        public static async Task<int> GetRemainingRequestsAsync(int userId)
        {
            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[AIRequestLimits_FUN_GetRemainingRequests](@UserId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = userId });

                        await connection.OpenAsync();

                        var result = await command.ExecuteScalarAsync();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams(() => userId);

                await cls_Errors_D.LogErrorAsync(new md_NewError
                (
                    ex.Message,
                    "Data Access Layer",
                    ex.Source ?? "null",
                    "cls_AIRequestLimits_D",
                    "GetRemainingRequestsAsync",
                    ex.StackTrace ?? "null",
                    null,
                    Params
                ));

                return 0;
            }
        }
    }
}
