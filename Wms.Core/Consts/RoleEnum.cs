using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wms.Core.Attributes;

namespace Wms.Core.Consts
{
    /// <summary>
    /// 这里的RoleRemark和数据库Role表的主键相对应
    /// </summary>
    public enum RoleEnum
    {
        [RoleRemark(1)]
        普通员工,

        [RoleRemark(2)]
        组长,

        [RoleRemark(3)]
        科长,

        [RoleRemark(4)]
        经理,

        [RoleRemark(5)]
        管理员,

        [RoleRemark(6)]
        超级管理员,

        [RoleRemark(7)]
        开发者,
    }
}
