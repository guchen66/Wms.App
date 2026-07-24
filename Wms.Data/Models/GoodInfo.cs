using Wms.Data.Models.NotMapped;
using SqlSugar;
using SqlSugar.DbConvert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wms.Core.Consts;
namespace Wms.Data.Models
{
    [SugarTable("GoodInfo")]
    public class GoodInfo : AutoIncrementEntity
    {
        [SugarColumn(ColumnDescription = "商品名称")]
        public string GoodName { get; set; }

        [SugarColumn(ColumnDescription = "商品数量")]
        public int Count { get; set; }

        [SugarColumn(ColumnDescription = "买家信息")]
        public string Buyers { get; set; }

        [SugarColumn(ColumnDescription = "下单时间")]
        public DateTime OrderTime { get; set; }

        [SugarColumn(ColumnDataType ="varchar(16)",SqlParameterDbType =typeof(EnumToStringConvert), ColumnDescription = "订单状态")]
        public OrderState OrderState { get; set; }

        public int OrderHeaderId { get; set; }             //一对多的标志
    }

   
}
