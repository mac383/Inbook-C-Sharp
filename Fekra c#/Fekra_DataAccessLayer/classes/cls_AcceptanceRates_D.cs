using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Acceptance_Rates;
using Fekra_DataAccessLayer.models.Branches;

namespace Fekra_DataAccessLayer.classes
{
    public class cls_AcceptanceRates_D
    {
        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[AcceptanceRates_FUN_GetCount] ()";

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
                        "cls_AcceptanceRates_D",
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
        public static async Task<int> GetCountByBranchAsync(int branchId)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[AcceptanceRates_FUN_GetCountByBranch] (@branchId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@branchId", SqlDbType.Int) { Value = branchId });

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
                        () => branchId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AcceptanceRates_D",
                        "GetCountByBranchAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<int> GetPagesCountByBranchAsync(int branchId)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT [dbo].[AcceptanceRates_PagesCount_Branch] (@branchId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@branchId", SqlDbType.Int) { Value = branchId });

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
                        () => branchId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AcceptanceRates_D",
                        "GetPagesCountByBranchAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return -1;
            }

            return count;
        }

        // completed testing.
        public static async Task<List<md_AcceptanceRates>?> GetByBranchAsync(int branchId, int pageNumber)
        {
            List<md_AcceptanceRates> rates = new List<md_AcceptanceRates>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[AcceptanceRates_FUN_GetByBranch] (@branchId, @packageNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@branchId", SqlDbType.Int) { Value = branchId });
                        command.Parameters.Add(new SqlParameter("@packageNumber", SqlDbType.Int) { Value = pageNumber });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                rates.Add
                                    (
                                        new md_AcceptanceRates
                                        (
                                            reader.GetInt32(reader.GetOrdinal("RateId")),
                                            reader.GetString(reader.GetOrdinal("College")),
                                            Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Total"))),
                                            Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Average"))),
                                            reader.GetString(reader.GetOrdinal("Gender")),

                                            reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                            null : reader.GetString(reader.GetOrdinal("Description")),

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
                        () => branchId,
                        () => pageNumber
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AcceptanceRates_D",
                        "GetByBranchAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return rates.Count > 0 ? rates : null;
        }

        // completed testing.
        public static async Task<md_AcceptanceRates?> GetByIdAsync(int rateId)
        {
            md_AcceptanceRates? rate = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[AcceptanceRates_FUN_GetById] (@rateId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@rateId", SqlDbType.Int) { Value = rateId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                rate = new md_AcceptanceRates
                                    (
                                        reader.GetInt32(reader.GetOrdinal("RateId")),
                                        reader.GetString(reader.GetOrdinal("College")),
                                        Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Total"))),
                                        Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("Average"))),
                                        reader.GetString(reader.GetOrdinal("Gender")),

                                        reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                        null : reader.GetString(reader.GetOrdinal("Description")),

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
                        () => rateId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AcceptanceRates_D",
                        "GetByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return rate;
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int rateId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[AcceptanceRates_SP_Delete]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@rateId", SqlDbType.Int) { Value = rateId });
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
                        () => rateId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AcceptanceRates_D",
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
        public static async Task<int> NewAsync(md_NewAcceptanceRate rate)
        {
            int insertedId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[AcceptanceRates_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@college", SqlDbType.NVarChar, 250) { Value = rate.College });
                        command.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal) { Value = rate.Total });
                        command.Parameters.Add(new SqlParameter("@average", SqlDbType.Decimal) { Value = rate.Average });
                        command.Parameters.Add(new SqlParameter("@gender", SqlDbType.NVarChar, 10) { Value = rate.Gender });
                        command.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 150) { Value = rate.Description ?? (object)DBNull.Value });
                        command.Parameters.Add(new SqlParameter("@branchId", SqlDbType.Int) { Value = rate.BranchId });
                        command.Parameters.Add(new SqlParameter("@academicYearId", SqlDbType.Int) { Value = rate.AcademicYearId });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = rate.ByAdmin });

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
                        () => rate.College,
                        () => rate.Total,
                        () => rate.Average,
                        () => rate.Gender,
                        () => rate.Description,
                        () => rate.BranchId,
                        () => rate.AcademicYearId,
                        () => rate.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AcceptanceRates_D",
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
        public static async Task<bool> UpdateAsync(md_UpdateAcceptanceRate rate)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[AcceptanceRates_SP_Update]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@rateId", SqlDbType.Int) { Value = rate.RateId });
                        command.Parameters.Add(new SqlParameter("@college", SqlDbType.NVarChar, 250) { Value = rate.College });
                        command.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal) { Value = rate.Total });
                        command.Parameters.Add(new SqlParameter("@average", SqlDbType.Decimal) { Value = rate.Average });
                        command.Parameters.Add(new SqlParameter("@gender", SqlDbType.NVarChar, 10) { Value = rate.Gender });
                        command.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 150) { Value = rate.Description ?? (object)DBNull.Value });
                        command.Parameters.Add(new SqlParameter("@branchId", SqlDbType.Int) { Value = rate.BranchId });
                        command.Parameters.Add(new SqlParameter("@academicYearId", SqlDbType.Int) { Value = rate.AcademicYearId });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = rate.ByAdmin });

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
                        () => rate.RateId,
                        () => rate.College,
                        () => rate.Total,
                        () => rate.Average,
                        () => rate.Gender,
                        () => rate.Description,
                        () => rate.BranchId,
                        () => rate.AcademicYearId,
                        () => rate.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AcceptanceRates_D",
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
