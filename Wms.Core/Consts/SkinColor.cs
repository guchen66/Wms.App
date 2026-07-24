using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Core.Consts
{
    public class SkinColor
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public SkinColor(string name, string color)
        {
            Name = name;
            Color = color;
        }
    }

    public class SkinColorList : ObservableCollection<SkinColor>
    {
        public SkinColorList()
        {
            Add(new SkinColor("Dark Green", "Dark.Green"));
            Add(new SkinColor("Dark Red", "Dark.Red"));
            Add(new SkinColor("Dark Blue", "Dark.Blue"));
            Add(new SkinColor("Light Blue", "Light.Blue"));
            Add(new SkinColor("Light Red", "Light.Red"));
            Add(new SkinColor("Light Green", "Light.Green"));
            // ... 添加其他颜色
        }
    }
}
