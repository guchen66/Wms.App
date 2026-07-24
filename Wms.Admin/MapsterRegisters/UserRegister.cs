using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wms.Core.Dtos;
using Wms.Data.Models;
using Mapster;

namespace Wms.Admin.MapsterRegisters
{
    public class UserRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config
                .ForType<UserInfo, UserInfoDto>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Password, src => src.Password).Map(dest=>dest.RoleDto,src=>src.Role);

            config
                .ForType<UserInfoDto, UserInfo>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Password, src => src.Password).Map(dest=>dest.Role,src=>src.RoleDto);
        }
    }
}
