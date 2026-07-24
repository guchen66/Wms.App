using Wms.Data.Models.NotMapped;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Data.Models
{
    [SugarTable("WorkStep")]
    public class WorkStep : AutoIncrementEntity
    {
        public int WorkStepId { get; set; }

        [SugarColumn(ColumnDescription = "工序名称", Length = 200)]
        public string WorkStepName { get; set; }

        [SugarColumn(ColumnDescription = "操作顺序")]
        public string OperationSequence { get; set; }

        [SugarColumn(ColumnDescription = "操作参数")]
        public string OperationParameters { get; set; }

        [SugarColumn(ColumnDescription = "所需技能")]
        public string RequiredSkills { get; set; } 

        [SugarColumn(ColumnDescription = "工序持续时间")]
        public int Duration { get; set; }

        [SugarColumn(ColumnDescription = "所需材料")]
        public string RequiredMaterials { get; set; }

        public int WorkStationId { get; set; }

        /// <summary>
        /// 工序查找工位一对一
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(WorkStationId))]
        public WorkStation WorkStationInfo { get; set; } 

        /*  [SugarColumn(ColumnDescription = "工序持续时间")]
          public List<string> RequiredTools { get; set; }*/
        /*   public SafetyRisk SafetyRisk { get; set; } // 安全风险评估

           [SugarColumn(ColumnDescription = "质量控制要求")]
           public QualityControl QualityControl { get; set; } 


           public List<CheckItem> CheckItems { get; set; } // 检查项目列表
           public List<ProcessDefect> Defects { get; set; } // 工序可能产生的缺陷列表
           public List<ProcessStep> Steps { get; set; } // 工序步骤详情列表
           public Station BelongsToStation { get; set; } // 所属工位*/

    }
}
