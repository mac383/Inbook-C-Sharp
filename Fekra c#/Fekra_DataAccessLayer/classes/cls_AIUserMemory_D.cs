using Fekra_DataAccessLayer.models.AIUserMemory;
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
    public class cls_AIUserMemory_D
    {
        public static async Task<bool> UpdateUserMemoryAsync(md_UpdateUserMemory updateData)
        {
            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string procedureName = "AIUserMemory_SP_UpdateUserMemory";

                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@MemoryId", SqlDbType.Int) { Value = updateData.MemoryId });
                        command.Parameters.Add(new SqlParameter("@RememberData", SqlDbType.NVarChar, 3000) { Value = updateData.RememberData });

                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams(() => updateData.MemoryId, () => updateData.RememberData);

                await cls_Errors_D.LogErrorAsync(new md_NewError
                (
                    ex.Message,
                    "Data Access Layer",
                    ex.Source ?? "null",
                    "cls_AIUserMemory_D",
                    "UpdateUserMemoryAsync",
                    ex.StackTrace ?? "null",
                    null,
                    Params
                ));

                return false;
            }
        }

        public static async Task<md_UserMemory?> GetUserMemoryByUserIdAsync(int userId)
        {
            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = "SELECT * FROM [dbo].[AIUserMemory_FUN_GetUserMemoryByUserId](@UserId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = userId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new md_UserMemory
                                (
                                    reader.GetInt32(reader.GetOrdinal("MemoryId")),
                                    reader.GetString(reader.GetOrdinal("RememberData")),
                                    reader.GetDateTime(reader.GetOrdinal("LastUpdated"))
                                );
                            }
                        }
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
                    "cls_AIUserMemory_D",
                    "GetUserMemoryByUserIdAsync",
                    ex.StackTrace ?? "null",
                    null,
                    Params
                ));
            }

            return null; // إذا لم يتم العثور على ذاكرة
        }
    }
}
