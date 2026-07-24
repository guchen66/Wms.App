using Wms.Admin.IRepositorys;
using Wms.Controls.Mvvm;
using Wms.Core.Extensions;
using Wms.Data.Models;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wms.Controls.ViewModels
{
    public class WorkStationViewModel : BaseNavigationAware
    {
        private readonly IBaseRepository<WorkStation> _workStationRepository;

        private string _search;

        public string Search
        {
            get => _search;
            set => SetProperty(ref _search, value);
        }

        private ObservableCollection<WorkStation> _workStations;

        public ObservableCollection<WorkStation> WorkStations
        {
            get => _workStations;
            set => SetProperty(ref _workStations, value);
        }

        public WorkStationViewModel(IBaseRepository<WorkStation> workStationRepository,IContainerProvider provider) : base(provider)
        {
            _workStationRepository = workStationRepository;

            var models=_workStationRepository.Context.Queryable<WorkStation>().Includes(x=>x.WorkSteps).ToList();
            WorkStations = models.ToObservableCollection();
        }

        #region 命令

        public ICommand QueryWorkStationCommand { get; set; }
        public ICommand AddWorkStationCommand { get; set; }
        public ICommand UpdateWorkStationCommand { get; set; }
        public ICommand DelWorkStationCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        #endregion
    }
}
