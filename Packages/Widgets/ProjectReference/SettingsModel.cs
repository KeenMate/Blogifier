using System;
using System.Collections.Generic;
using System.Text;

namespace Blogifier.Widgets.ProjectReference
{
	public class SettingsModel
	{
		public string FirstVal { get; set; }
		public int SomeInt { get; set; }
		public List<string> SomeList { get; set; }
		public bool Checkbox { get; set; }
		public Dictionary<string, object> SomeDictionary { get; set; }
	}
}
