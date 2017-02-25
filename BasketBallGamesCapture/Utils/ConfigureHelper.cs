using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BasketBallGamesCapture.Utils
{
    public static class ConfigureHelper
    {
        public static string HistoryConnectString
        {
            get
            {
                return GetConnectString("HistoryAlertDB");
            }
        }

        /// <summary>
        /// Get normal string by specific name
        /// </summary>
        /// <param name="name">The name of the value.</param>
        /// <returns></returns>
        private static string GetConnectString(string name)
        {
            //    string value = CloudConfigurationManager.GetSetting(name);

            string value = WebConfigurationManager.ConnectionStrings[name].ConnectionString;

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new NullReferenceException(string.Format("Cannot get the conect string {0}", name));
            }

            return value;
        }

    }
}