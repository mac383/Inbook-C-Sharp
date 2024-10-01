using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Acceptance_Rates_Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_AcceptanceRatesFiles
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewAcceptanceRateFile file)
        {
            if (!Validation.CheckLength(1, 150, file.FileTitle))
                return false;

            if (string.IsNullOrEmpty(file.FileURL))
                return false;

            if (!Validation.CheckLength(1, 150, file.FileName))
                return false;

            if (file.AcademicYearId <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static bool ValidateObj_UpdateMode(md_UpdateAcceptanceRateFile file)
        {
            if (file.FileId <= 0)
                return false;

            if (!Validation.CheckLength(1, 150, file.FileTitle))
                return false;

            if (string.IsNullOrEmpty(file.FileURL))
                return false;

            if (!Validation.CheckLength(1, 150, file.FileName))
                return false;

            if (file.AcademicYearId <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<List<md_AcceptanceRatesFiles>?> GetAllAsync()
        {
            return await cls_AcceptanceRatesFiles_D.GetAllAsync();
        }

        // completed testing.
        public static async Task<md_AcceptanceRatesFiles?> GetByIdAsync(int fileId)
        {
            return await cls_AcceptanceRatesFiles_D.GetByIdAsync(fileId);
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int fileId, int byAdmin)
        {
            return await cls_AcceptanceRatesFiles_D.DeleteAsync(fileId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> IsFileExistAsync(string fileName)
        {
            return await cls_AcceptanceRatesFiles_D.IsFileExistAsync(fileName);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewAcceptanceRateFile file)
        {
            if (!ValidateObj_NewMode(file))
                return -1;

            return await cls_AcceptanceRatesFiles_D.NewAsync(file);
        }

        // completed testing.
        public static async Task<bool> UpdateAsync(md_UpdateAcceptanceRateFile file)
        {
            if (!ValidateObj_UpdateMode(file))
                return false;

            return await cls_AcceptanceRatesFiles_D.UpdateAsync(file);
        }
    }
}
