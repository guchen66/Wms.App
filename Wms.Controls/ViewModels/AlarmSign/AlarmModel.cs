using Wms.Admin.IRepositorys;
using Wms.Data.Models;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
namespace Wms.Controls.ViewModels.AlarmSign
{
    /// <summary>
    /// 突发奇想，用方法绑定列表试一下
    /// </summary>
    public class AlarmModel
    {
        private readonly IBaseRepository<AlarmInfo> _alarmRepository;

        public AlarmModel()
        {
            _alarmRepository = ContainerLocator.Container.Resolve<IBaseRepository<AlarmInfo>>();
        }
        public List<AlarmInfo> GetAlarmInfoList()
        {
            return _alarmRepository.Context.Queryable<AlarmInfo>().ToList();
        }
    }
}
