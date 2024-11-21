using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Typical_Questions;
using Fekra_DataAccessLayer.models.Materials;

namespace Fekra_DataAccessLayer.classes
{
    public class cls_TypicalQuestions_D
    {
        // completed testing.
        public static async Task<int> GetTypicalQuestionsPagesCountMaterialsAsync(int materialId)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[TypicalQuestions_FUN_PagesCount_Material] (@materialId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@materialId", SqlDbType.Int) { Value = materialId });

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
                        () => materialId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_TypicalQuestions_D",
                        "GetTypicalQuestionsPagesCountMaterialsAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<md_TypicalQuestion?> GetByIdAsync(int questionId)
        {
            md_TypicalQuestion? typicalQuestion = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[TypicalQuestions_FUN_GetById] (@questionId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@questionId", SqlDbType.Int) { Value = questionId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                typicalQuestion = new md_TypicalQuestion
                                    (
                                        reader.GetInt32(reader.GetOrdinal("QuestionId")),
                                        reader.GetString(reader.GetOrdinal("QuestionTitle")),
                                        reader.GetString(reader.GetOrdinal("FileURL")),
                                        reader.GetString(reader.GetOrdinal("FileName")),
                                        reader.GetString(reader.GetOrdinal("Type")),
                                        reader.GetString(reader.GetOrdinal("MaterialName")),
                                        reader.GetString(reader.GetOrdinal("BranchName")),
                                        reader.GetString(reader.GetOrdinal("AcademicYear"))
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
                        () => questionId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_TypicalQuestions_D",
                        "GetByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return typicalQuestion;
        }

        // completed testing.
        public static async Task<List<md_TypicalQuestion>?> GetByMaterialAsync(int materialId)
        {
            List<md_TypicalQuestion> typicalQuestions = new List<md_TypicalQuestion>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[TypicalQuestions_FUN_GetByMaterial] (@materialId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@materialId", SqlDbType.Int) { Value = materialId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                typicalQuestions.Add
                                    (
                                        new md_TypicalQuestion
                                        (
                                            reader.GetInt32(reader.GetOrdinal("QuestionId")),
                                            reader.GetString(reader.GetOrdinal("QuestionTitle")),
                                            reader.GetString(reader.GetOrdinal("FileURL")),
                                            reader.GetString(reader.GetOrdinal("FileName")),
                                            reader.GetString(reader.GetOrdinal("Type")),
                                            reader.GetString(reader.GetOrdinal("MaterialName")),
                                            reader.GetString(reader.GetOrdinal("BranchName")),
                                            reader.GetString(reader.GetOrdinal("AcademicYear"))
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
                        () => materialId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_TypicalQuestions_D",
                        "GetByMaterialAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return typicalQuestions.Count > 0 ? typicalQuestions : null;
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int questionId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[TypicalQuestions_SP_Delete]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@questionId", SqlDbType.Int) { Value = questionId });
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
                        () => questionId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_TypicalQuestions_D",
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
        public static async Task<bool> IsFileExistAsync(string fileName)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[TypicalQuestions_SP_IsFileExist]";

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
                        "cls_TypicalQuestions_D",
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
        public static async Task<int> NewAsync(md_NewTypicalQuestion question)
        {
            int insertedId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[TypicalQuestions_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@questionTitle", SqlDbType.NVarChar, 150) { Value = question.QuestionTitle });
                        command.Parameters.Add(new SqlParameter("@fileUrL", SqlDbType.NVarChar) { Value = question.FileURL });
                        command.Parameters.Add(new SqlParameter("@fileName", SqlDbType.NVarChar, 150) { Value = question.FileName });
                        command.Parameters.Add(new SqlParameter("@questionTypeId", SqlDbType.Int) { Value = question.QuestionTypeId });
                        command.Parameters.Add(new SqlParameter("@materialId", SqlDbType.Int) { Value = question.MaterialId });
                        command.Parameters.Add(new SqlParameter("@branchId", SqlDbType.Int) { Value = question.BranchId});
                        command.Parameters.Add(new SqlParameter("@academicYearId", SqlDbType.Int) { Value = question.AcademicYearId });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = question.ByAdmin });

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
                        () => question.QuestionTitle,
                        () => question.FileURL,
                        () => question.FileName,
                        () => question.QuestionTypeId,
                        () => question.MaterialId,
                        () => question.BranchId,
                        () => question.AcademicYearId,
                        () => question.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_TypicalQuestions_D",
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
        public static async Task<bool> UpdateAsync(md_UpdateTypicalQuestion question)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[TypicalQuestions_SP_Update]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@questionId", SqlDbType.Int) { Value = question.QuestionId });
                        command.Parameters.Add(new SqlParameter("@questionTitle", SqlDbType.NVarChar, 150) { Value = question.QuestionTitle });
                        command.Parameters.Add(new SqlParameter("@fileUrL", SqlDbType.NVarChar) { Value = question.FileURL });
                        command.Parameters.Add(new SqlParameter("@fileName", SqlDbType.NVarChar, 150) { Value = question.FileName });
                        command.Parameters.Add(new SqlParameter("@questionTypeId", SqlDbType.Int) { Value = question.QuestionTypeId });
                        command.Parameters.Add(new SqlParameter("@materialId", SqlDbType.Int) { Value = question.MaterialId });
                        command.Parameters.Add(new SqlParameter("@branchId", SqlDbType.Int) { Value = question.BranchId });
                        command.Parameters.Add(new SqlParameter("@academicYearId", SqlDbType.Int) { Value = question.AcademicYearId });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = question.ByAdmin });

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
                        () => question.QuestionId,
                        () => question.QuestionTitle,
                        () => question.FileURL,
                        () => question.FileName,
                        () => question.QuestionTypeId,
                        () => question.MaterialId,
                        () => question.BranchId,
                        () => question.AcademicYearId,
                        () => question.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_TypicalQuestions_D",
                        "UpdateAsync",
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
