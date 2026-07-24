using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Data.Models.NotMapped
{
    /// <summary>
    ///     递增主键实体基类
    /// </summary>
    public abstract class NotAutoIncrementEntity : EntityBase
    {
        /// <summary>
        ///     主键Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        // 注意是在这里定义你的公共实体
        public override int Id { get; set; }
    }
}
