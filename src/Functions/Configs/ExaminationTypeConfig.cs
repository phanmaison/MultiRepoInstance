using System.Collections.Generic;

namespace Funtions.Configs
{
    public enum ExaminationDataSource
    {
        Sql,
        Csv
    }

    /// <summary>
    /// Configuration for each examination type
    /// </summary>
    public static class ExaminationTypeConfig
    {
        // this is manual configuration for development purpose only

        public static Dictionary<string, ExaminationDataSource> Providers = new Dictionary<string, ExaminationDataSource>
        {
            {"Type 1", ExaminationDataSource.Csv },
            {"Type 2", ExaminationDataSource.Sql },
            // Type 3 is not configured => use default repository
        };

    }
}
