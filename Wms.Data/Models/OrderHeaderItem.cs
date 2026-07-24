using Wms.Data.Models.NotMapped;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Data.Models
{
    [SugarTable("OrderHeaderItem")]
    public class OrderHeaderItem: AutoIncrementEntity
    {
        [SugarColumn(ColumnDataType = "Nvarchar(20)")]
        public string? Title { get; set; }

        [SugarColumn(ColumnDataType = "Nvarchar(20)")]
        public string Path { get; set; }

        [Navigate(NavigateType.OneToMany,nameof(GoodInfo.OrderHeaderId))]
        public List<GoodInfo> GoodInfos { get; set; }

    }
}
