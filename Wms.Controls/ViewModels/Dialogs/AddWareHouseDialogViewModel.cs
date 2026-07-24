using Wms.Admin.IRepositorys;
using Wms.Controls.Mvvm;
using Wms.Core.Consts;
using Wms.Core.Dtos;
using Wms.Data.Models;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wms.Controls.ViewModels.Dialogs
{
   public class AddWareHouseDialogViewModel : BaseDialogAware
    {
        #region 字段、属性

        public string Title => "添加仓库弹窗";
        public event Action action;
        private IBaseRepository<WareHouse> _wareHouseRepository;
        private IBaseRepository<UserInfo> _userRepository;
        private WareHouseDto _wareHouseDto;

        public WareHouseDto WareHouseDto
        {
            get => _wareHouseDto??(_wareHouseDto=new WareHouseDto());
            set => SetProperty(ref _wareHouseDto, value);
        }

        #endregion

        public AddWareHouseDialogViewModel(IBaseRepository<WareHouse> wareHouseRepository, IBaseRepository<UserInfo> userRepository)
        {
            _wareHouseRepository = wareHouseRepository;
            _userRepository = userRepository;
            SaveCommand = new DelegateCommand<string>(ExecuteSave);
            CancelCommand = new DelegateCommand<string>(ExecuteCancel);
            _userRepository = userRepository;
        }

        #region 命令

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion

        #region 方法

        private void ExecuteSave(string parameter)
        {
            WareHouse wareHouse = new WareHouse()
            {
               WareHouseId=WareHouseDto.WareHouseId,
               WareHouseName =WareHouseDto.WareHouseName,
               ItemTotal=WareHouseDto.ItemTotal.ToInt(),
               ItemType=WareHouseDto.ItemType,
               Price=WareHouseDto.Price,
               CreateTime=DateValue,
               UpdateTime= DateValue,
               UserId= ++UserId,
               AssociatedPerson=WareHouseDto.AssociatedPerson,
            };
            _wareHouseRepository.Context.Insertable<WareHouse>(wareHouse).ExecuteCommand();
            RaiseRequestClose(new DialogResult(ButtonResult.OK));
        }

        static int UserId { get; set; }

        private void ExecuteCancel(string parameter)
        {
            RaiseRequestClose(new DialogResult(ButtonResult.No));
        }



        #endregion
    }
}
