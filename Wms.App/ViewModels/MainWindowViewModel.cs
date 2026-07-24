using Wms.Admin.IRepositorys;
using Wms.Controls.Mvvm;
using Wms.Controls.Views;
using Wms.Core.Common;
using Wms.Data.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Wms.Core.Extensions;
using SqlSugar;
using Prism.Regions;
namespace Wms.App.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IBaseRepository<AsideMenuControl> _controlRepository;

        private ObservableCollection<AsideMenuControl> _asideMenuControls;

        public ObservableCollection<AsideMenuControl> AsideMenuControls
        {
            get => _asideMenuControls??(_asideMenuControls=new ObservableCollection<AsideMenuControl>());
            set => SetProperty(ref _asideMenuControls, value);
        }

        public MainWindowViewModel(IBaseRepository<AsideMenuControl> controlRepository,IContainerProvider provider) : base(provider)
        {
            _controlRepository = controlRepository;
            LoadedCommand = new DelegateCommand(ExecuteLoaded);
            SelectedViewCommand = new DelegateCommand<string>(ExecuteSelected);

        }

        private void ExecuteLoaded()
        {
            //初始化左侧菜单按钮
           AsideMenuControls = _controlRepository.Context.Queryable<AsideMenuControl>().ToList().ToObservableCollection();
            
        }
        public void ExecuteSelected(string menuTitle)
        {
            NavigationToView(menuTitle);
        }
        public ICommand LoadedCommand { get; set; }
        public ICommand SelectedViewCommand { get; set; }

    }
}
