using Wms.Data.Models.NotMapped;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Data.Models
{
    [SugarTable("WareHouse")]
    public class WareHouse : AutoIncrementEntity
    {
        public int WareHouseId { get; set; }

        [SugarColumn(ColumnDataType = "Nvarchar(20)")]
        public string WareHouseName { get; set; }

        [SugarColumn(ColumnDescription ="物件总数")]
        public int ItemTotal { get; set; }


        [SugarColumn(ColumnDescription = "物件类型",ColumnDataType = "Nvarchar(50)", IsNullable = true)]
        public string? ItemType { get; set; }

        [SugarColumn(ColumnDescription = "物件价格",DecimalDigits = 2)]
        public decimal Price { get; set; }


        [SugarColumn(ColumnDescription = "物件标记", ColumnDataType = "Nvarchar(256)", IsNullable = true)]
        public string Tag { get; set; }

        public int? UserId { get; set; }

        [SugarColumn(ColumnDescription = "负责人",ColumnDataType = "Nvarchar(50)")]
        public string? AssociatedPerson { get; set; }
    }
}
