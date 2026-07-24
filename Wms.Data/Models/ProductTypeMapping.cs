using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Data.Models
{
    /// <summary>
    /// 产品分类表和产品表属于多对多的关系
    /// </summary>
    public class ProductTypeMapping
    {
        public int ProductId { get; set; }

        public int ProducTypetId { get; set; }

        /// <summary>
        /// ProductTypeId1表示全部产品，ProductData表主键+1，并且ProductTypeId=1，
        /// 2表示生产产品
        /// 3表示完成产品
        /// </summary>
        [SugarColumn(ColumnDescription = "备注",IsNullable =true)]
        public string? Remark { get; set; }
    }
}
