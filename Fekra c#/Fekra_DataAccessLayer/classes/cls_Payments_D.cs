using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.models.Payments;
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
    public class cls_Payments_D
    {
        // completed testing.
        public static async Task<double> GetTotalPaymentsAsync()
        {
            double payments = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Payments_FUN_GetTotalPayments] ()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        object? returnValue = await command.ExecuteScalarAsync();

                        if (returnValue != null && returnValue != DBNull.Value)
                            payments = Convert.ToDouble(returnValue);
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
                        "cls_Payments_D",
                        "GetTotalPaymentsAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return payments;
        }

        // completed testing.
        public static async Task<int> GetPaymentsPagesCountAllAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[Payments_PagesCount_All] ()";

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
                        "cls_Payments_D",
                        "GetPaymentsPagesCountAllAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<List<md_Payments>?> GetAllAsync()
        {
            List<md_Payments> payments = new List<md_Payments>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Payments_FUN_GetAll] ()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                payments.Add
                                    (
                                        new md_Payments
                                        (
                                            reader.GetInt32(reader.GetOrdinal("PaymentId")),
                                            Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Amount"))),
                                            reader.GetString(reader.GetOrdinal("Currency")),
                                            reader.GetDateTime(reader.GetOrdinal("PaymentDate")),
                                            reader.GetString(reader.GetOrdinal("PaymentMethod")),

                                            reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                            null : reader.GetString(reader.GetOrdinal("Description")),

                                            reader.GetString(reader.GetOrdinal("UserName"))
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
                        "cls_Payments_D",
                        "GetAllAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return null;
            }

            return payments.Count > 0 ? payments : null;
        }

        // completed testing.
        public static async Task<List<md_Payments>?> GetByUserAsync(int userId)
        {
            List<md_Payments> payments = new List<md_Payments>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Payments_FUN_GetByUserId] (@userId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = userId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                payments.Add
                                    (
                                        new md_Payments
                                        (
                                            reader.GetInt32(reader.GetOrdinal("PaymentId")),
                                            Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Amount"))),
                                            reader.GetString(reader.GetOrdinal("Currency")),
                                            reader.GetDateTime(reader.GetOrdinal("PaymentDate")),
                                            reader.GetString(reader.GetOrdinal("PaymentMethod")),

                                            reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                            null : reader.GetString(reader.GetOrdinal("Description")),

                                            reader.GetString(reader.GetOrdinal("UserName"))
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
                        "cls_Payments_D",
                        "GetByUserAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return payments.Count > 0 ? payments : null;
        }

        // completed testing.
        public static async Task<md_Payments?> GetByIdAsync(int paymentId)
        {
            md_Payments? payment = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[Payments_FUN_GetById] (@paymentId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@paymentId", SqlDbType.Int) { Value = paymentId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                payment = new md_Payments
                                    (
                                        reader.GetInt32(reader.GetOrdinal("PaymentId")),
                                        Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Amount"))),
                                        reader.GetString(reader.GetOrdinal("Currency")),
                                        reader.GetDateTime(reader.GetOrdinal("PaymentDate")),
                                        reader.GetString(reader.GetOrdinal("PaymentMethod")),

                                        reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                        null : reader.GetString(reader.GetOrdinal("Description")),

                                        reader.GetString(reader.GetOrdinal("UserName"))
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
                        () => paymentId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Payments_D",
                        "GetByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return payment;
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewPayment payment)
        {
            int insertedId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[Payments_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@amount", SqlDbType.Money) { Value = payment.Amount });
                        command.Parameters.Add(new SqlParameter("@currency", SqlDbType.NVarChar, 50) { Value = payment.Currency });
                        command.Parameters.Add(new SqlParameter("@paymentMethod", SqlDbType.NVarChar, 100) { Value = payment.PaymentMethod });
                        command.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 250) { Value = payment.Description ?? (object)DBNull.Value });
                        command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int) { Value = payment.UserId });
                        command.Parameters.Add(new SqlParameter("@subscriptionId", SqlDbType.Int) { Value = payment.SubscriptionId });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = payment.ByAdmin });

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
                        () => payment.Amount,
                        () => payment.Currency,
                        () => payment.PaymentMethod,
                        () => payment.Description,
                        () => payment.UserId,
                        () => payment.SubscriptionId,
                        () => payment.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_Payments_D",
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
