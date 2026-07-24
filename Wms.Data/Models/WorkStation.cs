using Wms.Data.Models.NotMapped;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Data.Models
{
    [SugarTable("WorkStation")]
    public class WorkStation : AutoIncrementEntity
    {
        [SugarColumn(ColumnDescription = "工站Id", Length = 200)]
        public int WorkId {  get; set; }

        [SugarColumn(ColumnDescription = "工站名称")]
        public string WorkName { get; set; }

        [SugarColumn(ColumnDescription = "工位位置信息")]
        public string Location { get; set; }

        [SugarColumn(ColumnDescription = "工位容纳能力")]
        public int Capacity { get; set; }

        [SugarColumn(ColumnDescription = "是否自动化工位")]
        public bool IsAutomatic { get; set; }

        [SugarColumn(ColumnDescription = "投产日期")]
        public new DateTime CreateTime { get; set; }

        [SugarColumn(ColumnDescription = "最后维护日期")]
        public new DateTime UpdateTime { get; set; }

        [SugarColumn(ColumnDescription = "维护人员")]
        public string MaintenancePerson { get; set; }

        //工位包含的产品数据
        [Navigate(NavigateType.OneToOne, nameof(ProductData.ProductId),nameof(WorkId))]
        public List<ProductData> ProductDatas { get; set; }

        //非主键模式和子表的主键WorkStepId对应, 工位包含的工序列表
        [Navigate(NavigateType.OneToMany,nameof(WorkStep.WorkStepId),nameof(WorkId))]
        public List<WorkStep> WorkSteps { get; set; }

        //工位所使用的设备列表
        [Navigate(NavigateType.OneToMany, nameof(DeviceInfo.DeviceInfoId), nameof(WorkId))]
        public List<DeviceInfo> DeviceInfos { get; set; }

    }
}
