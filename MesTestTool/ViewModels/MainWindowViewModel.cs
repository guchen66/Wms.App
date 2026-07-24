using MesTestTool.MES;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MesTestTool.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {
            UpLoadCommand = new DelegateCommand(async ()=> await ExecuteUpLoad());
        }

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

        public ICommand UpLoadCommand { get; set; }
    }
}
