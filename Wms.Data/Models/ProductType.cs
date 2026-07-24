using Wms.Data.Models.NotMapped;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Data.Models
{
    /// <summary>
    /// 数据分别表
    /// </summary>
    [SugarTable("ProductType")]
    public class ProductType : AutoIncrementEntity
    {       
        public int CategoryId { get; set; }

        [SugarColumn(ColumnDescription = "分类名称")]
        public string CategoryName { get; set; }

        [SugarColumn(ColumnDescription = "分类描述")]
        public string Description { get; set; }

        // 多对多的关系 通过ProductTypeMapping来确定
        [Navigate(typeof(ProductTypeMapping), nameof(ProductTypeMapping.ProducTypetId), nameof(ProductTypeMapping.ProductId))]
        public List<ProductData> ProductDataInfo { get; set; }
    }
}
