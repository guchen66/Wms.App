using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Core.Dtos
{
    public class WareHouseDto : BaseDto
    {
        private int _wareHouseId;

        public int WareHouseId
        {
            get => _wareHouseId;
            set => SetProperty(ref _wareHouseId, value);
        }

        private string _wareHouseName;

        public string WareHouseName
        {
            get => _wareHouseName;
            set => SetProperty(ref _wareHouseName, value);
        }

        private int? _itemTotal;

        public int? ItemTotal
        {
            get => _itemTotal;
            set => SetProperty(ref _itemTotal, value);
        }

        private string _itemType;

        public string ItemType
        {
            get => _itemType;
            set => SetProperty(ref _itemType, value);
        }

        private decimal _price;

        public decimal Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private string _tag;

        public string Tag
        {
            get => _tag;
            set => SetProperty(ref _tag, value);
        }

        private int _userId;

        public int UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private string _associatedPerson;

        public string AssociatedPerson
        {
            get => _associatedPerson;
            set => SetProperty(ref _associatedPerson, value);
        }

    }
}
