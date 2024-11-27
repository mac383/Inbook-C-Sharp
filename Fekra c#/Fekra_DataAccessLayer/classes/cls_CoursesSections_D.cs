using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Courses_Sections;
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
    public class cls_CoursesSections_D
    {
        // completed testing.
        public static async Task<List<md_CoursesSections>?> GetSectionsByCourseAsync(int courseId)
        {
            List<md_CoursesSections> sections = new List<md_CoursesSections>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[CoursesSections_FUN_GetByCourse] (@courseId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@courseId", SqlDbType.Int) { Value = courseId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                sections.Add
                                    (
                                        new md_CoursesSections
                                        (
                                            reader.GetInt32(reader.GetOrdinal("SectionId")),
                                            reader.GetString(reader.GetOrdinal("SectionName")),

                                            reader.IsDBNull(reader.GetOrdinal("CoverURL")) ?
                                            null : reader.GetString(reader.GetOrdinal("CoverURL")),

                                            reader.IsDBNull(reader.GetOrdinal("CoverName")) ?
                                            null : reader.GetString(reader.GetOrdinal("CoverName")),

                                            reader.GetInt32(reader.GetOrdinal("LessonsCount"))
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
                        () => courseId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_CoursesSections_D",
                        "GetSectionsByCourseAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return sections.Count > 0 ? sections : null;
        }

        // completed testing.
        public static async Task<md_CourseSection?> GetByIdAsync(int sectionId)
        {
            md_CourseSection? section = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[CoursesSections_FUN_GetById] (@sectionId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@sectionId", SqlDbType.Int) { Value = sectionId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                section = new md_CourseSection
                                    (
                                        reader.GetInt32(reader.GetOrdinal("SectionId")),

                                        reader.GetString(reader.GetOrdinal("SectionName")),
                                        reader.GetString(reader.GetOrdinal("PlaylistURL")),
                                        reader.GetString(reader.GetOrdinal("PlaylistId")),

                                        reader.IsDBNull(reader.GetOrdinal("CoverURL")) ?
                                        null : reader.GetString(reader.GetOrdinal("CoverURL")),

                                        reader.IsDBNull(reader.GetOrdinal("CoverName")) ?
                                        null : reader.GetString(reader.GetOrdinal("CoverName")),

                                        reader.GetString(reader.GetOrdinal("CourseTitle"))
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
                        () => sectionId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_CoursesSections_D",
                        "GetByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return section;
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int sectionId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[CoursesSections_SP_Delete]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@sectionId", SqlDbType.Int) { Value = sectionId });
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
                        () => sectionId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_CoursesSections_D",
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
        public static async Task<bool> DeleteCoverAsync(int sectionId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[CoursesSections_SP_DeleteCover]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@sectionId", SqlDbType.Int) { Value = sectionId });
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
                        () => sectionId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_CoursesSections_D",
                        "DeleteCoverAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        // completed testing.
        public static async Task<bool> IsHasRelationsAsync(int sectionId)
        {
            bool isHasRelations = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[CoursesSections_SP_HasRelations]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@sectionId", SqlDbType.Int) { Value = sectionId });

                        SqlParameter returnParameter = command.Parameters.Add("returnValue", SqlDbType.Bit);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        isHasRelations = Convert.ToBoolean(returnParameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                    (
                        () => sectionId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_CoursesSections_D",
                        "IsHasRelationsAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return isHasRelations;
        }

        // completed testing.
        public static async Task<bool> IsCoverExistAsync(string coverName)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[CoursesSections_SP_IsCoverExist]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@coverName", SqlDbType.NVarChar, 150) { Value = coverName });

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
                        () => coverName
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_CoursesSections_D",
                        "IsCoverExistAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return isExist;
        }

        // completed testing.
        public static async Task<bool> SetCoverAsync(int sectionId, string imageURL, string imageName, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[CoursesSections_SP_SetCover]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@sectionId", SqlDbType.Int) { Value = sectionId });
                        command.Parameters.Add(new SqlParameter("@coverURL", SqlDbType.NVarChar) { Value = imageURL });
                        command.Parameters.Add(new SqlParameter("@coverName", SqlDbType.NVarChar, 150) { Value = imageName });
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
                        () => sectionId,
                        () => imageURL,
                        () => imageName,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_CoursesSections_D",
                        "SetCoverAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        // completed testing.
        public static async Task<bool> SetSectionNameAsync(int sectionId, string sectionName, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[CoursesSections_SP_SetSectionName]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@sectionId", SqlDbType.Int) { Value = sectionId });
                        command.Parameters.Add(new SqlParameter("@sectionName", SqlDbType.NVarChar, 250) { Value = sectionName });
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
                        () => sectionId,
                        () => sectionName,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_CoursesSections_D",
                        "SetSectionNameAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        // completed testing.
        public static async Task<int> NewAsync(md_CompleteCourseSection section)
        {
            int insertedId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[CoursesSections_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@sectionName", SqlDbType.NVarChar, 250) { Value = section.SectionName });
                        command.Parameters.Add(new SqlParameter("@playlistURL", SqlDbType.NVarChar) { Value = section.PlaylistURL });
                        command.Parameters.Add(new SqlParameter("@playlistId", SqlDbType.NVarChar, 150) { Value = section.PlaylistId });
                        command.Parameters.Add(new SqlParameter("@courseId", SqlDbType.Int) { Value = section.CourseId });
                        command.Parameters.Add(new SqlParameter("@lessons", SqlDbType.Structured) { Value = section.Lessons ?? (object)DBNull.Value });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = section.ByAdmin });

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
                        () => section.SectionName,
                        () => section.PlaylistURL,
                        () => section.PlaylistId,
                        () => section.CourseId,
                        () => section.Lessons.Rows,
                        () => section.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_CoursesSections_D",
                        "NewAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return -1;
            }

            return insertedId;
        }
    }
}
