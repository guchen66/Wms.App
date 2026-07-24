using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Core.Dtos
{
    public class OrderHeaderItemDto:BaseDto
    {
		private string _title;

		public string Title
		{
			get => _title;
			set => SetProperty(ref _title, value);
		}

		private string _content;

		public string Content
		{
			get => _content;
			set => SetProperty(ref _content, value);
		}

		private string _path;

		public string Path
		{
			get => _path;
			set => SetProperty(ref _path, value);
		}

	}
}
