﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DBService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface IDataService
	{

        [OperationContract]
        string GetUserLinks(string guid);

        [OperationContract]
        string InsertLinkOrCreateUser(string fullLink, int? userId);

        [OperationContract]
        string IncrementLink(string linkId);
	}
}
