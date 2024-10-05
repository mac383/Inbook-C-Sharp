using Fekra_DataAccessLayer.models.Admins;
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
    public class cls_EnrolledSections_D
    {
        //completed testing.
        public static async Task<List<md_EnrolledSections>?> GetByEnrolledCourseAsync(int enrolledCourseId)
        {
            List<md_EnrolledSections> enrolledSections = new List<md_EnrolledSections>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[EnrolledSections_FUN_GetByEnrolledCourse] (@enrolledCourseId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@enrolledCourseId", SqlDbType.Int) { Value = enrolledCourseId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                enrolledSections.Add
                                    (
                                        new md_EnrolledSections
                                        (
                                            reader.GetInt32(reader.GetOrdinal("EnrolledSectionId")),
                                            reader.GetBoolean(reader.GetOrdinal("IsCompleted")),
                                            reader.GetByte(reader.GetOrdinal("CompletionRate")),
                                            reader.GetBoolean(reader.GetOrdinal("IsStarted")),
                                            reader.GetString(reader.GetOrdinal("SectionName")),

                                            reader.IsDBNull(reader.GetOrdinal("CoverURL")) ?
                                            null : reader.GetString(reader.GetOrdinal("CoverURL")),

                                            reader.GetInt32(reader.GetOrdinal("Lessons"))
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
                        () => enrolledCourseId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledSections_D",
                        "GetByEnrolledCourseAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return enrolledSections.Count > 0 ? enrolledSections : null;
        }

        //completed testing.
        public static async Task<md_EnrolledSection?> GetByIdAsync(int enrolledSectionId)
        {
            md_EnrolledSection? enrolledSection = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[EnrolledSections_FUN_GetById] (@enrolledSectionId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@enrolledSectionId", SqlDbType.Int) { Value = enrolledSectionId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                enrolledSection = new md_EnrolledSection
                                    (
                                        reader.GetInt32(reader.GetOrdinal("EnrolledSectionId")),
                                        reader.GetBoolean(reader.GetOrdinal("IsCompleted")),
                                        reader.GetByte(reader.GetOrdinal("CompletionRate")),

                                        reader.IsDBNull(reader.GetOrdinal("FileTitle")) ?
                                        null : reader.GetString(reader.GetOrdinal("FileTitle")),

                                        reader.IsDBNull(reader.GetOrdinal("FileURL")) ?
                                        null : reader.GetString(reader.GetOrdinal("FileURL")),

                                        reader.IsDBNull(reader.GetOrdinal("FileName")) ?
                                        null : reader.GetString(reader.GetOrdinal("FileName")),

                                        reader.GetString(reader.GetOrdinal("SectionName")),
                                        reader.GetString(reader.GetOrdinal("PlaylistURL")),

                                        reader.IsDBNull(reader.GetOrdinal("CoverURL")) ?
                                        null : reader.GetString(reader.GetOrdinal("CoverURL")),

                                        reader.GetInt32(reader.GetOrdinal("Lessons"))
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
                        "cls_EnrolledSections_D",
                        "GetByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return enrolledSection;
        }

        //completed testing.
        public static async Task<bool> DeleteFileAsync(int enrolledSectionId)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledSections_SP_DeleteFile]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@enrolledSectionId", SqlDbType.Int) { Value = enrolledSectionId });

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
                        () => enrolledSectionId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledSections_D",
                        "DeleteFileAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        //completed testing.
        public static async Task<bool> IsFileExistAsync(string fileName)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledSections_SP_IsFileExist]";

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
                        "cls_EnrolledSections_D",
                        "IsFileExistAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return isExist;
        }

        //completed testing.
        public static async Task<bool> IsSectionStartedAsync(int enrolledSectionId)
        {
            bool isStarted = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledSections_SP_IsSectionStarted]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@enrolledSectionId", SqlDbType.Int) { Value = enrolledSectionId });

                        SqlParameter returnParameter = command.Parameters.Add("returnValue", SqlDbType.Bit);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        isStarted = Convert.ToBoolean(returnParameter.Value);
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
                        "cls_EnrolledSections_D",
                        "IsSectionStartedAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return isStarted;
        }

        //completed testing.
        public static async Task<bool> SetAsStartedAsync(int enrolledSectionId)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledSections_SP_SetAsStarted]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@enrolledSectionId", SqlDbType.Int) { Value = enrolledSectionId });

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
                        () => enrolledSectionId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledSections_D",
                        "SetAsStartedAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        //completed testing.
        public static async Task<bool> SetFileAsync(int enrolledSectionId, string fileTitle, string fileURL, string fileName)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledSections_SP_SetFile]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@enrolledSectionId", SqlDbType.Int) { Value = enrolledSectionId });
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
                        () => enrolledSectionId,
                        () => fileTitle,
                        () => fileURL,
                        () => fileName
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledSections_D",
                        "SetFileAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        //completed testing.
        public static async Task<bool> SetFileTitleAsync(int enrolledSectionId, string title)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledSections_SP_SetFileTitle]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@enrolledSectionId", SqlDbType.Int) { Value = enrolledSectionId });
                        command.Parameters.Add(new SqlParameter("@fileTitle", SqlDbType.NVarChar, 250) { Value = title });

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
                        () => enrolledSectionId,
                        () => title
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledSections_D",
                        "SetFileTitleAsync",
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
