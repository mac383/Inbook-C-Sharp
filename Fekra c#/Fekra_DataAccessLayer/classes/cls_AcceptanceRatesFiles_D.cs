using Fekra_DataAccessLayer.models.Acceptance_Rates_Files;
using Fekra_DataAccessLayer.models.Branches;
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
    public class cls_AcceptanceRatesFiles_D
    {
        // completed testing.
        public static async Task<List<md_AcceptanceRatesFiles>?> GetAllAsync()
        {
            List<md_AcceptanceRatesFiles> files = new List<md_AcceptanceRatesFiles>();

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[AcceptanceRatesFiles_FUN_GetAll] ()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                files.Add
                                    (
                                        new md_AcceptanceRatesFiles
                                        (
                                            reader.GetInt32(reader.GetOrdinal("FileId")),
                                            reader.GetString(reader.GetOrdinal("FileTitle")),
                                            reader.GetString(reader.GetOrdinal("FileURL")),
                                            reader.GetString(reader.GetOrdinal("FileName")),
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
                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AcceptanceRatesFiles_D",
                        "GetAllAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        null
                    ));

                return null;
            }

            return files.Count > 0 ? files : null;
        }

        // completed testing.
        public static async Task<md_AcceptanceRatesFiles?> GetByIdAsync(int fileId)
        {
            md_AcceptanceRatesFiles? file = null;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"SELECT * FROM [dbo].[AcceptanceRatesFiles_FUN_GetById] (@fileId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@fileId", SqlDbType.Int) { Value = fileId });

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                file = new md_AcceptanceRatesFiles
                                    (
                                        reader.GetInt32(reader.GetOrdinal("FileId")),
                                        reader.GetString(reader.GetOrdinal("FileTitle")),
                                        reader.GetString(reader.GetOrdinal("FileURL")),
                                        reader.GetString(reader.GetOrdinal("FileName")),
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
                        () => fileId
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AcceptanceRatesFiles_D",
                        "GetByIdAsync",
                        string.IsNullOrEmpty(ex.StackTrace) ? "null" : ex.StackTrace,
                        null,
                        Params
                    ));

                return null;
            }

            return file;
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int fileId, int byAdmin)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[AcceptanceRatesFiles_SP_Delete]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@fileId", SqlDbType.Int) { Value = fileId });
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
                        () => fileId,
                        () => byAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AcceptanceRatesFiles_D",
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
                    string query = @"[dbo].[AcceptanceRatesFiles_SP_IsFileExist]";

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
                        "cls_AcceptanceRatesFiles_D",
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
        public static async Task<int> NewAsync(md_NewAcceptanceRateFile file)
        {
            int insertedId = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[AcceptanceRatesFiles_SP_New]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@fileTitle", SqlDbType.NVarChar, 150) { Value = file.FileTitle });
                        command.Parameters.Add(new SqlParameter("@fileURL", SqlDbType.NVarChar) { Value = file.FileURL });
                        command.Parameters.Add(new SqlParameter("@fileName", SqlDbType.NVarChar, 150) { Value = file.FileName });
                        command.Parameters.Add(new SqlParameter("@academicYearId", SqlDbType.Int) { Value = file.AcademicYearId });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = file.ByAdmin });

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
                        () => file.FileTitle,
                        () => file.FileURL,
                        () => file.FileName,
                        () => file.AcademicYearId,
                        () => file.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AcceptanceRatesFiles_D",
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
        public static async Task<bool> UpdateAsync(md_UpdateAcceptanceRateFile file)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = cls_database.Connection())
                {
                    string query = @"[dbo].[AcceptanceRatesFiles_SP_Update]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@fileId", SqlDbType.Int) { Value = file.FileId });
                        command.Parameters.Add(new SqlParameter("@fileTitle", SqlDbType.NVarChar, 150) { Value = file.FileTitle });
                        command.Parameters.Add(new SqlParameter("@fileURL", SqlDbType.NVarChar) { Value = file.FileURL });
                        command.Parameters.Add(new SqlParameter("@fileName", SqlDbType.NVarChar, 150) { Value = file.FileName });
                        command.Parameters.Add(new SqlParameter("@academicYearId", SqlDbType.Int) { Value = file.AcademicYearId });
                        command.Parameters.Add(new SqlParameter("@byAdmin", SqlDbType.Int) { Value = file.ByAdmin });

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
                        () => file.FileId,
                        () => file.FileTitle,
                        () => file.FileURL,
                        () => file.FileName,
                        () => file.AcademicYearId,
                        () => file.ByAdmin
                    );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                    (
                        ex.Message,
                        "Data Access Layer",
                        string.IsNullOrEmpty(ex.Source) ? "null" : ex.Source,
                        "cls_AcceptanceRatesFiles_D",
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
