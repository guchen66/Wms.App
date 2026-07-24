using Wms.Data.Models.NotMapped;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Data.Models
{
    [SugarTable("ProductData")]
    public class ProductData : AutoIncrementEntity
    {
        [SugarColumn(ColumnDescription = "产品唯一标识符")]
        public int ProductCode { get; set; }

        [SugarColumn(ColumnDescription = "产品名称")]
        public string ProductName { get; set; }

        [SugarColumn(ColumnDescription = "产品Ok数量")]
        public int OkCount { get; set; }

        [SugarColumn(ColumnDescription = "产品Ng数量")]
        public int NgCount { get; set; }

        [SugarColumn(ColumnDescription = "产品状态")]
        public string ProductState { get; set; }

        [SugarColumn(ColumnDescription = "产品图片")]
        public string Image { get; set; }

        public int ProductId { get; set; }             //一对多的标志

        public int WorkStationId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(WorkStationId))]
        public WorkStation WorkStationInfo { get; set; }

        [Navigate(typeof(ProductTypeMapping), nameof(ProductTypeMapping.ProductId), nameof(ProductTypeMapping.ProducTypetId))]
        public List<ProductType> ProductTypeInfo { get; set; }
    }
}
