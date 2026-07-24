using NewLife.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Core.Common
{
    public class GeneratorData
    {
        public string Title { get; set; }
        public bool IsAutoTable { get; set; }
        public bool IsAutoData { get; set; }
    }

    public class GeneratorDataProvider
    {
        private static GeneratorData _jsonData;
        private static GeneratorData GetJsonData()
        {
            if (_jsonData == null)
            {
                var provider = new JsonConfigProvider()
                {
                    FileName = "AppConfig.json"
                };

                _jsonData = provider.Load<GeneratorData>("GeneratorData")!;
            }

            return _jsonData;
        }
        public static bool IsAutoTable
        {
            get => GetJsonData().IsAutoTable;
        }

        public static bool IsAutoTableData
        {
            get => GetJsonData().IsAutoData;
        }
    }
}
