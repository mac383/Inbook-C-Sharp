using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fekra_DataAccessLayer.classes
{
    public class cls_Errors_D
    {

        // completed testing.
        public static string GetParams(params Expression<Func<object?>>[] expressions)
        {
            var resultDict = new Dictionary<string, string>();

            foreach (var expression in expressions)
            {
                MemberExpression? memberExpression = null;

                if (expression.Body is MemberExpression)
                {
                    memberExpression = (MemberExpression)expression.Body;
                }
                else if (expression.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression)
                {
                    memberExpression = (MemberExpression)unaryExpression.Operand;
                }

                if (memberExpression != null)
                {
                    string parameterName = memberExpression.Member.Name;
                    object? parameterValue = expression.Compile().Invoke();
                    string valueString = parameterValue == null ? "null" : parameterValue.ToString();
                    resultDict[parameterName] = valueString;
                }
            }

            // Convert the dictionary to JSON
            return JsonSerializer.Serialize(resultDict, new JsonSerializerOptions { WriteIndented = true });

            /*
               INVOKE
               MyParams = GetParams
               (
                   () => var1,
                   () => var2,
                   () => var3
               );
            */

        }

        // completed testing.
        public static async Task<bool> LogErrorAsync(md_NewError error)
        {
            int insertedId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Errors_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@errorMessage", SqlDbType.NVarChar, 1000) { Value = error.Message });
                        command.Parameters.Add(new SqlParameter("@layer", SqlDbType.NVarChar, 100) { Value = error.Layer });
                        command.Parameters.Add(new SqlParameter("@source", SqlDbType.NVarChar, 100) { Value = error.Source });
                        command.Parameters.Add(new SqlParameter("@class", SqlDbType.NVarChar, 100) { Value = error.Class });
                        command.Parameters.Add(new SqlParameter("@method", SqlDbType.NVarChar, 100) { Value = error.Method });
                        command.Parameters.Add(new SqlParameter("@stackTrace", SqlDbType.NVarChar, 1000) { Value = error.StackTrace });
                        command.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 250) { Value = error.Description ?? (object)DBNull.Value });
                        command.Parameters.Add(new SqlParameter("@params", SqlDbType.NVarChar) { Value = error.Params ?? (object)DBNull.Value });


                        SqlParameter returnParameter = command.Parameters.Add("returnValue", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        insertedId = (int)returnParameter.Value;
                    }
                }
            }
            catch
            {
                return false;
            }

            return insertedId > 0;
        }

        // completed testing.
        public static async Task<bool> SetAsHandledAsync(int errorId, int byAdmin)
        {

            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Errors_SP_SetAsHandled]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@errorId", SqlDbType.Int) { Value = errorId });
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
                        () => errorId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Errors_D",
                        "SetAsHandled",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        // completed testing.
        public static async Task<bool> SetDescriptionAsync(int errorId, string description, int byAdmin)
        {

            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Errors_SP_SetDescription]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@errorId", SqlDbType.Int) { Value = errorId });
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
                        () => errorId,
                        () => description,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Errors_D",
                        "SetDescription",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        // completed testing.
        public static async Task<int> GetPagesCount_All_Async()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Errors_FUN_PagesCount_All] ()";

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
                        "cls_Errors_D",
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
        public static async Task<int> GetPagesCount_Handled_Async()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Errors_FUN_PagesCount_Handled] ()";

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
                        "cls_Errors_D",
                        "GetPagesCount_Handled_Async",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<int> GetPagesCount_NotHandled_Async()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Errors_FUN_PagesCount_NotHandled] ()";

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
                        "cls_Errors_D",
                        "GetPagesCount_NotHandled_Async",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<List<md_Errors>?> GetAll(int pageNumber)
        {
            List<md_Errors> errors = new List<md_Errors>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Errors_FUN_GetAll] (@packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                errors.Add
                                    (
                                        new md_Errors
                                        (
                                            reader.GetInt32(reader.GetOrdinal("ErrorId")),
                                            reader.GetDateTime(reader.GetOrdinal("ErrorDate")),
                                            reader.GetString(reader.GetOrdinal("ErrorMessage")),
                                            reader.GetString(reader.GetOrdinal("Layer")),
                                            reader.GetString(reader.GetOrdinal("Class")),
                                            reader.GetBoolean(reader.GetOrdinal("IsHandled")),
                                            reader.GetString(reader.GetOrdinal("Method"))
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
                        "cls_Errors_D",
                        "GetAll",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return errors.Count > 0 ? errors : null;
        }

        // completed testing.
        public static async Task<List<md_Errors>?> GetHandledErrorsAsync(int pageNumber)
        {
            List<md_Errors> errors = new List<md_Errors>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Errors_FUN_GetHandled] (@packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                errors.Add
                                    (
                                        new md_Errors
                                        (
                                            reader.GetInt32(reader.GetOrdinal("ErrorId")),
                                            reader.GetDateTime(reader.GetOrdinal("ErrorDate")),
                                            reader.GetString(reader.GetOrdinal("ErrorMessage")),
                                            reader.GetString(reader.GetOrdinal("Layer")),
                                            reader.GetString(reader.GetOrdinal("Class")),
                                            reader.GetBoolean(reader.GetOrdinal("IsHandled")),
                                            reader.GetString(reader.GetOrdinal("Method"))
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
                        "cls_Errors_D",
                        "GetHandledErrors",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return errors.Count > 0 ? errors : null;
        }

        // completed testing.
        public static async Task<List<md_Errors>?> GetNotHandledErrorsAsync(int pageNumber)
        {
            List<md_Errors> errors = new List<md_Errors>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Errors_FUN_GetNotHandled] (@packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                errors.Add
                                    (
                                        new md_Errors
                                        (
                                            reader.GetInt32(reader.GetOrdinal("ErrorId")),
                                            reader.GetDateTime(reader.GetOrdinal("ErrorDate")),
                                            reader.GetString(reader.GetOrdinal("ErrorMessage")),
                                            reader.GetString(reader.GetOrdinal("Layer")),
                                            reader.GetString(reader.GetOrdinal("Class")),
                                            reader.GetBoolean(reader.GetOrdinal("IsHandled")),
                                            reader.GetString(reader.GetOrdinal("Method"))
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
                        "cls_Errors_D",
                        "GetNotHandledErrorsAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return errors.Count > 0 ? errors : null;
        }

        // completed testing.
        public static async Task<md_Error?> GetById(int errorId)
        {
            md_Error? error = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Errors_FUN_GetById] (@id)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = errorId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                error = new md_Error
                                    (
                                        reader.GetInt32(reader.GetOrdinal("ErrorId")),
                                        reader.GetDateTime(reader.GetOrdinal("ErrorDate")),
                                        reader.GetString(reader.GetOrdinal("ErrorMessage")),
                                        reader.GetString(reader.GetOrdinal("Layer")),
                                        reader.GetString(reader.GetOrdinal("Source")),
                                        reader.GetString(reader.GetOrdinal("Class")),
                                        reader.GetString(reader.GetOrdinal("Method")),
                                        reader.GetString(reader.GetOrdinal("StackTrace")),
                                        reader.GetBoolean(reader.GetOrdinal("IsHandled")),
                                        reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                                        reader.IsDBNull(reader.GetOrdinal("Params")) ? null : reader.GetString(reader.GetOrdinal("Params"))
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
                        () => errorId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Errors_D",
                        "GetById",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return error;
        }

        // completed testing.
        public static async Task<md_Error?> GetByKey(string key)
        {
            md_Error? error = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Errors_FUN_GetByKey] (@errorKey)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@errorKey", SqlDbType.NVarChar, 25) { Value = key });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                error = new md_Error
                                    (
                                        reader.GetInt32(reader.GetOrdinal("ErrorId")),
                                        reader.GetDateTime(reader.GetOrdinal("ErrorDate")),
                                        reader.GetString(reader.GetOrdinal("ErrorMessage")),
                                        reader.GetString(reader.GetOrdinal("Layer")),
                                        reader.GetString(reader.GetOrdinal("Source")),
                                        reader.GetString(reader.GetOrdinal("Class")),
                                        reader.GetString(reader.GetOrdinal("Method")),
                                        reader.GetString(reader.GetOrdinal("StackTrace")),
                                        reader.GetBoolean(reader.GetOrdinal("IsHandled")),
                                        reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                                        reader.IsDBNull(reader.GetOrdinal("Params")) ? null : reader.GetString(reader.GetOrdinal("Params"))
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
                        () => key
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Errors_D",
                        "GetByKey",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return error;
        }

    }
}
