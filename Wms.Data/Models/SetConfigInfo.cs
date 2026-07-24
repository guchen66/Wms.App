using Wms.Data.Models.NotMapped;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Data.Models
{
    [SugarTable("SetConfigInfo")]
    public class SetConfigInfo : AutoIncrementEntity
    {
        [SugarColumn(ColumnDescription = "标题")]
        public string Title { get; set; }

        [SugarColumn(ColumnDescription = "背景颜色")]
        public string BackgroundColor { get; set; }

        [SugarColumn(ColumnDescription = "图标")]
        public string Icon { get; set; }

        [SugarColumn(ColumnDescription = "分类配置")]
        public string ConfigName { get; set; }

        [SugarColumn(ColumnDescription = "打开不同配置Dialog")]
        public string DialogName { get; set; }

    }
}
