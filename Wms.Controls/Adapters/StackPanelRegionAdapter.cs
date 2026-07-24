using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wms.Controls.Adapters
{
    /// <summary>
    /// Prism默认的没有 StackPanel区域适配器，需要自定义
    /// </summary>
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            if (region == null) throw new ArgumentNullException();

            region.Views.CollectionChanged += (s, e) => 
            {
                if (e.Action==NotifyCollectionChangedAction.Add)
                {
                    foreach (var view in e.NewItems)
                    {
                        region.Add(view);
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
