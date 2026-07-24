using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Core.Dtos
{
    public class UserInfoDto:BaseDto
    {
		private string _name;

		public string Name
		{
			get => _name;
			set => SetProperty(ref _name, value);
		}
		private string _password;

		public string Password
		{
			get => _password;
			set => SetProperty(ref _password, value);
		}


        private int _roleId;

        public int RoleId
        {
            get => _roleId;
            set => SetProperty(ref _roleId, value);
        }

		private RoleDto _roleDto;

		public RoleDto RoleDto
		{
			get => _roleDto;
			set => SetProperty(ref _roleDto, value);
		}

	}
}
