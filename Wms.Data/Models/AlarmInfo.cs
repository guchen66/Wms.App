using Wms.Data.Models.NotMapped;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Data.Models
{
    [SugarTable("AlarmInfo",TableDescription ="报警表")]
    public class AlarmInfo : AutoIncrementEntity
    {
        [SugarColumn(ColumnDescription = "报警唯一标识", Length = 200)]
        public int AlarmCode { get; set; }

        [SugarColumn(ColumnDescription = "报警名称")]
        public string AlarmName { get; set; }

        [SugarColumn(ColumnDescription = "报警工位")]
        public string AlarmStation { get; set; }

        [SugarColumn(ColumnDescription = "报警工序")]
        public string AlarmStep { get; set; }

        [SugarColumn(ColumnDescription = "报警状态")]
        public string AlarmState { get; set; }

        [SugarColumn(ColumnDescription = "报警持续时间")]
        public int Duration { get; set; }

        [SugarColumn(ColumnDescription = "托盘号")]
        public string TrayNumber { get; set; }

        public int WorkStepId { get; set; }

        [Navigate(NavigateType.OneToOne,nameof(WorkStepId))]                   //报警表和工序一对一的关系
        public WorkStep WorkStep { get; set; }
    }
}
