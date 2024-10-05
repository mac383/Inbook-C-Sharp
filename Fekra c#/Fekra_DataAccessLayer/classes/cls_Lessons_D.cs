using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.models.Lessons;
using Fekra_DataAccessLayer.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Fekra_DataAccessLayer.classes
{
    public class cls_Lessons_D
    {
        // completed testing.
        public static async Task<List<md_Lessons>?> GetBySectionAsync(int sectionId)
        {
            List<md_Lessons> lessons = new List<md_Lessons>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Lessons_FUN_GetBySection] (@sectionId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@sectionId", SqlDbType.Int) { Value = sectionId });
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lessons.Add
                                    (
                                        new md_Lessons
                                        (
                                            reader.GetInt32(reader.GetOrdinal("LessonId")),
                                            reader.GetString(reader.GetOrdinal("LessonTitle")),
                                            reader.GetString(reader.GetOrdinal("SectionName"))
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
                        () => sectionId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Lessons_D",
                        "GetBySectionAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return lessons.Count > 0 ? lessons : null;
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int lessonId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Lessons_SP_Delete]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@lessonId", SqlDbType.Int) { Value = lessonId });
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
                        () => lessonId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Lessons_D",
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
        public static async Task<int> NewAsync(md_CompleteLesson lesson)
        {
            int insertedId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Lessons_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@lessonTitle", SqlDbType.NVarChar, 250) { Value = lesson.LessonTitle });
                        command.Parameters.Add(new SqlParameter("@videoURL", SqlDbType.NVarChar) { Value = lesson.VideoURL });
                        command.Parameters.Add(new SqlParameter("@videoId", SqlDbType.NVarChar, 150) { Value = lesson.VideoId });
                        command.Parameters.Add(new SqlParameter("@sectionId", SqlDbType.Int) { Value = lesson.SectionId });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = lesson.ByAdmin });

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
                        () => lesson.LessonTitle,
                        () => lesson.VideoURL,
                        () => lesson.VideoId,
                        () => lesson.SectionId,
                        () => lesson.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Lessons_D",
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
        public static async Task<bool> UpdateTitleAsync(int lessonId, string title, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Lessons_SP_UpdateTitle]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@lessonId", SqlDbType.Int) { Value = lessonId });
                        command.Parameters.Add(new SqlParameter("@lessonTitle", SqlDbType.NVarChar, 250) { Value = title });
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
                        () => lessonId,
                        () => title,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Lessons_D",
                        "UpdateTitleAsync",
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
