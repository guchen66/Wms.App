using Wms.Controls.Mvvm;
using Wms.Core.Dtos;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.VisualBasic.ApplicationServices;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Wms.Admin.IRepositorys;
using Wms.Admin.Repositorys;
using Wms.Data.Models;
using MapsterMapper;
using Mapster;
using Wms.Core.Extensions;
using Prism.Regions;
using SqlSugar.IOC;
using System.Linq.Expressions;
using Wms.Core.Consts;
namespace Wms.Controls.ViewModels
{
    public class ProductInfoViewModel : BaseNavigationAware
    {
        #region 属性、字段

        private string _searchContent;

        public string SearchContent
        {
            get => _searchContent;
            set => SetProperty(ref _searchContent, value);
        }


        private ProductEnum _productEnumName;

        public ProductEnum ProductEnumName
        {
            get => _productEnumName;
            set => SetProperty(ref _productEnumName, value);
        }
        private DateTime _startTime=DateTime.Now;

        public DateTime StartTime
        {
            get =>_startTime;
            set =>SetProperty(ref _startTime, value);
        }
        private DateTime _endTime= DateTime.Now;

        public DateTime EndTime
        {
            get => _endTime;
            set => SetProperty(ref _endTime, value);
        }
        private ObservableCollection<ProductType> _productTypes;

        public ObservableCollection<ProductType> ProductTypes
        {
            get => _productTypes?? (_productTypes = new ObservableCollection<ProductType>());
            set => SetProperty(ref _productTypes, value);
        }

        private ObservableCollection<ProductData> _productInfos;
        public ObservableCollection<ProductData> ProductInfos
        {
            get => _productInfos ?? (_productInfos = new ObservableCollection<ProductData>());
            set => SetProperty(ref _productInfos, value);
        }
        private IBaseRepository<ProductData> _productInfoRepository;
        private IBaseRepository<ProductType> _productTypeRepository;
        #endregion

        #region 命令

        public ICommand LoadedCommand { get; set; }
        public ICommand QueryCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        #endregion

      
        private DispatcherTimer _timer;
        private bool _isDelaying;
        public ProductInfoViewModel(IBaseRepository<ProductType> productTypeRepository,IBaseRepository<ProductData> productInfoRepository, IContainerProvider provider) : base(provider)
        {
            _productTypeRepository = productTypeRepository;
            _productInfoRepository = productInfoRepository;

            /*  LoadedCommand = new DelegateCommand(ExecuteIniting);
              QueryUserCommand = new DelegateCommand(ExecuteQueryUser);
              AddUserCommand = new DelegateCommand(ExecuteAddUser);
              UpdateUserCommand = new DelegateCommand<int?>(ExecuteUpdateUser);
              DelUserCommand = new DelegateCommand<int?>(ExecuteDelUser);
              RefreshCommand = new DelegateCommand(ExecuteRefresh);*/
            QueryCommand = new DelegateCommand<string>(ExecuteQuery);
            var typeModels=_productTypeRepository.Context.Queryable<ProductType>().Includes(x => x.ProductDataInfo).ToList();
            ProductTypes=typeModels.ToObservableCollection();

            var productModels=_productInfoRepository.Context.Queryable<ProductData>().Includes(x=>x.WorkStationInfo).ToList();
            ProductInfos=productModels.ToObservableCollection();
        }

        private void ExecuteQuery(string search)
        {
            
        }
    }
}
