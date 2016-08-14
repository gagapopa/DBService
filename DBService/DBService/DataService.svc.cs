﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NLog;

namespace DBService
{
	public class DataService : IDataService
	{
        static Logger logger = LogManager.GetCurrentClassLogger();
		public string GetData(int value)
		{
			return string.Format("You entered: {0}", value);
		}

        public string GetUserLinks(string guid)
        {
            try
            {
                logger.Info("GetUserLinks: " + guid);

                string result;
                using (var context = new luxoftdatabaseEntities())
                {
                    result = context.getUserLinks(guid).FirstOrDefault();
                }
               
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return "ERROR:" + ex.Message;
            }
        }
	}
}
