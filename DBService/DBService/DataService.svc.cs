using System;
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
        public string InsertLinkOrCreateUser(string fullLink, int? userId)
        {
            try
            {
                logger.Info("InsertLinkOrCreateUser: " + "fullLink " + fullLink + "userId " + userId);

                string result;
                using (var context = new luxoftdatabaseEntities())
                {
                    result = context.insertLinkOrCreateUser(fullLink, userId).FirstOrDefault();
                }
               
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return "ERROR:" + ex.Message;
            }
        }
        public string IncrementLink(string linkId)
        {
            try
            {
                logger.Info("IncrementLink: " + "linkId " + linkId);

                string result;
                using (var context = new luxoftdatabaseEntities())
                {
                    result = context.incrementLink(linkId.DecodeFromBase()).FirstOrDefault();
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
