using Fekra_DataAccessLayer.models.AI_Conversations;
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
    public class cls_AIConversations_D
    {
        public static async Task<int> AddNewConversationAsync(int userId)
        {
            int conversationId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[AIConversations_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = userId });

                        await connection.OpenAsync();

                        object? returnValue = await command.ExecuteNonQueryAsync();

                        if (returnValue != null && returnValue != DBNull.Value)
                            conversationId = Convert.ToInt32(returnValue);
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
                        "cls_AIConversations_D",
                        "AddNewConversationAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return -1;
            }

            return conversationId;
        }

        public static async Task<bool> UpdateConversationTitleAsync(int conversationId, string newTitle)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[AIConversations_SP_UpdateTitle]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@ConversationId", SqlDbType.Int) { Value = conversationId });
                        command.Parameters.Add(new SqlParameter("@NewTitle", SqlDbType.NVarChar, 255) { Value = newTitle });

                        await connection.OpenAsync();

                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        isSuccess = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                (
                    () => conversationId,
                    () => newTitle
                );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AIConversations_D",
                        "UpdateConversationTitleAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return isSuccess;
        }

        public static async Task<List<md_Conversations>?> GetAllConversationsAsync(int userId)
        {
            List<md_Conversations> conversations = new List<md_Conversations>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[AIConversations_FUN_GetAll](@UserId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = userId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                conversations.Add
                                (
                                    new md_Conversations
                                    (
                                        reader.GetInt32(reader.GetOrdinal("ConversationId")),
                                        reader.GetString(reader.GetOrdinal("Title")),
                                        reader.GetDateTime(reader.GetOrdinal("LastInteraction"))
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
                        "cls_AIConversations_D",
                        "GetAllConversationsAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return conversations.Count > 0 ? conversations : null;
        }

        public static async Task<bool> DeleteConversationAsync(int conversationId)
        {
            bool isSuccess = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[AIConversations_SP_Delete]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@ConversationId", SqlDbType.Int) { Value = conversationId });

                        await connection.OpenAsync();

                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        isSuccess = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                (
                    () => conversationId
                );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AIConversations_D",
                        "DeleteConversationAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return isSuccess;
        }

        public static async Task<string> GetConversationSummaryAsync(int conversationId)
        {
            string? summary = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[AIConversations_FUN_GetSummary](@ConversationId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@ConversationId", SqlDbType.Int) { Value = conversationId });

                        await connection.OpenAsync();

                        object? returnValue = await command.ExecuteScalarAsync();
                        summary = returnValue != null && returnValue != DBNull.Value ? returnValue.ToString() : null;
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                (
                    () => conversationId
                );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AIConversations_D",
                        "GetConversationSummaryAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return "";
            }

            return summary ?? "";
        }

    }
}
