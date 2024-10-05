using Fekra_DataAccessLayer.models.Enrolled_Lessons;
using Fekra_DataAccessLayer.models.Enrolled_Sections;
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
    public class cls_EnrolledLessons_D
    {
        // completed testing.
        public static async Task<List<md_EnrolledLessons>?> GetByEnrolledSectionAsync(int enrolledSectionId)
        {
            List<md_EnrolledLessons> enrolledLessons = new List<md_EnrolledLessons>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[EnrolledLessons_FUN_GetByEnrolledSection] (@enrolledSectionId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@enrolledSectionId", SqlDbType.Int) { Value = enrolledSectionId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                enrolledLessons.Add
                                    (
                                        new md_EnrolledLessons
                                        (
                                            reader.GetInt32(reader.GetOrdinal("EnrolledLessonId")),
                                            reader.GetString(reader.GetOrdinal("LessonTitle")),
                                            
                                            reader.IsDBNull(reader.GetOrdinal("Note")) ?
                                            null : reader.GetString(reader.GetOrdinal("Note")),

                                            reader.GetBoolean(reader.GetOrdinal("IsCompleted")),

                                            reader.IsDBNull(reader.GetOrdinal("HasFile")) ?
                                            null : reader.GetBoolean(reader.GetOrdinal("HasFile"))
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
                        () => enrolledSectionId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledLessons_D",
                        "GetByEnrolledSectionAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return enrolledLessons.Count > 0 ? enrolledLessons : null;
        }

        // completed testing.
        public static async Task<md_EnrolledLesson?> GetByIdAsync(int enrolledLessonId)
        {
            md_EnrolledLesson? enrolledLesson = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[EnrolledLessons_FUN_GetById] (@enrolledLessonId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@enrolledLessonId", SqlDbType.Int) { Value = enrolledLessonId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                enrolledLesson = new md_EnrolledLesson
                                    (
                                        reader.GetInt32(reader.GetOrdinal("EnrolledLessonId")),
                                        reader.GetString(reader.GetOrdinal("LessonTitle")),
                                        reader.GetString(reader.GetOrdinal("VideoURL")),

                                        reader.IsDBNull(reader.GetOrdinal("Note")) ?
                                        null : reader.GetString(reader.GetOrdinal("Note")),

                                        reader.GetBoolean(reader.GetOrdinal("IsCompleted")),

                                        reader.IsDBNull(reader.GetOrdinal("FileTitle")) ?
                                        null : reader.GetString(reader.GetOrdinal("FileTitle")),

                                        reader.IsDBNull(reader.GetOrdinal("FileURL")) ?
                                        null : reader.GetString(reader.GetOrdinal("FileURL")),

                                        reader.IsDBNull(reader.GetOrdinal("FileName")) ?
                                        null : reader.GetString(reader.GetOrdinal("FileName"))
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
                        () => enrolledLessonId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledLessons_D",
                        "GetByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return enrolledLesson;
        }

        // completed testing.
        public static async Task<bool> DeleteFileAsync(int enrolledLessonId)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledLessons_SP_DeleteFile]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@enrolledLessonId", SqlDbType.Int) { Value = enrolledLessonId });

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
                        () => enrolledLessonId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledLessons_D",
                        "DeleteFileAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        // completed testing.
        public static async Task<bool> DeleteNoteAsync(int enrolledLessonId)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledLessons_SP_DeleteNote]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@enrolledLessonId", SqlDbType.Int) { Value = enrolledLessonId });

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
                        () => enrolledLessonId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledLessons_D",
                        "DeleteNoteAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        // completed testing.
        public static async Task<bool> IsFileExistAsync(string fileName)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledLessons_SP_IsFileExist]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@fileName", SqlDbType.NVarChar, 150) { Value = fileName });

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
                        () => fileName
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledLessons_D",
                        "IsFileExistAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return isExist;
        }

        // completed testing.
        public static async Task<bool> SetAsCompletedAsync(int enrolledLessonId)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledLessons_SP_SetAsCompleted]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@enrolledLessonId", SqlDbType.Int) { Value = enrolledLessonId });

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
                        () => enrolledLessonId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledLessons_D",
                        "SetAsCompletedAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        // completed testing.
        public static async Task<bool> SetFileAsync(int enrolledLessonId, string fileTitle, string fileURL, string fileName)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledLessons_SP_SetFile]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@enrolledLessonId", SqlDbType.Int) { Value = enrolledLessonId });
                        command.Parameters.Add(new SqlParameter("@fileTitle", SqlDbType.NVarChar, 250) { Value = fileTitle });
                        command.Parameters.Add(new SqlParameter("@fileURL", SqlDbType.NVarChar) { Value = fileURL });
                        command.Parameters.Add(new SqlParameter("@fileName", SqlDbType.NVarChar, 150) { Value = fileName });

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
                        () => enrolledLessonId,
                        () => fileTitle,
                        () => fileURL,
                        () => fileName
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledLessons_D",
                        "SetFileAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        // completed testing.
        public static async Task<bool> SetNoteAsync(int enrolledLessonId, string note)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledLessons_SP_SetNote]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@enrolledLessonId", SqlDbType.Int) { Value = enrolledLessonId });
                        command.Parameters.Add(new SqlParameter("@note", SqlDbType.NVarChar, 250) { Value = note });

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
                        () => enrolledLessonId,
                        () => note
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledLessons_D",
                        "SetNoteAsync",
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
