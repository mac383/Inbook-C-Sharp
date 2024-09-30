using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.AcademicYears;
using Fekra_DataAccessLayer.models.Branches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fekra_BusinessLayer.services
{
    public class cls_AcademicYears
    {
        // completed testing.
        public static bool ValidateObj_NewMode(md_NewAcademicYear academicYear)
        {
            if (!Validation.CheckLength(1, 25, academicYear.AcademicYear))
                return false;

            if (academicYear.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static bool ValidateObj_UpdateMode(md_UpdateAcademicYear academicYear)
        {
            if (academicYear.AcademicYearId <= 0)
                return false;

            if (!Validation.CheckLength(1, 25, academicYear.AcademicYear))
                return false;

            if (academicYear.ByAdmin <= 0)
                return false;

            return true;
        }

        // completed testing.
        public static async Task<int> GetCountAsync()
        {
            return await cls_AcademicYears_D.GetCountAsync();
        }

        // completed testing.
        public static async Task<List<md_AcademicYears>?> GetAllAsync()
        {
            return await cls_AcademicYears_D.GetAllAsync();
        }

        // completed testing.
        public static async Task<md_AcademicYears?> GetByIdAsync(int yearId)
        {
            return await cls_AcademicYears_D.GetByIdAsync(yearId);
        }

        // completed testing.
        public static async Task<bool> DeleteAsync(int yearId, int byAdmin)
        {
            return await cls_AcademicYears_D.DeleteAsync(yearId, byAdmin);
        }

        // completed testing.
        public static async Task<bool> IsHasRelationsAsync(int yearId)
        {
            return await cls_AcademicYears_D.IsHasRelationsAsync(yearId);
        }

        // completed testing.
        public static async Task<bool> IsExistAsync(string year)
        {
            return await cls_AcademicYears_D.IsExistAsync(year);
        }

        // completed testing.
        public static async Task<int> NewAsync(md_NewAcademicYear academicYear)
        {
            if (!ValidateObj_NewMode(academicYear))
                return -1;

            return await cls_AcademicYears_D.NewAsync(academicYear);
        }

        // completed testing.
        public static async Task<bool> UpdateAsync(md_UpdateAcademicYear academicYear)
        {
            if (!ValidateObj_UpdateMode(academicYear))
                return false;

            return await cls_AcademicYears_D.UpdateAsync(academicYear);
        }
    }
}
