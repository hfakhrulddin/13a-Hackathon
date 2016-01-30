using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unirest_net.http;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Hackathon.Core.Domin;
using System.Xml;
using System.Xml.Linq;
namespace Hackathon.Core.Services
{
    public class LocationService
    {
        public static LocationInfo showLocation(string city, string state)
        {
            LocationInfo result;
            string url = ($"http://www.yaddress.net/api/address?%20AddressLine1=&AddressLine2={city}+{state}");
            string xml = WebGetRequest(url);
                var doc2 = JObject.Parse(xml);
                result = JsonConvert.DeserializeObject<LocationInfo>((doc2).ToString());
                return result;
        }
        public static string WebGetRequest(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
                Stream objStream;
                HttpWebResponse response;
                string retVal;
                StreamReader objReader;
                try
                {
                    response = request.GetResponse() as HttpWebResponse;
                }
                catch (WebException ex)
                {
                    response = ex.Response as HttpWebResponse;
                }
                objStream = response.GetResponseStream();
                objReader = new StreamReader(objStream);
                retVal = objReader.ReadToEnd();

                objReader.Dispose();
                objStream.Dispose();
                response.Dispose();
                return retVal;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}

