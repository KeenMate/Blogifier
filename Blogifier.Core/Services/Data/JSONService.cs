using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogifier.Core.Services
{
	public class JSONService : IJSONService
	{
		public string ObjectToJSONString(object obj)
		{
			return JsonConvert.SerializeObject(obj);
		}

		public T JSONStringToObject<T>(string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}
	}
}
