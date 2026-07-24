using Wms.Core.Consts;
using Wms.Data.Models.NotMapped;
using SqlSugar.DbConvert;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Data.Models
{
    [SugarTable("DeviceInfo")]
    public class DeviceInfo : AutoIncrementEntity
    {
        [SugarColumn(ColumnDescription = "设备名称")]
        public string DeviceName { get; set; }

        [SugarColumn(ColumnDescription = "设备数量")]
        public int Count { get; set; }

        [SugarColumn(ColumnDescription = "设备安全风险")]
        public string SafetyRisk { get; set; }

        public int DeviceInfoId { get; set; }             //一对多的标志

        public int WorkStationId { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(WorkStationId))]
        public WorkStation WorkStationInfo { get; set; }
    }
}
