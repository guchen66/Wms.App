using Wms.Admin.Services;
using Wms.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Admin.IServices
{
    public interface IProductDataConfigService:IBaseService<ProductDataConfig>
    {
        List<ProductDataConfig> GetAllProductDataConfig();
        ProductDataConfig GetProductDataConfig();
    }
}
