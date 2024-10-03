using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.models.Subscription_Plans;
using Fekra_DataAccessLayer.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_DataAccessLayer.classes
{
    public class cls_SubscriptionPlans_D
    {
        // completed testing.
        public static async Task<List<md_ActiveSubscriptionPlans>?> GetActivePlansByBranchAsync(int branchId)
        {
            List<md_ActiveSubscriptionPlans> plans = new List<md_ActiveSubscriptionPlans>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[SubscriptionPlans_FUN_GetActivePlansByBranch] (@branchId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@branchId", SqlDbType.Int) { Value = branchId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                plans.Add
                                    (
                                        new md_ActiveSubscriptionPlans
                                        (
                                            reader.GetInt32(reader.GetOrdinal("PlanId")),
                                            reader.GetString(reader.GetOrdinal("PlanName")),
                                            Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Price"))),
                                            reader.GetByte(reader.GetOrdinal("Discount")),
                                            Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("FinalPrice"))),
                                            
                                            reader.GetByte(reader.GetOrdinal("MonthlyDuration")),
                                            reader.GetByte(reader.GetOrdinal("DailyDuration")),

                                            reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                            null : reader.GetString(reader.GetOrdinal("Description")),

                                            reader.GetBoolean(reader.GetOrdinal("IsFreeTrail")),
                                            reader.GetString(reader.GetOrdinal("BranchName"))
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
                        () => branchId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_SubscriptionPlans_D",
                        "GetActivePlansByBranchAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return plans.Count > 0 ? plans : null;
        }

        // completed testing.
        public static async Task<List<md_SubscriptionPlans>?> GetByBranchAsync(int branchId)
        {
            List<md_SubscriptionPlans> plans = new List<md_SubscriptionPlans>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[SubscriptionPlans_FUN_GetByBranch] (@branchId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@branchId", SqlDbType.Int) { Value = branchId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                plans.Add
                                    (
                                        new md_SubscriptionPlans
                                        (
                                            reader.GetInt32(reader.GetOrdinal("PlanId")),
                                            reader.GetString(reader.GetOrdinal("PlanName")),
                                            Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Price"))),
                                            reader.GetByte(reader.GetOrdinal("Discount")),
                                            Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("FinalPrice"))),
                                            reader.GetByte(reader.GetOrdinal("MonthlyDuration")),
                                            reader.GetByte(reader.GetOrdinal("DailyDuration")),
                                            reader.GetBoolean(reader.GetOrdinal("IsActive")),

                                            reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                            null : reader.GetString(reader.GetOrdinal("Description")),

                                            reader.GetBoolean(reader.GetOrdinal("IsFreeTrail")),
                                            reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                                            reader.GetString(reader.GetOrdinal("BranchName"))
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
                        () => branchId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_SubscriptionPlans_D",
                        "GetByBranchAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return plans.Count > 0 ? plans : null;
        }

        // completed testing.
        public static async Task<md_SubscriptionPlans?> GetByIdAsync(int planId)
        {
            md_SubscriptionPlans? plan = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[SubscriptionPlans_FUN_GetById] (@planId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@planId", SqlDbType.Int) { Value = planId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                plan = new md_SubscriptionPlans
                                    (
                                        reader.GetInt32(reader.GetOrdinal("PlanId")),
                                        reader.GetString(reader.GetOrdinal("PlanName")),
                                        Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Price"))),
                                        reader.GetByte(reader.GetOrdinal("Discount")),
                                        Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("FinalPrice"))),
                                        reader.GetByte(reader.GetOrdinal("MonthlyDuration")),
                                        reader.GetByte(reader.GetOrdinal("DailyDuration")),
                                        reader.GetBoolean(reader.GetOrdinal("IsActive")),

                                        reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                        null : reader.GetString(reader.GetOrdinal("Description")),

                                        reader.GetBoolean(reader.GetOrdinal("IsFreeTrail")),
                                        reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                                        reader.GetString(reader.GetOrdinal("BranchName"))
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
                        () => planId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_SubscriptionPlans_D",
                        "GetByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return plan;
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int planId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[SubscriptionPlans_SP_Delete]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@planId", SqlDbType.Int) { Value = planId });
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
                        () => planId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_SubscriptionPlans_D",
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
        public static async Task<bool> IsHasRelationsAsync(int planId)
        {
            bool hasRelations = false;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[SubscriptionPlans_SP_HasRelations]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@planId", SqlDbType.Int) { Value = planId });

                        SqlParameter returnParameter = command.Parameters.Add("returnValue", SqlDbType.Bit);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        hasRelations = Convert.ToBoolean(returnParameter.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                    (
                        () => planId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_SubscriptionPlans_D",
                        "IsHasRelationsAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return hasRelations;
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewSubscriptionPlan plan)
        {
            int insertedId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[SubscriptionPlans_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@planName", SqlDbType.NVarChar, 100) { Value = plan.PlanName });
                        command.Parameters.Add(new SqlParameter("@price", SqlDbType.Money) { Value = plan.Price });
                        command.Parameters.Add(new SqlParameter("@discount", SqlDbType.TinyInt) { Value = plan.Discount });
                        command.Parameters.Add(new SqlParameter("@monthlyDuration", SqlDbType.TinyInt) { Value = plan.MonthlyDuration });
                        command.Parameters.Add(new SqlParameter("@dailyDuration", SqlDbType.TinyInt) { Value = plan.DailyDuration});
                        command.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 250) { Value = plan.Description ?? (object)DBNull.Value });
                        command.Parameters.Add(new SqlParameter("@branchId", SqlDbType.Int) { Value = plan.BranchId });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = plan.ByAdmin });

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
                        () => plan.PlanName,
                        () => plan.Price,
                        () => plan.Discount,
                        () => plan.MonthlyDuration,
                        () => plan.DailyDuration,
                        () => plan.Description,
                        () => plan.BranchId,
                        () => plan.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_SubscriptionPlans_D",
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
        public static async Task<bool> SetAsActiveAsync(int planId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[SubscriptionPlans_SP_SetAsActive]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@planId", SqlDbType.Int) { Value = planId });
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
                        () => planId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_SubscriptionPlans_D",
                        "SetAsActiveAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        // completed testing.
        public static async Task<bool> SetAsInActiveAsync(int planId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[SubscriptionPlans_SP_SetAsInActive]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@planId", SqlDbType.Int) { Value = planId });
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
                        () => planId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_SubscriptionPlans_D",
                        "SetAsInActiveAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;
        }

        // completed testing.
        public static async Task<bool> SetDescriptionAsync(int planId, string description, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[SubscriptionPlans_SP_SetDescription]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@planId", SqlDbType.Int) { Value = planId });
                        command.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 250) { Value = description });
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
                        () => planId,
                        () => description,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_SubscriptionPlans_D",
                        "SetDescriptionAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return false;
            }

            return rowsAffected > 0;

        }

        // completed testing.
        public static async Task<bool> UpdateAsync(md_UpdateSubscriptionPlan plan)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[SubscriptionPlans_SP_Update]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@planId", SqlDbType.Int) { Value = plan.PlanId });
                        command.Parameters.Add(new SqlParameter("@planName", SqlDbType.NVarChar, 100) { Value = plan.PlanName });
                        command.Parameters.Add(new SqlParameter("@price", SqlDbType.Money) { Value = plan.Price });
                        command.Parameters.Add(new SqlParameter("@discount", SqlDbType.TinyInt) { Value = plan.Discount });
                        command.Parameters.Add(new SqlParameter("@monthlyDuration", SqlDbType.TinyInt) { Value = plan.MonthlyDuration });
                        command.Parameters.Add(new SqlParameter("@dailyDuration", SqlDbType.TinyInt) { Value = plan.DailyDuration });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = plan.ByAdmin });

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
                        () => plan.PlanId,
                        () => plan.PlanName,
                        () => plan.Price,
                        () => plan.Discount,
                        () => plan.MonthlyDuration,
                        () => plan.DailyDuration,
                        () => plan.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_SubscriptionPlans_D",
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
