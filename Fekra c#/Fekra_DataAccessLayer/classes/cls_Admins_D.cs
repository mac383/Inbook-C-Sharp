using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.models.System_Tables;
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
    public class cls_Admins_D
    {
        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Admins_FUN_Count] ()";

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
                        "cls_Admins_D",
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
        public static async Task<int> GetDeletionsCountAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Admins_FUN_DeletionsCount] ()";

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
                        "cls_Admins_D",
                        "GetDeletionsCountAsync",
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
                    string query = @"SELECT [dbo].[Admins_FUN_InActivesCount] ()";

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
                        "cls_Admins_D",
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
        public static async Task<int> GetAllPagesCountAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Admins_FUN_PagesCount_All] ()";

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
                        "cls_Admins_D",
                        "GetAllPagesCountAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<int> GetDeletionsPagesCountAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Admins_FUN_PagesCount_Deletions] ()";

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
                        "cls_Admins_D",
                        "GetDeletionsPagesCountAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<int> GetInActivesPagesCountAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Admins_FUN_PagesCount_InActives] ()";

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
                        "cls_Admins_D",
                        "GetInActivesPagesCountAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<List<md_Admins>?> GetAllAsync(int pageNumber)
        {
            List<md_Admins> admins = new List<md_Admins>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Admins_FUN_GetAll] (@packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                admins.Add
                                    (
                                        new md_Admins
                                        (
                                            reader.GetInt32(reader.GetOrdinal("AdminId")),
                                            reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                            reader.GetString(reader.GetOrdinal("FullName")),
                                            reader.GetString(reader.GetOrdinal("UserName")),
                                            
                                            reader.IsDBNull(reader.GetOrdinal("ProfileImageURL")) ?
                                            null : reader.GetString(reader.GetOrdinal("ProfileImageURL")),

                                            reader.IsDBNull(reader.GetOrdinal("ProfileImageName")) ?
                                            null : reader.GetString(reader.GetOrdinal("ProfileImageName")),

                                            reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
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
                        "cls_Admins_D",
                        "GetAllAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return admins.Count > 0 ? admins : null;
        }

        // completed testing.
        public static async Task<List<md_Admins>?> GetByFullNameAsync(string fullName)
        {
            List<md_Admins> admins = new List<md_Admins>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Admins_FUN_GetByFullName] (@fullName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@fullName", SqlDbType.NVarChar, 25) { Value = fullName });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                admins.Add
                                    (
                                        new md_Admins
                                        (
                                            reader.GetInt32(reader.GetOrdinal("AdminId")),
                                            reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                            reader.GetString(reader.GetOrdinal("FullName")),
                                            reader.GetString(reader.GetOrdinal("UserName")),

                                            reader.IsDBNull(reader.GetOrdinal("ProfileImageURL")) ?
                                            null : reader.GetString(reader.GetOrdinal("ProfileImageURL")),

                                            reader.IsDBNull(reader.GetOrdinal("ProfileImageName")) ?
                                            null : reader.GetString(reader.GetOrdinal("ProfileImageName")),

                                            reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
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
                        () => fullName
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "GetByFullNameAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return admins.Count > 0 ? admins : null;
        }

        // completed testing.
        public static async Task<List<md_Admins>?> GetDeletionsAsync(int pageNumber)
        {
            List<md_Admins> admins = new List<md_Admins>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Admins_FUN_GetDeletions] (@packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                admins.Add
                                    (
                                        new md_Admins
                                        (
                                            reader.GetInt32(reader.GetOrdinal("AdminId")),
                                            reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                            reader.GetString(reader.GetOrdinal("FullName")),
                                            reader.GetString(reader.GetOrdinal("UserName")),

                                            reader.IsDBNull(reader.GetOrdinal("ProfileImageURL")) ?
                                            null : reader.GetString(reader.GetOrdinal("ProfileImageURL")),

                                            reader.IsDBNull(reader.GetOrdinal("ProfileImageName")) ?
                                            null : reader.GetString(reader.GetOrdinal("ProfileImageName")),

                                            reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
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
                        "cls_Admins_D",
                        "GetDeletionsAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return admins.Count > 0 ? admins : null;
        }

        // completed testing.
        public static async Task<List<md_Admins>?> GetInActivesAsync(int pageNumber)
        {
            List<md_Admins> admins = new List<md_Admins>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Admins_FUN_GetInActives] (@packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                admins.Add
                                    (
                                        new md_Admins
                                        (
                                            reader.GetInt32(reader.GetOrdinal("AdminId")),
                                            reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                            reader.GetString(reader.GetOrdinal("FullName")),
                                            reader.GetString(reader.GetOrdinal("UserName")),

                                            reader.IsDBNull(reader.GetOrdinal("ProfileImageURL")) ?
                                            null : reader.GetString(reader.GetOrdinal("ProfileImageURL")),

                                            reader.IsDBNull(reader.GetOrdinal("ProfileImageName")) ?
                                            null : reader.GetString(reader.GetOrdinal("ProfileImageName")),

                                            reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
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
                        "cls_Admins_D",
                        "GetInActivesAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return admins.Count > 0 ? admins : null;
        }

        // completed testing.
        public static async Task<md_AdminAuth?> GetByAuthAsync(string userNameOrEmail, string password)
        {
            md_AdminAuth? admin = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Admins_FUN_GetByAuth] (@userNameOrEmail, @password)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@userNameOrEmail", SqlDbType.NVarChar, 150) { Value = userNameOrEmail });
                        command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150) { Value = password });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                admin = new md_AdminAuth
                                    (
                                        reader.GetInt32(reader.GetOrdinal("AdminId")),
                                        reader.GetInt64(reader.GetOrdinal("Permissions")),

                                        reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                        null : reader.GetString(reader.GetOrdinal("Description")),

                                        reader.GetString(reader.GetOrdinal("FullName")),
                                        reader.GetString(reader.GetOrdinal("Email")),
                                        reader.GetString(reader.GetOrdinal("UserName")),
                                        reader.GetString(reader.GetOrdinal("Password")),

                                        reader.IsDBNull(reader.GetOrdinal("ProfileImageURL")) ?
                                        null : reader.GetString(reader.GetOrdinal("ProfileImageURL")),

                                        reader.IsDBNull(reader.GetOrdinal("ProfileImageName")) ?
                                        null : reader.GetString(reader.GetOrdinal("ProfileImageName")),

                                        reader.GetDateTime(reader.GetOrdinal("RegistrationDate"))
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
                        () => userNameOrEmail,
                        () => password
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "GetByAuthAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return admin;
        }

        // completed testing.
        public static async Task<md_Admin?> GetByIdAsync(int adminId)
        {
            md_Admin? admin = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Admins_FUN_GetById] (@adminId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                admin = new md_Admin
                                    (
                                        reader.GetInt32(reader.GetOrdinal("AdminId")),
                                        reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                        reader.GetInt64(reader.GetOrdinal("Permissions")),

                                        reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                        null : reader.GetString(reader.GetOrdinal("Description")),

                                        reader.GetString(reader.GetOrdinal("FullName")),
                                        reader.GetString(reader.GetOrdinal("Email")),
                                        reader.GetString(reader.GetOrdinal("UserName")),

                                        reader.IsDBNull(reader.GetOrdinal("ProfileImageURL")) ?
                                        null : reader.GetString(reader.GetOrdinal("ProfileImageURL")),

                                        reader.IsDBNull(reader.GetOrdinal("ProfileImageName")) ?
                                        null : reader.GetString(reader.GetOrdinal("ProfileImageName")),

                                        reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                                        reader.GetDateTime(reader.GetOrdinal("RegistrationDate"))
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
                        () => adminId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "GetByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return admin;
        }

        // completed testing.
        public static async Task<md_Admins?> GetByUserNameOrEmailAsync(string userNameOrEmail)
        {
            md_Admins? admin = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Admins_FUN_GetByUserNameOrEmail] (@userNameOrEmail)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@userNameOrEmail", SqlDbType.NVarChar, 150) { Value = userNameOrEmail });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                admin = new md_Admins
                                    (
                                        reader.GetInt32(reader.GetOrdinal("AdminId")),
                                        reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                        reader.GetString(reader.GetOrdinal("FullName")),
                                        reader.GetString(reader.GetOrdinal("UserName")),

                                        reader.IsDBNull(reader.GetOrdinal("ProfileImageURL")) ?
                                        null : reader.GetString(reader.GetOrdinal("ProfileImageURL")),

                                        reader.IsDBNull(reader.GetOrdinal("ProfileImageName")) ?
                                        null : reader.GetString(reader.GetOrdinal("ProfileImageName")),

                                        reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
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
                        () => userNameOrEmail
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "GetByUserNameOrEmailAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return admin;
        }

        // completed testing.
        public static async Task<bool> ClearPermissionsAsync(int adminId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Admins_SP_ClearPermissions]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = byAdmin });

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
                        () => adminId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "ClearPermissionsAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int adminId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Admins_SP_Delete]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = byAdmin });

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
                        () => adminId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "DeleteAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        // completed testing.
        public static async Task<bool> DeleteImageAsync(int adminId)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Admins_SP_DeleteImage]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });

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
                        () => adminId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "DeleteImageAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        public static async Task<int> NewAsync(md_NewAdmin admin)
        {
            int insertedId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Admins_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@permissions", SqlDbType.BigInt) { Value = admin.Permissions });
                        command.Parameters.Add(new SqlParameter("@fullName", SqlDbType.NVarChar, 25) { Value = admin.FullName });
                        command.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 150) { Value = admin.Email });
                        command.Parameters.Add(new SqlParameter("@userName", SqlDbType.NVarChar, 25) { Value = admin.UserName });
                        command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150) { Value = admin.Password });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = admin.ByAdmin });

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
                        () => admin.Permissions,
                        () => admin.FullName,
                        () => admin.Email,
                        () => admin.UserName,
                        () => admin.Password,
                        () => admin.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
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
        public static async Task<bool> SetAsActiveAsync(int adminId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Admins_SP_SetAsActive]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = byAdmin });

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
                        () => adminId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "SetAsActiveAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        // completed testing.
        public static async Task<bool> SetAsInActiveAsync(int adminId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Admins_SP_SetAsInActive]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = byAdmin });

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
                        () => adminId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "SetAsInActiveAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        // completed testing.
        public static async Task<bool> SetDescriptionAsync(int adminId, string description, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Admins_SP_SetDescription]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });
                        command.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 250) { Value = description });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = byAdmin });

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
                        () => adminId,
                        () => description,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "SetDescriptionAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        // completed testing.
        public static async Task<bool> SetEmailAsync(int adminId, string email)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Admins_SP_SetEmail]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });
                        command.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 150) { Value = email });

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
                        () => adminId,
                        () => email
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "SetEmailAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        // completed testing.
        public static async Task<bool> SetFullNameAsync(int adminId, string fullName)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Admins_SP_SetFullName]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });
                        command.Parameters.Add(new SqlParameter("@fullName", SqlDbType.NVarChar, 25) { Value = fullName });

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
                        () => adminId,
                        () => fullName
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "SetFullNameAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        // completed testing.
        public static async Task<bool> SetImageAsync(int adminId, string imageURL, string imageName)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Admins_SP_SetImage]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });
                        command.Parameters.Add(new SqlParameter("@imageURL", SqlDbType.NVarChar) { Value = imageURL });
                        command.Parameters.Add(new SqlParameter("@imageName", SqlDbType.NVarChar, 150) { Value = imageName });

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
                        () => adminId,
                        () => imageURL,
                        () => imageName
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "SetImageAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        // completed testing.
        public static async Task<bool> SetPasswordAsync(int adminId, string password)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Admins_SP_SetPassword]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });
                        command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 150) { Value = password });

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
                        () => adminId,
                        () => password
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "SetPasswordAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        // completed testing.
        public static async Task<bool> SetPermissionsAsync(int adminId, long permissions, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Admins_SP_SetPermissions]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });
                        command.Parameters.Add(new SqlParameter("@permissions", SqlDbType.BigInt) { Value = permissions });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = byAdmin });

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
                        () => adminId,
                        () => permissions,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "SetPermissionsAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        // completed testing.
        public static async Task<bool> SetUserNameAsync(int adminId, string userName)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Admins_SP_SetUserName]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@adminId", SqlDbType.Int) { Value = adminId });
                        command.Parameters.Add(new SqlParameter("@userName", SqlDbType.NVarChar, 25) { Value = userName });

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
                        () => adminId,
                        () => userName
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Admins_D",
                        "SetUserNameAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }
    }
}
