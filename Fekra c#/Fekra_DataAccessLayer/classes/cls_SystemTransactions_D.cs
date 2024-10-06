using Fekra_DataAccessLayer.models.Additions;
using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.models.SystemTransactions;
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
    public class cls_SystemTransactions_D
    {
        // completed testing.
        public static async Task<List<md_SystemTransactions>?> GetByTarget(int targetId, string tableName)
        {
            List<md_SystemTransactions> transactions = new List<md_SystemTransactions>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[SystemTransactions_FUN_GetTransactionsByTargetId] (@targetId, @tableName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@targetId", SqlDbType.Int) { Value = targetId });
                        command.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 100) { Value = tableName });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                transactions.Add
                                    (
                                        new md_SystemTransactions
                                        (
                                            reader.GetInt32(reader.GetOrdinal("TransactionId")),
                                            reader.GetInt32(reader.GetOrdinal("TargetId")),
                                            reader.GetString(reader.GetOrdinal("TableName")),
                                            reader.GetDateTime(reader.GetOrdinal("TransactionDate")),
                                            reader.GetString(reader.GetOrdinal("TransactionData")),
                                            reader.GetString(reader.GetOrdinal("UserName")),
                                            reader.GetByte(reader.GetOrdinal("TransactionType"))
                                        )
                                    );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                    (
                        () => targetId,
                        () => tableName
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_SystemTransactions_D",
                        "GetByTarget",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return transactions.Count > 0 ? transactions : null;
        }
    }
}
