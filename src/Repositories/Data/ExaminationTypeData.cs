using Repositories.Models;
using System.Collections.Generic;

namespace Repositories.Data
{
    /// <summary>
    /// Simulate data from Examination Type table, this data is from database 
    /// </summary>
    public class ExaminationTypeData
    {
        public static Dictionary<string, ExaminationTypeModel> Dictionary = new Dictionary<string, ExaminationTypeModel>
        {
            {
                ExaminationTypeConst.Type1,
                new ExaminationTypeModel { ExaminationType = ExaminationTypeConst.Type1, ExaminationName = "Name 1", ConnectionString = "Server=local1;Database=db;"}
            },
            {
                ExaminationTypeConst.Type2,
                new ExaminationTypeModel { ExaminationType = ExaminationTypeConst.Type2, ExaminationName = "Name 2", ConnectionString = "Server=local2;Database=db;"}
            },
            {
                ExaminationTypeConst.Type3,
                new ExaminationTypeModel { ExaminationType = ExaminationTypeConst.Type3, ExaminationName = "Name 3", ConnectionString = "Server=local3;Database=db;"}
            }

        };

    }
}
