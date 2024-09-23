using Fekra_DataAccessLayer.models.Additions;
using Fekra_DataAccessLayer.models.Deletions;
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
    public class cls_Deletions_D
    {
        // completed testing.
        public static async Task<List<md_Deletions>?> GetAllAsync(int pageNumber)
        {
            List<md_Deletions> deletions = new List<md_Deletions>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Deletions_FUN_GetAll] (@packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                deletions.Add
                                    (
                                        new md_Deletions
                                        (
                                            reader.GetInt32(reader.GetOrdinal("DeletionId")),
                                            reader.GetInt32(reader.GetOrdinal("TargetId")),
                                            reader.GetString(reader.GetOrdinal("TableName")),
                                            reader.GetDateTime(reader.GetOrdinal("DeletionDate")),
                                            reader.GetString(reader.GetOrdinal("DeletedData")),
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
                        "cls_Deletions_D",
                        "GetAllAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return deletions.Count > 0 ? deletions : null;
        }

        // completed testing.
        public static async Task<List<md_Deletions>?> GetByAdminAsync(int adminId, int pageNumber)
        {
            List<md_Deletions> deletions = new List<md_Deletions>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Deletion_FUN_GetByAdminId] (@adminId, @packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                deletions.Add
                                    (
                                        new md_Deletions
                                        (
                                            reader.GetInt32(reader.GetOrdinal("DeletionId")),
                                            reader.GetInt32(reader.GetOrdinal("TargetId")),
                                            reader.GetString(reader.GetOrdinal("TableName")),
                                            reader.GetDateTime(reader.GetOrdinal("DeletionDate")),
                                            reader.GetString(reader.GetOrdinal("DeletedData")),
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
                        "cls_Deletions_D",
                        "GetByAdminAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return deletions.Count > 0 ? deletions : null;
        }

        // completed testing.
        public static async Task<List<md_Deletions>?> GetByTableAsync(int tableId, int pageNumber)
        {
            List<md_Deletions> deletions = new List<md_Deletions>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Deletions_FUN_GetByTableId] (@tableId, @packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@tableId", SqlDbType.Int) { Value = tableId });
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                deletions.Add
                                    (
                                        new md_Deletions
                                        (
                                            reader.GetInt32(reader.GetOrdinal("DeletionId")),
                                            reader.GetInt32(reader.GetOrdinal("TargetId")),
                                            reader.GetString(reader.GetOrdinal("TableName")),
                                            reader.GetDateTime(reader.GetOrdinal("DeletionDate")),
                                            reader.GetString(reader.GetOrdinal("DeletedData")),
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
                        "cls_Deletions_D",
                        "GetByTableAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return deletions.Count > 0 ? deletions : null;
        }

        // completed testing.
        public static async Task<md_Deletions?> GetByIdAsync(int deletionId)
        {
            md_Deletions? deletion = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Deletions_FUN_GetById] (@deletionId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@deletionId", SqlDbType.Int) { Value = deletionId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                deletion = new md_Deletions
                                    (
                                        reader.GetInt32(reader.GetOrdinal("DeletionId")),
                                        reader.GetInt32(reader.GetOrdinal("TargetId")),
                                        reader.GetString(reader.GetOrdinal("TableName")),
                                        reader.GetDateTime(reader.GetOrdinal("DeletionDate")),
                                        reader.GetString(reader.GetOrdinal("DeletedData")),
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
                        () => deletionId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Deletions_D",
                        "GetByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return deletion;
        }

        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Deletions_FUN_GetCount] ()";

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
                        "cls_Deletions_D",
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
                    string query = @"SELECT [dbo].[Deletions_FUN_PagesCount_Admin] (@adminId)";

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
                        "cls_Deletions_D",
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
                    string query = @"SELECT [dbo].[Deletions_FUN_PagesCount_All] ()";

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
                        "cls_Deletions_D",
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
                    string query = @"SELECT [dbo].[Deletions_FUN_PagesCount_Table] (@tableId)";

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
                        "cls_Deletions_D",
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
