using Wms.Admin.IRepositorys;
using Wms.Admin.Repositorys;
using Wms.Controls.Mvvm;
using Wms.Controls.Views;
using Wms.Controls.Views.OrderSign;
using Wms.Core.Common;
using Wms.Core.Consts;
using Wms.Core.Extensions;
using Wms.Data.Models;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wms.Controls.ViewModels
{
    public class OrderManageViewModel : BaseNavigationAware
    {

        private readonly IBaseRepository<OrderHeaderItem> _orderRepository;
        private string _selectedItemValue;

        public string SelectedItemValue
        {
            get => _selectedItemValue;
            set => SetProperty(ref _selectedItemValue, value);
        }
        private OrderState _orderState;

        public OrderState OrderState
        {
            get => _orderState;
            set => SetProperty(ref _orderState, value);
        }

        private ObservableCollection<OrderHeaderItem> _orderHeaderItems;

        public ObservableCollection<OrderHeaderItem> OrderHeaderItems
        {
            get => _orderHeaderItems??(_orderHeaderItems=new ObservableCollection<OrderHeaderItem>());
            set => SetProperty(ref _orderHeaderItems, value);
        }

        public OrderManageViewModel(IContainerProvider provider, IBaseRepository<OrderHeaderItem> orderRepository) : base(provider)
        {
            _orderRepository = orderRepository;

            RegionManager.RegisterViewWithRegion(RegionNames.OrderManagerRegion, typeof(AllOrderListView));
            
            LoadedCommand = new DelegateCommand(ExecuteLoaded);
        }

        private async void ExecuteLoaded()
        {
            var orders = await _orderRepository.Context.Queryable<OrderHeaderItem>().Includes(x=>x.GoodInfos).ToListAsync();        //连同关联表字段一起查询
            OrderHeaderItems=orders.ToObservableCollection();
          //  _orderRepository.Context.Queryable<OrderHeaderItem>().ToList().ForEach(item => { OrderHeaderItems.Add(item); });
        }

        public ICommand LoadedCommand { get; set; }
        public ICommand UpdateGoodCommand { get; set; }
        public ICommand DelGoodCommand { get; set; }
    }
}
