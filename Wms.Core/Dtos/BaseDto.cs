using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Core.Dtos
{
    public class BaseDto : BindableBase
    {
        private int _id;

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }


        private DateTime _createTime;

        public DateTime CreateTime
        {
            get => _createTime;
            set => SetProperty(ref _createTime, value);
        }


        private DateTime _updateTime;

        public DateTime UpdateTime
        {
            get => _updateTime;
            set => SetProperty(ref _updateTime, value);
        }

    }
}
