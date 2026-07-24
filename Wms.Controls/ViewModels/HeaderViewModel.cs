using ControlzEx.Theming;
using Wms.Controls.Mvvm;
using Wms.Core.Consts;
using Microsoft.VisualBasic.ApplicationServices;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wms.Data;
using Wms.Admin.IServices;
using Wms.Admin.Services;
namespace Wms.Controls.ViewModels
{
    public class HeaderViewModel : BaseViewModel
    {
        IProductDataConfigService _productDataConfigService;
        public HeaderViewModel(IContainerProvider provider) : base(provider)
        {
            _productDataConfigService=provider.Resolve<IProductDataConfigService>();
             WindowDataHandler.Config= _productDataConfigService.GetProductDataConfig();
             LoadedCommand = new DelegateCommand(GetBatch);
        }


        #region HeaderView Skin颜色修改

        private string _role;

        public string Batch
        {
            get => _role;
            set => SetProperty(ref _role, value);
        }

        public void GetBatch()
        {         
            if (WindowDataHandler.Config!=null)
            {
                Batch = WindowDataHandler.Config.Batch;
            }
        }

        private SkinColor _selectedSkinColor;

        public SkinColor SelectedSkinColor
        {
            get => _selectedSkinColor;
            set
            {
                if (_selectedSkinColor != value) 
                {
                    _selectedSkinColor = value;
                    ThemeManager.Current.ChangeTheme(Application.Current, _selectedSkinColor.Color);
                    RaisePropertyChanged();
                };
            }
        }


        #endregion

        //TextBox初始为Empty
        private string search = string.Empty;

        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(); }
        }

        public ICommand LoadedCommand { get; set; } 
    }
}
