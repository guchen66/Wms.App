using Wms.Admin.IRepositorys;
using Wms.Controls.Mvvm;
using Wms.Core.Dtos;
using Wms.Data.Models;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wms.Controls.ViewModels.Dialogs
{
    public class UpdateWareHouseDialogViewModel : BaseDialogAware
    {
        #region 属性、字段

        public string Title => "修改UserInfo弹窗";

        public event Action action;
        List<WareHouse> UserInfos = null;
        public IBaseRepository<WareHouse> _wareHouseRepository;

        /// <summary>
        /// 界面通过Dto绑定
        /// </summary>
        private WareHouseDto _wareHouseDto;

        public WareHouseDto WareHouseDto
        {
            get => _wareHouseDto ?? (_wareHouseDto = new WareHouseDto());
            set => SetProperty(ref _wareHouseDto, value);
        }

        /// <summary>
        /// 接收主界面传输过来值，并赋值给WareHouseDto
        /// </summary>
        public List<WareHouse> wareHouses = null;

        private ObservableCollection<WareHouse> _wareHouseList;

        public ObservableCollection<WareHouse> WareHouseList
        {
            get { return _wareHouseList; }
            set { SetProperty(ref _wareHouseList, value); }
        }
        private DateTime _dateValue = DateTime.Now;
        public DateTime DateValue
        {
            get { return _dateValue; }
            set { SetProperty(ref _dateValue, value); }
        }
        #endregion

        public UpdateWareHouseDialogViewModel(IBaseRepository<WareHouse> wareHouseRepository)
        {
           _wareHouseRepository = wareHouseRepository;
            SaveCommand = new DelegateCommand<int?>(ExecuteSave);
            CancelCommand = new DelegateCommand<string>(ExecuteCancel);
        }

        #region 命令

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion

        #region 方法

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("dataList"))
            {
                wareHouses = parameters.GetValue<List<WareHouse>>("dataList");
                foreach (var wareHouse in wareHouses)
                {
                    WareHouseDto.Id = wareHouse.Id;
                    WareHouseDto.WareHouseId=wareHouse.WareHouseId;
                    WareHouseDto.WareHouseName=wareHouse.WareHouseName;
                    WareHouseDto.ItemTotal=wareHouse.ItemTotal;
                    WareHouseDto.ItemType=wareHouse.ItemType;
                    WareHouseDto.Price=wareHouse.Price;
                    WareHouseDto.AssociatedPerson=wareHouse.AssociatedPerson;
                    WareHouseDto.UpdateTime= (DateTime)wareHouse.UpdateTime;
                }
            }
        }

        private void ExecuteSave(int? id)
        {
            var updatedWareHouses = _wareHouseRepository.Context.Queryable<WareHouse>().Where(x => x.Id == id).First();
            if (updatedWareHouses != null)
            {
                updatedWareHouses.WareHouseName = WareHouseDto.WareHouseName;
                updatedWareHouses.ItemTotal=WareHouseDto.ItemTotal.ToInt();
                updatedWareHouses.ItemType=WareHouseDto.ItemType;
                updatedWareHouses.Price=WareHouseDto.Price;
                updatedWareHouses.Tag=WareHouseDto.Tag;
                updatedWareHouses.UserId = 1;
                updatedWareHouses.AssociatedPerson=WareHouseDto.AssociatedPerson;
                updatedWareHouses.UpdateTime=DateTime.Now;
                
                var s = _wareHouseRepository.Context.Updateable(updatedWareHouses).ExecuteCommand();
            }
            RaiseRequestClose(new DialogResult(ButtonResult.OK));
        }

        private void ExecuteCancel(string parameter)
        {
            RaiseRequestClose(new DialogResult(ButtonResult.No));
            //   RequestClose?.Invoke(new DialogResult(ButtonResult.No));      // 使用基类后失效
        }

        #endregion
    }
}
