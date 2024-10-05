using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Enrolled_Courses;
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
    public class cls_EnrolledCourses_D
    {
        //completed testing.
        public static async Task<List<md_EnrolledCourses>?> GetByUserAsync(int userId)
        {
            List<md_EnrolledCourses> courses = new List<md_EnrolledCourses>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[EnrolledCourses_FUN_GetByUser] (@userId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = userId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                courses.Add
                                    (
                                        new md_EnrolledCourses
                                        (
                                            reader.GetInt32(reader.GetOrdinal("EnrolledCourseId")),
                                            reader.GetString(reader.GetOrdinal("CourseTitle")),

                                            reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                            null : reader.GetString(reader.GetOrdinal("Description")),

                                            reader.GetString(reader.GetOrdinal("TeacherName")),

                                            reader.IsDBNull(reader.GetOrdinal("CoverURL")) ?
                                            null : reader.GetString(reader.GetOrdinal("CoverURL")),

                                            reader.GetBoolean(reader.GetOrdinal("IsCompleted")),
                                            reader.GetByte(reader.GetOrdinal("CompletionRate"))
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
                        () => userId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledCourses_D",
                        "GetByUserAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return courses.Count > 0 ? courses : null;
        }

        //completed testing.
        public static async Task<md_EnrolledCourse?> GetByIdAsync(int enrolledCourseId)
        {
            md_EnrolledCourse? course = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[EnrolledCourses_FUN_GetById] (@enrolledCourseId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@enrolledCourseId", SqlDbType.Int) { Value = enrolledCourseId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                course = new md_EnrolledCourse
                                    (
                                        reader.GetInt32(reader.GetOrdinal("EnrolledCourseId")),
                                        reader.GetString(reader.GetOrdinal("CourseTitle")),

                                        reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                        null : reader.GetString(reader.GetOrdinal("Description")),

                                        reader.GetString(reader.GetOrdinal("TeacherName")),

                                        reader.IsDBNull(reader.GetOrdinal("CoverURL")) ?
                                        null : reader.GetString(reader.GetOrdinal("CoverURL")),

                                        reader.IsDBNull(reader.GetOrdinal("CoverName")) ?
                                        null : reader.GetString(reader.GetOrdinal("CoverName")),

                                        reader.GetString(reader.GetOrdinal("BranchName")),
                                        reader.GetBoolean(reader.GetOrdinal("IsCompleted")),
                                        reader.GetByte(reader.GetOrdinal("CompletionRate"))
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
                        "cls_EnrolledCourses_D",
                        "GetByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return course;
        }

        //completed testing.
        public static async Task<bool> DeleteAsync(int enrolledCourseId)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledCourses_SP_Delete]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@enoleedCourseId", SqlDbType.Int) { Value = enrolledCourseId });

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
                        () => enrolledCourseId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledCourses_D",
                        "DeleteAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        //completed testing.
        public static async Task<bool> IsUserEnrolledToCourseAsync(int userId, int courseId)
        {
            bool isEnrolled = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledCourses_SP_IsUserEnrolledToCourse]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = userId });
                        command.Parameters.Add(new SqlParameter("@courseId", SqlDbType.Int) { Value = courseId });

                        SqlParameter returnParameter = command.Parameters.Add("returnValue", SqlDbType.Bit);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        isEnrolled = Convert.ToBoolean(returnParameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                    (
                        () => userId,
                        () => courseId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledCourses_D",
                        "IsUserEnrolledToCourseAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return isEnrolled;
        }

        //completed testing.
        public static async Task<int> NewAsync(md_NewEnrolledCourse course)
        {
            int insertedId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[EnrolledCourses_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = course.UserId });
                        command.Parameters.Add(new SqlParameter("@courseId", SqlDbType.Int) { Value = course.CourseId });

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
                        () => course.UserId,
                        () => course.CourseId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_EnrolledCourses_D",
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
