using Wms.Admin.IRepositorys;
using Wms.Controls.Mvvm;
using Wms.Core.Extensions;
using Wms.Data.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wms.Controls.ViewModels
{
    public class SetViewModel : BaseNavigationAware
    {
        private readonly IBaseRepository<SetConfigInfo> _setRepository;
        private ObservableCollection<SetConfigInfo> _settingSources;

        public ObservableCollection<SetConfigInfo> SettingSources
        {
            get => _settingSources??(_settingSources=new ObservableCollection<SetConfigInfo>());
            set => SetProperty(ref _settingSources, value);
        }

        public SetViewModel(IBaseRepository<SetConfigInfo> setRepository,IContainerProvider provider) : base(provider)
        {
            _setRepository = setRepository;
            var models=_setRepository.Context.Queryable<SetConfigInfo>().ToList();
            SettingSources = models.ToObservableCollection();
            OpenSettingCommand = new DelegateCommand<string>(ExecuteOpenSet);
        }

        private void ExecuteOpenSet(string dialogName)
        {
            DialogParameters paramters = new DialogParameters();
          //  paramters.Add("RefreshValue", new Action(ExecuteAutoRefresh));
            DialogService.ShowDialog(dialogName, paramters, DialogCompleted);
        }


        /// <summary>
        /// 执行弹窗关闭操作，
        /// 我的刷新操作在AddUserInfoDialogViewModel内部完成，这里可以省略
        /// </summary>
        /// <param name="result"></param>
        private void DialogCompleted(IDialogResult result)
        {
            if (result.Result == ButtonResult.OK)
            {
                // HandyControl.Controls.Dialog.Show(new ErrorDialog());
                //   ExecuteRefresh();
            }
            else
            {
                //  HandyControl.Controls.Dialog.Show(new ErrorDialog());
            }
        }

        public ICommand OpenSettingCommand { get; set; }
    }

}
