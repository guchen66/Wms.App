using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Core.Helpers
{
    /// <summary>
    /// Excel操作帮助类
    /// </summary>
    public static class ExcelHelper
    {
        public static void ExecuteDowLoad(string filePath,object value)
        {
            MiniExcel.SaveAs(filePath, value);
        }

        private static IEnumerable<Dictionary<string, object>> RewriteTitle<TEntity>(List<TEntity> models)
        {
            var dict = new Dictionary<string, object>();
            foreach (var item in models)
            {
               
              /*  dict.Add("物资Id", item.WareHouseName);
                dict.Add("物资名称", item.WareHouseName);
                dict.Add("物资类型", item.ItemType);
                //  dict.Add("物资单位", item.Amount);
                dict.Add("价格", item.Price);
                dict.Add("备注", item.Tag);
                dict.Add("创建日期", item.CreateTime);
                dict.Add("操作员Id", item.UserId);
                dict.Add("操作员", item.AssociatedPerson);
*/
                yield return dict;
            }
        }
    }
}
