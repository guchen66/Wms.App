using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Wms.Admin.IRepositorys;
using Wms.Admin.Repositorys;
using Wms.Communication.MES;
using Wms.Controls.Mvvm;
using Wms.Core.Dtos;
using Wms.Core.Extensions;
using Wms.Data.Models;
using MahApps.Metro.Controls.Dialogs;
using MiniExcelLibs;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Wms.Controls.ViewModels
{
    public class WareHouseViewModel : BaseNavigationAware
    {
        #region 属性、字段

        private readonly IBaseRepository<WareHouse> _wareHouseRepository;

        private ObservableCollection<WareHouseDto> _wareHouseList;
        public ObservableCollection<WareHouseDto> WareHouseList
        {
            get => _wareHouseList;
            set=>SetProperty(ref _wareHouseList, value);
        }
        #endregion

        #region 命令

        public ICommand QueryCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DownLoadCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand UpLoadMesCommand { get; set; }
        #endregion

        public WareHouseViewModel(IBaseRepository<WareHouse> wareHouseRepository, IContainerProvider provider): base(provider)
        {
            _wareHouseRepository = wareHouseRepository;
            WareHouseList = new ObservableCollection<WareHouseDto>();
            QueryCommand = new DelegateCommand<string>(ExecuteQuery);
            AddCommand = new DelegateCommand(ExecuteAdd);
            UpdateCommand = new DelegateCommand<int?>(ExecuteUpdate);
            DeleteCommand = new DelegateCommand<int?>(ExecuteDelete);
            DownLoadCommand = new DelegateCommand<string>(ExecuteDownLoad);
            RefreshCommand = new DelegateCommand(ExecuteRefresh);
            UpLoadMesCommand = new DelegateCommand(async()=>await ExecuteUpLoad());
        }

       
        #region 方法

        //TextBox初始为Empty
        private string _search = string.Empty;
        public string Search
        {
            get => _search;
            set=> SetProperty(ref _search, value);
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void ExecuteQuery(string search)
        {
            if (search==null)
            {
               var wareHouseList= _wareHouseRepository.Context.Queryable<WareHouse>().ToList();
               WareHouseList= DefaultMapper.Map<List<WareHouseDto>>(wareHouseList).ToObservableCollection();
            }
            else
            {
                var dataList = _wareHouseRepository.Context.Queryable<WareHouse>()
               .ToList()
               .Where(it =>
                   it.Id.ToString().Contains(Search)
                   || it.WareHouseName.Contains(Search)
                   || it.Price.ToString().Contains(Search));
                WareHouseList = DefaultMapper.Map<List<WareHouseDto>>(dataList).ToObservableCollection();
            }           
        }

        /// <summary>
        /// 添加 如果将刷新传递过去，那么DialogCompleted回调可以不写
        /// </summary>
        private void ExecuteAdd()
        {
            DialogParameters paramters = new DialogParameters();
            paramters.Add("RefreshValue", new Action(Refresh));
            DialogService.ShowDialog("AddWareHouseDialog", DialogCompleted);
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
                ExecuteAutoRefresh();
            }
            else
            {
                ExecuteAutoRefresh();
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        private void ExecuteUpdate(int? id)
        {
            var dataList = _wareHouseRepository.Context.Queryable<WareHouse>().Where(it => it.Id == id).ToList();
            DialogParameters paramters = new DialogParameters();
            paramters.Add("dataList", dataList);
            paramters.Add("RefreshValue", new Action(Refresh));
            DialogService.ShowDialog("UpdateWareHouseDialog", paramters, DialogCompleted);
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="search"></param>
        private async void ExecuteDownLoad(string search)
        {
            var fileName = $"{DateTime.Now:yyyyMMddHHmmss}-仓储.xlsx";
            var filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                fileName
            );
            var dataList = _wareHouseRepository.Context.Queryable<WareHouse>().ToList();
            MiniExcel.SaveAs(filePath, RewriteTitle(dataList));
            await CompletedDialogAsync();
           
        }

        private IEnumerable<Dictionary<string, object>> RewriteTitle(List<WareHouse> cargoModels)
        {
            foreach (var item in cargoModels)
            {
                var dict = new Dictionary<string, object>();
                dict.Add("物资Id", item.WareHouseName);
                dict.Add("物资名称", item.WareHouseName);
                dict.Add("物资类型", item.ItemType);
              //  dict.Add("物资单位", item.Amount);
                dict.Add("价格", item.Price);
                dict.Add("备注", item.Tag);
                dict.Add("创建日期", item.CreateTime);
                dict.Add("操作员Id", item.UserId);
                dict.Add("操作员", item.AssociatedPerson);

                yield return dict;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        private async void ExecuteDelete(int? ids)
        {
            var model = _wareHouseRepository.Context.Queryable<WareHouse>().Where(it => it.Id == ids);

            if (model != null)
            {
                var result= await ShowBaseNavigationAwareMessageDialogAsync();
                if (result == MessageDialogResult.Affirmative)
                {
                    //刷新
                    _wareHouseRepository.Context.Deleteable<WareHouse>().In(ids).IsLogic().ExecuteCommand();
                    ExecuteAutoRefresh();
                }
                if (result == MessageDialogResult.Negative)
                {
                    ExecuteAutoRefresh();
                }
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        private void ExecuteRefresh()
        {
            DoRefresh();
        }

        //用来刷新界面
        public void Refresh()
        {
            var dataList = _wareHouseRepository.Context.Queryable<WareHouse>().Where(it => it.WareHouseName == Search).ToList();

          //  WareHouseList = new ObservableCollection<WareHouse>();
            if (dataList != null)
            {
              //  _wareHouseRepository.QueryListAsync(dataList);
               
            }
        }

        /// <summary>
        /// 自动刷新
        /// </summary>
        private void ExecuteAutoRefresh()
        {
            var wareHouses = _wareHouseRepository.Context.Queryable<WareHouse>().ToList();
            var wareHouseDtos = DefaultMapper.Map<List<WareHouseDto>>(wareHouses);
            WareHouseList.Clear();
            if (wareHouses != null)
            {
                foreach (var wareHouse in wareHouseDtos)
                {
                    Dispatcher.CurrentDispatcher.Invoke(() => WareHouseList.Add(wareHouse));
                }
            }
        }
        /// <summary>
        /// 手动刷新
        /// </summary>
        private async void DoRefresh()
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "确定",
                NegativeButtonText = "取消",
                ColorScheme = MetroDialogColorScheme.Accented,
                AnimateShow = true,
                AnimateHide = false,
            };
            var controller = await this.DialogCoordinator.ShowProgressAsync(
                this,
                "请稍等",
                "正在刷新数据...",
                settings: mySettings
            );

            controller.SetIndeterminate();
            Search = string.Empty;
            this.Refresh();
            await Task.Delay(3000); // Wait for 3 seconds
            await controller.CloseAsync();
        }

        /// <summary>
        /// 数据上传MES
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private async Task ExecuteUpLoad()
        {
            var apiClient = new MesApiClient();
            var data = new
            {
                // 构建要上传的数据对象
                OrderId = "123",
                PartNumber = "456"
            };

            bool success = await apiClient.UploadDataToMesAsync(data);
            if (success)
            {
                MessageBox.Show("上传成功");
            }
        }

        #endregion
    }
}
