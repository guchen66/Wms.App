using Wms.Admin.IRepositorys;
using Wms.Admin.IServices;
using Wms.Controls.Mvvm;
using Wms.Core.Consts;
using Wms.Core.Extensions;
using Wms.Data.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Wms.Controls.ViewModels
{
    public class AlarmViewModel : BaseNavigationAware
    {
        private AlarmEnum _alarmName;

        public AlarmEnum AlarmName
        {
            get => _alarmName;
            set => SetProperty(ref _alarmName, value);
        }

        public readonly ILogger _logger;

        private readonly IBaseRepository<AlarmInfo> _alarmRepository;

        private string _searchContent;

        public string SearchContent
        {
            get => _searchContent;
            set => SetProperty(ref _searchContent, value);
        }

        private ObservableCollection<AlarmInfo> _alarmInfos;

        public ObservableCollection<AlarmInfo> AlarmInfos
        {
            get => _alarmInfos??(_alarmInfos=new ObservableCollection<AlarmInfo>());
            set => SetProperty(ref _alarmInfos, value);
        }

        public AlarmViewModel(IBaseRepository<AlarmInfo> alarmRepository,ILogger logger,IContainerProvider provider) : base(provider)
        {
            _logger = logger;
            _alarmRepository = alarmRepository;
            QueryAlarmCommand = new DelegateCommand<string>(ExecuteQuery);
        }

        private void ExecuteQuery(string content)
        {
           // RegionManager
               SearchContent = AlarmName.ToString();
            var models = _alarmRepository.Context.Queryable<AlarmInfo>().Includes(x=>x.WorkStep).ToList();
            AlarmInfos = models.ToObservableCollection();

            GetListCollectionView().Refresh();
        }

        public ICommand QueryAlarmCommand { get; set; }

        private ListCollectionView GetListCollectionView()
        {
            return (ListCollectionView)CollectionViewSource
                            .GetDefaultView(this.AlarmInfos);
        }
    }
}
