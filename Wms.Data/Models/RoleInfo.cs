using Wms.Data.Models.NotMapped;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Data.Models
{
    [SugarTable("RoleInfo")]
    public class RoleInfo : AutoIncrementEntity
    {
        public string Name { get; set; }

        [SugarColumn(ColumnDescription = "1-10数字越大等级越高 10表示程序设计人员")]
        public int Sort { get; set; }
    }
}
