using Fekra_DataAccessLayer.models.Additions;
using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.classes
{
    public class cls_Additions_D
    {
        // completed testing.
        public static async Task<List<md_Additions>?> GetAllAsync(int pageNumber)
        {
            List<md_Additions> additions = new List<md_Additions>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Additions_FUN_GetAll] (@packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                additions.Add
                                    (
                                        new md_Additions
                                        (
                                            reader.GetInt32(reader.GetOrdinal("AdditionId")),
                                            reader.GetInt32(reader.GetOrdinal("TargetId")),
                                            reader.GetString(reader.GetOrdinal("TableName")),
                                            reader.GetDateTime(reader.GetOrdinal("AddedDate")),
                                            reader.GetString(reader.GetOrdinal("AddedData")),
                                            reader.GetString(reader.GetOrdinal("UserName"))
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
                        () => pageNumber
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Additions_D",
                        "GetAllAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return additions.Count > 0 ? additions : null;
        }

        // completed testing.
        public static async Task<List<md_Additions>?> GetByAdminAsync(int adminId, int pageNumber)
        {
            List<md_Additions> additions = new List<md_Additions>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Additions_FUN_GetByAdminId] (@adminId, @packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                additions.Add
                                    (
                                        new md_Additions
                                        (
                                            reader.GetInt32(reader.GetOrdinal("AdditionId")),
                                            reader.GetInt32(reader.GetOrdinal("TargetId")),
                                            reader.GetString(reader.GetOrdinal("TableName")),
                                            reader.GetDateTime(reader.GetOrdinal("AddedDate")),
                                            reader.GetString(reader.GetOrdinal("AddedData")),
                                            reader.GetString(reader.GetOrdinal("UserName"))
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
                        () => adminId,
                        () => pageNumber
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Additions_D",
                        "GetByAdminAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return additions.Count > 0 ? additions : null;
        }

        // completed testing.
        public static async Task<List<md_Additions>?> GetByTableAsync(int tableId, int pageNumber)
        {
            List<md_Additions> additions = new List<md_Additions>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Additions_FUN_GetByTableId] (@tableId, @packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@tableId", SqlDbType.Int) { Value = tableId });
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                additions.Add
                                    (
                                        new md_Additions
                                        (
                                            reader.GetInt32(reader.GetOrdinal("AdditionId")),
                                            reader.GetInt32(reader.GetOrdinal("TargetId")),
                                            reader.GetString(reader.GetOrdinal("TableName")),
                                            reader.GetDateTime(reader.GetOrdinal("AddedDate")),
                                            reader.GetString(reader.GetOrdinal("AddedData")),
                                            reader.GetString(reader.GetOrdinal("UserName"))
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
                        () => tableId,
                        () => pageNumber
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Additions_D",
                        "GetByTableAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return additions.Count > 0 ? additions : null;
        }

        // completed testing.
        public static async Task<md_Additions?> GetByIdAsync(int additionId)
        {
            md_Additions? addition = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Additions_FUN_GetById] (@additionId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@additionId", SqlDbType.Int) { Value = additionId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                addition = new md_Additions
                                    (
                                        reader.GetInt32(reader.GetOrdinal("AdditionId")),
                                        reader.GetInt32(reader.GetOrdinal("TargetId")),
                                        reader.GetString(reader.GetOrdinal("TableName")),
                                        reader.GetDateTime(reader.GetOrdinal("AddedDate")),
                                        reader.GetString(reader.GetOrdinal("AddedData")),
                                        reader.GetString(reader.GetOrdinal("UserName"))
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
                        () => additionId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Additions_D",
                        "GetByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return addition;
        }

        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Additions_FUN_GetCount] ()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object? returnValue = await command.ExecuteScalarAsync();

                        if (returnValue != null && returnValue != DBNull.Value)
                            count = Convert.ToInt32(returnValue);
                    }
                }
            }
            catch (Exception ex)
            {
                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Additions_D",
                        "GetCountAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<int> GetPagesCount_Admin_Async(int adminId)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Additions_FUN_PagesCount_Admin] (@adminId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });

                        await connection.OpenAsync();

                        object? returnValue = await command.ExecuteScalarAsync();

                        if (returnValue != null && returnValue != DBNull.Value)
                            count = Convert.ToInt32(returnValue);
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                    (
                        () => adminId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Additions_D",
                        "GetPagesCount_Admin_Async",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<int> GetPagesCount_All_Async()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Additions_FUN_PagesCount_All] ()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object? returnValue = await command.ExecuteScalarAsync();

                        if (returnValue != null && returnValue != DBNull.Value)
                            count = Convert.ToInt32(returnValue);
                    }
                }
            }
            catch (Exception ex)
            {
                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Additions_D",
                        "GetPagesCount_All_Async",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<int> GetPagesCount_Table_Async(int tableId)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Additions_FUN_PagesCount_Table] (@tableId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@tableId", SqlDbType.Int) { Value = tableId });

                        await connection.OpenAsync();

                        object? returnValue = await command.ExecuteScalarAsync();

                        if (returnValue != null && returnValue != DBNull.Value)
                            count = Convert.ToInt32(returnValue);
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                    (
                        () => tableId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Additions_D",
                        "GetPagesCount_Table_Async",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return -1;
            }

            return count;
        }

    }
}
