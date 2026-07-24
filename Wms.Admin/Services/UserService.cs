using Wms.Admin.IRepositorys;
using Wms.Admin.IServices;
using Wms.Data.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Admin.Services
{
    public class UserService : BaseService<UserInfo>, IUserService
    {
        private readonly IUserRepository _db;
        public UserService(IUserRepository repository) : base(repository)
        {
            _db = repository;
        }     
    }
}      

