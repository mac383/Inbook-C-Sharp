using Fekra_DataAccessLayer.models;
using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.models.General_Questions;
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
    public class cls_GeneralQuestions_D
    {
        // completed testing.
        public static async Task<List<md_GeneralQuestions>?> GetAllAsync()
        {
            List<md_GeneralQuestions> questions = new List<md_GeneralQuestions>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[GeneralQuestions_FUN_GetAll] ()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                questions.Add
                                    (
                                        new md_GeneralQuestions
                                        (
                                            reader.GetInt32(reader.GetOrdinal("QuestionId")),
                                            reader.GetString(reader.GetOrdinal("Question")),
                                            reader.GetString(reader.GetOrdinal("Answer"))
                                        )
                                    );
                            }
                        }
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
                        "cls_GeneralQuestions_D",
                        "GetAllAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return null;
            }

            return questions.Count > 0 ? questions : null;
        }

        // completed testing.
        public static async Task<md_GeneralQuestions?> GetByIdAsync(int questionId)
        {
            md_GeneralQuestions? question = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[GeneralQuestions_FUN_GetById] (@questionId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@questionId", SqlDbType.Int) { Value = questionId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                question = new md_GeneralQuestions
                                    (
                                        reader.GetInt32(reader.GetOrdinal("QuestionId")),
                                        reader.GetString(reader.GetOrdinal("Question")),
                                        reader.GetString(reader.GetOrdinal("Answer"))
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
                        "cls_GeneralQuestions_D",
                        "GetByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return question;
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewGeneralQuestion question)
        {
            int insertedId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[GeneralQuestions_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@question", SqlDbType.NVarChar, 500) { Value = question.Question });
                        command.Parameters.Add(new SqlParameter("@answer", SqlDbType.NVarChar) { Value = question.Answer });
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
                        () => question.Question,
                        () => question.Answer,
                        () => question.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_GeneralQuestions_D",
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
        public static async Task<int> UpdateAsync(md_UpdateGeneralQuestion question)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[GeneralQuestions_SP_Update]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@questionId", SqlDbType.Int) { Value = question.QuestionId });
                        command.Parameters.Add(new SqlParameter("@question", SqlDbType.NVarChar, 500) { Value = question.Question });
                        command.Parameters.Add(new SqlParameter("@answer", SqlDbType.NVarChar) { Value = question.Answer });
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
                        () => question.Question,
                        () => question.Answer,
                        () => question.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_GeneralQuestions_D",
                        "UpdateAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return -1;
            }

            return rowsAffected;
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int questionId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[GeneralQuestions_SP_Delete]";

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
                        "cls_GeneralQuestions_D",
                        "DeleteAsync",
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
