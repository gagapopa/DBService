using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DBService
{
	public class DataService : IDataService
	{
		public string GetData(int value)
		{
			return string.Format("You entered: {0}", value);
		}
	}
}
