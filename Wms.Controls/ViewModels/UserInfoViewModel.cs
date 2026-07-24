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
using SqlSugar;
namespace Wms.Controls.ViewModels
{
    public class UserInfoViewModel :  BaseNavigationAware
    {
        #region 属性、字段
        
        private ObservableCollection<UserInfoDto> _userInfos;
        public ObservableCollection<UserInfoDto> UserInfos
        {
            get =>_userInfos?? (_userInfos = new ObservableCollection<UserInfoDto>());
            set =>SetProperty(ref _userInfos, value);
        }
        private IBaseRepository<UserInfoDto> _userRepository;

        #endregion

        #region 命令

        public ICommand LoadedCommand { get; set; }
        public ICommand QueryUserCommand { get; set; }
        public ICommand AddUserCommand { get; set; }
        public ICommand UpdateUserCommand { get; set; }
        public ICommand DelUserCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        #endregion

        List<User> dataList = new List<User>();

        private DispatcherTimer _timer;
        private bool _isDelaying;
        public UserInfoViewModel(IBaseRepository<UserInfoDto> userRepository,IContainerProvider provider) : base(provider)
        {
            _userRepository = userRepository;
         
            LoadedCommand = new DelegateCommand(ExecuteIniting);
            QueryUserCommand = new DelegateCommand(ExecuteQueryUser);
            AddUserCommand = new DelegateCommand(ExecuteAddUser);
            UpdateUserCommand = new DelegateCommand<int?>(ExecuteUpdateUser);
            DelUserCommand = new DelegateCommand<int?>(ExecuteDelUser);
            RefreshCommand = new DelegateCommand(ExecuteRefresh);

        }

        #region 方法

        /// <summary>
        /// 界面初始化
        /// </summary>
        private async void ExecuteIniting()
        {
           
            await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
            try
            {
                // 初始化查询过滤器，添加全局过滤条件
              //  DbScoped.Sugar.QueryFilter.AddTableFilter<UserInfo>(it => it.IsDelete == "0");
              //  _userRepository.Context.QueryFilter.AddTableFilter<UserInfo>(x => x.IsDelete == "0");
                var users = await _userRepository.Context.Queryable<UserInfo>().Includes(x => x.Role).ToListAsync();        //连同关联表字段一起查询
                UserInfos = DefaultMapper.Map<List<UserInfoDto>>(users).ToObservableCollection();
            }
            catch (Exception ex)
            {
               
                // 错误处理，例如记录日志或显示错误提示
                ShowProgressDialogAsync();
            }
        }

        /// <summary>
        /// 查询User
        /// </summary>
        private async void ExecuteQueryUser()
        {
            var users = await _userRepository.Context.Queryable<UserInfo>().Includes(x => x.Role).Where(it => it.Id.ToString().Contains(SearchContent)
                                       || it.Name.Contains(SearchContent)
                                       || it.Password.Contains(SearchContent)).ToListAsync();
            var userDtos = DefaultMapper.Map<List<UserInfoDto>>(users);
            UserInfos = userDtos.ToObservableCollection();
        }

        /// <summary>
        /// 添加
        /// </summary>
        private void ExecuteAddUser()
        {
            DialogParameters paramters = new DialogParameters();
            paramters.Add("RefreshValue", new Action(ExecuteAutoRefresh));
            DialogService.ShowDialog("AddUserInfoDialog", paramters, DialogCompleted);
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

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        private void ExecuteUpdateUser(int? id)
        {
            var dataList = _userRepository.Context.Queryable<UserInfo>().Where(it => it.Id == id).ToList();
            DialogParameters paramters = new DialogParameters();
            paramters.Add("dataList", dataList);

            paramters.Add("RefreshValue", new Action(ExecuteAutoRefresh));

            DialogService.ShowDialog("UpdateUserInfoDialog", paramters, r =>
            {
                if (r.Result == ButtonResult.Yes)
                {
                    //刷新
                    this.ExecuteAutoRefresh();
                }
            });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        private async void ExecuteDelUser(int? ids)
        {
            var model = _userRepository.Context.Queryable<UserInfo>().Where(it => it.Id == ids);
            if (model != null)
            {
                var result = await ShowBaseNavigationAwareMessageDialogAsync();
                if (result == MessageDialogResult.Affirmative)
                {
                    _userRepository.Context.Deleteable<UserInfo>().In(ids).IsLogic().ExecuteCommand();
                    ExecuteAutoRefresh();
                }
                if (result == MessageDialogResult.Negative)
                {
                    ExecuteAutoRefresh();
                }
            }
        }

        /// <summary>
        /// 自动刷新
        /// </summary>
        private void ExecuteAutoRefresh()
        {
            var users = _userRepository.Context.Queryable<UserInfo>().Includes(x => x.Role).ToList();
            var userDtos = DefaultMapper.Map<List<UserInfoDto>>(users);
            UserInfos.Clear();
            if (users != null)
            {
                foreach (var user in userDtos)
                {
                    Dispatcher.CurrentDispatcher.Invoke(() => UserInfos.Add(user));
                }
            }
        }

        //TextBox初始为Empty
        private string searchContent = string.Empty;

        public string SearchContent
        {
            get { return searchContent; }
            set
            {
                searchContent = value; RaisePropertyChanged();
                if (_timer == null)
                {
                    _timer = new DispatcherTimer();
                    _timer.Interval = TimeSpan.FromSeconds(1);
                    _timer.Tick += _timer_Tick;
                }
                if (!_isDelaying)
                {
                    _isDelaying = true;
                    _timer.IsEnabled = false;
                    _timer.Start();
                }
            }
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            //取消上一次操作
            _timer.Stop();
            _isDelaying = false;

            //执行搜索操作
            //   ExecuteQueryCmd();
        }



        /// <summary>
        /// 手动刷新
        /// </summary>
        private async void ExecuteRefresh()
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "确定",
                NegativeButtonText = "取消",
                ColorScheme = MetroDialogColorScheme.Accented,
                AnimateShow = true,
                AnimateHide = false,

            };
            var controller = await this.DialogCoordinator.ShowProgressAsync(this, "请稍等", "正在刷新数据...", settings: mySettings);

            controller.SetIndeterminate();
            SearchContent = string.Empty;
            this.ExecuteAutoRefresh();
            await Task.Delay(3000); 
            await controller.CloseAsync();
        }

        #endregion
    }
}
