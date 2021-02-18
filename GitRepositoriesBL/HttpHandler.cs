using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GitRepositoriesBL
{
    public class HttpHandler
    {

        /// <summary>
        /// Http Get Request Handler
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Get(string url)
        {
            string str_ReturnValue = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "my user agent";

            request.Method = "GET";
            request.ContentType = "application/json;charset=UTF-8";

         
            using (Stream s = request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    var jsonData = sr.ReadToEnd();
                    str_ReturnValue += jsonData.ToString();
                }
            }

            return str_ReturnValue;
        }
    }

}
