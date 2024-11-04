using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.models.Sessions;
using Fekra_DataAccessLayer.models.Users;
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
    public class cls_Sessions_D
    {
        // completed testing.
        public static async Task<List<md_Sessions>?> GetActiveSessionsAsync(int pageNumber)
        {
            List<md_Sessions> sessions = new List<md_Sessions>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Sessions_FUN_GetActiveSessions] (@packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                sessions.Add
                                    (
                                        new md_Sessions
                                        (
                                            reader.GetInt32(reader.GetOrdinal("SessionId")),
                                            reader.GetString(reader.GetOrdinal("SessionKey")),
                                            reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                            reader.GetString(reader.GetOrdinal("UserName")),
                                            reader.GetString(reader.GetOrdinal("Email"))
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
                        "cls_Sessions_D",
                        "GetActiveSessionsAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return sessions.Count > 0 ? sessions : null;
        }

        // completed testing.
        public static async Task<List<md_Sessions>?> GetInActiveSessionsAsync(int pageNumber)
        {
            List<md_Sessions> sessions = new List<md_Sessions>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Sessions_FUN_GetInActiveSessions] (@packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                sessions.Add
                                    (
                                        new md_Sessions
                                        (
                                            reader.GetInt32(reader.GetOrdinal("SessionId")),
                                            reader.GetString(reader.GetOrdinal("SessionKey")),
                                            reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                            reader.GetString(reader.GetOrdinal("UserName")),
                                            reader.GetString(reader.GetOrdinal("Email"))
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
                        "cls_Sessions_D",
                        "GetInActiveSessionsAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return sessions.Count > 0 ? sessions : null;
        }

        // completed testing.
        public static async Task<string?> GetActiveSessionKeyAsync(int userId)
        {
            string? key = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Sessions_FUN_GetActiveKey] (@userId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = userId });

                        await connection.OpenAsync();

                        object? returnValue = await command.ExecuteScalarAsync();

                        if (returnValue != null && returnValue != DBNull.Value)
                            key = returnValue.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                    (
                        () => userId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Sessions_D",
                        "GetActiveSessionKey",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return key;
        }

        // completed testing.
        public static async Task<int> GetActivesCountAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Sessions_FUN_GetActivesCount] ()";

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
                        "cls_Sessions_D",
                        "GetActivesCountAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<int> GetInActivesCountAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Sessions_FUN_GetInActivesCount] ()";

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
                        "cls_Sessions_D",
                        "GetInActivesCountAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<int> GetSessionsPagesCountActivesAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Sessions_FUN_PagesCount_Actives] ()";

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
                        "cls_Sessions_D",
                        "GetSessionsPagesCountActivesAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<int> GetSessionsPagesCountInActivesAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Sessions_FUN_PagesCount_InActives] ()";

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
                        "cls_Sessions_D",
                        "GetSessionsPagesCountInActivesAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<bool> DeleteInActiveSessionsAsync()
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Sessions_SP_DeleteInActiveSessions]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter returnParameter = command.Parameters.Add("returnValue", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        rowsAffected = (int)returnParameter.Value;
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
                        "cls_Sessions_D",
                        "DeleteInActiveSessionsAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        // completed testing.
        public static async Task<bool> IsSessionKeyActiveAsync(string key)
        {
            bool isActive = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Sessions_SP_IsKeyActive]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@key", SqlDbType.NVarChar, 100) { Value = key });

                        SqlParameter returnParameter = command.Parameters.Add("returnValue", SqlDbType.Bit);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        isActive = Convert.ToBoolean(returnParameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                    (
                        () => key
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Sessions_D",
                        "IsSessionKeyActiveAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return isActive;
        }

        // completed testing.
        public static async Task<bool> IsSessionKeyExistAsync(string key)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Sessions_SP_IsKeyExist]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@key", SqlDbType.NVarChar, 100) { Value = key });

                        SqlParameter returnParameter = command.Parameters.Add("returnValue", SqlDbType.Bit);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        isExist = Convert.ToBoolean(returnParameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                    (
                        () => key
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Sessions_D",
                        "IsSessionKeyExistAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return isExist;
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewSession session)
        {
            int insertedId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Sessions_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@key", SqlDbType.NVarChar, 100) { Value = session.Key });
                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = session.UserId });

                        SqlParameter returnParameter = command.Parameters.Add("returnValue", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        insertedId = (int)returnParameter.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                    (
                        () => session.Key,
                        () => session.UserId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Sessions_D",
                        "NewAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return -1;
            }

            return insertedId;
        }

        // completed testing.
        public static async Task<bool> SetSessionAsInActiveAsync(int userId)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Sessions_SP_SetAsInActive]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = userId });

                        SqlParameter returnParameter = command.Parameters.Add("returnValue", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        rowsAffected = (int)returnParameter.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                    (
                        () => userId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Sessions_D",
                        "SetSessionAsInActiveAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        // completed testing.
        public static async Task<(int TotalSessions, int ActiveSessions, int InActiveSessions)> GetUserSessionsAnalyticsAsync(int userId)
        {
            int totalSessions = 0;
            int activeSessions = 0;
            int inactiveSessions = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = "[dbo].[Sessions_SP_GetUserSessionsAnalytics]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = userId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                totalSessions = reader.GetInt32(reader.GetOrdinal("TotalSessions"));
                                activeSessions = reader.GetInt32(reader.GetOrdinal("ActiveSessions"));
                                inactiveSessions = reader.GetInt32(reader.GetOrdinal("InactiveSessions"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                (
                    () => userId
                );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                (
                    ex.Message,
                    "Data Access Layer",
                    string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                    "cls_Sessions_D",
                    "GetUserSessionsAnalyticsAsync",
                    string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                    null,
                    Params
                ));

                return (-1, -1, -1);
            }

            return (totalSessions, activeSessions, inactiveSessions);
        }

    }
}
