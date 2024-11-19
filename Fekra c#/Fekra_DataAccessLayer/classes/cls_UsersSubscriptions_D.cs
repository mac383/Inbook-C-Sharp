using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.models.Users_Subscriptions;
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
    public class cls_UsersSubscriptions_D
    {
        // completed testing.
        public static async Task<int> GetActivesCountAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[UsersSubscription_FUN_GetActivesCount]()";

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
                        "cls_UsersSubscriptions_D",
                        "GetActivesCount",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[UsersSubscription_FUN_GetCount]()";

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
                        "cls_UsersSubscriptions_D",
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
        public static async Task<int> GetInActivesCountAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[UsersSubscription_FUN_GetInActivesCount]()";

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
                        "cls_UsersSubscriptions_D",
                        "GetInActivesCount",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<int> GetUsersSubscriptionsPagesCountActiveAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[UsersSubscription_FUN_GetPages_Active] ()";

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
                        "cls_UsersSubscriptions_D",
                        "GetUsersSubscriptionsPagesCountActiveAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<int> GetUsersSubscriptionsPagesCountInActivesAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[UsersSubscription_FUN_GetPages_InActive] ()";

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
                        "cls_UsersSubscriptions_D",
                        "GetUsersSubscriptionsPagesCountInActivesAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<List<md_UsersSubscriptions>?> GetActivesAsync(int pageNumber)
        {
            List<md_UsersSubscriptions> subscriptions = new List<md_UsersSubscriptions>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[UsersSubscriptions_FUN_GetActives] (@packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                subscriptions.Add
                                    (
                                        new md_UsersSubscriptions
                                        (
                                            reader.GetInt32(reader.GetOrdinal("SubscriptionId")),
                                            reader.GetString(reader.GetOrdinal("PlanName")),
                                            reader.GetString(reader.GetOrdinal("BranchName")),
                                            reader.GetString(reader.GetOrdinal("UserName")),
                                            Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Price"))),
                                            reader.GetByte(reader.GetOrdinal("Discount")),
                                            Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("FinalPrice"))),
                                            reader.GetDateTime(reader.GetOrdinal("SubscriptionStart")),
                                            reader.GetDateTime(reader.GetOrdinal("SubscriptionEnd")),
                                            reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                            reader.GetInt32(reader.GetOrdinal("UserId"))
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
                        "cls_UsersSubscriptions_D",
                        "GetActivesAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return subscriptions.Count > 0 ? subscriptions : null;
        }

        // completed testing.
        public static async Task<List<md_UsersSubscriptions>?> GetInActivesAsync(int pageNumber)
        {
            List<md_UsersSubscriptions> subscriptions = new List<md_UsersSubscriptions>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[UsersSubscriptions_FUN_GetInActives] (@packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                subscriptions.Add
                                    (
                                        new md_UsersSubscriptions
                                        (
                                            reader.GetInt32(reader.GetOrdinal("SubscriptionId")),
                                            reader.GetString(reader.GetOrdinal("PlanName")),
                                            reader.GetString(reader.GetOrdinal("BranchName")),
                                            reader.GetString(reader.GetOrdinal("UserName")),
                                            Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Price"))),
                                            reader.GetByte(reader.GetOrdinal("Discount")),
                                            Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("FinalPrice"))),
                                            reader.GetDateTime(reader.GetOrdinal("SubscriptionStart")),
                                            reader.GetDateTime(reader.GetOrdinal("SubscriptionEnd")),
                                            reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                            reader.GetInt32(reader.GetOrdinal("UserId"))
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
                        "cls_UsersSubscriptions_D",
                        "GetInActivesAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return subscriptions.Count > 0 ? subscriptions : null;
        }

        // completed testing.
        public static async Task<md_UserSubscription?> GetActiveSubscriptionByUserAsync(int userId)
        {
            md_UserSubscription? subscription = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[UsersSubscriptions_FUN_GetActiveSubscriptionByUserId] (@userId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = userId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                subscription = new md_UserSubscription
                                    (
                                        reader.GetInt32(reader.GetOrdinal("SubscriptionId")),

                                        reader.IsDBNull(reader.GetOrdinal("PaymentId")) ? null :
                                        reader.GetInt32(reader.GetOrdinal("PaymentId")),

                                        reader.GetString(reader.GetOrdinal("PlanName")),
                                        Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Price"))),
                                        reader.GetByte(reader.GetOrdinal("Discount")),
                                        Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("FinalPrice"))),
                                        reader.GetDateTime(reader.GetOrdinal("SubscriptionStart")),
                                        reader.GetDateTime(reader.GetOrdinal("SubscriptionEnd")),
                                        reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                        reader.GetInt32(reader.GetOrdinal("UserId"))
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
                        "cls_UsersSubscriptions_D",
                        "GetActiveSubscriptionByUserAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return subscription;
        }

        // completed testing.
        public static async Task<md_UserSubscription?> GetSubscriptionByIdAsync(int subscriptionId)
        {
            md_UserSubscription? subscription = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[UsersSubscriptions_FUN_GetById] (@subscriptionId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@subscriptionId", SqlDbType.Int) { Value = subscriptionId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                subscription = new md_UserSubscription
                                    (
                                        reader.GetInt32(reader.GetOrdinal("SubscriptionId")),

                                        reader.IsDBNull(reader.GetOrdinal("PaymentId")) ? null :
                                        reader.GetInt32(reader.GetOrdinal("PaymentId")),

                                        reader.GetString(reader.GetOrdinal("PlanName")),
                                        Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Price"))),
                                        reader.GetByte(reader.GetOrdinal("Discount")),
                                        Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("FinalPrice"))),
                                        reader.GetDateTime(reader.GetOrdinal("SubscriptionStart")),
                                        reader.GetDateTime(reader.GetOrdinal("SubscriptionEnd")),
                                        reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                        reader.GetInt32(reader.GetOrdinal("UserId"))
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
                        () => subscriptionId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_UsersSubscriptions_D",
                        "GetSubscriptionByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return subscription;
        }

        // completed testing.
        public static async Task<bool> CheckUserSubscriptionAsync(int userId)
        {
            bool isActive = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[UsersSubscriptions_SP_CheckUserSubscription]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = userId });
                        
                        SqlParameter returnParameter = command.Parameters.Add("returnValue", SqlDbType.Bit);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        isActive = Convert.ToBoolean(returnParameter.Value);
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
                        "cls_UsersSubscriptions_D",
                        "CheckUserSubscriptionAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return isActive;
        }

        // completed testing.
        public static async Task<bool> IsUserHasActiveSubscriptionAsync(int userId)
        {
            bool isHasActiveSubscription = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[UsersSubscriptions_SP_IsUserHasActiveSubscription]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = userId });

                        SqlParameter returnParameter = command.Parameters.Add("returnValue", SqlDbType.Bit);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        isHasActiveSubscription = Convert.ToBoolean(returnParameter.Value);
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
                        "cls_UsersSubscriptions_D",
                        "IsUserHasActiveSubscriptionAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return isHasActiveSubscription;
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewUserSubscription subscription)
        {
            int insertedId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[UsersSubscriptions_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = subscription.UserId });
                        command.Parameters.Add(new SqlParameter("@planId", SqlDbType.Int) { Value = subscription.PlanId });

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
                        () => subscription.UserId,
                        () => subscription.PlanId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_UsersSubscriptions_D",
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
