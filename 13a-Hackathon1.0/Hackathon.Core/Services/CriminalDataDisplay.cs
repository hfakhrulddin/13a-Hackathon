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

namespace Hackathon.Core.Servives
{
    public class CriminalDataDisplay
    {

        public static  List<CriminalInfo> showData(string lat, string lon)
        {
            // 1. Create a HTTP request & Cast it to http web request.
            var httpRequest = (HttpWebRequest)HttpWebRequest.Create($"https://jgentes-Crime-Data-v1.p.mashape.com/crime?enddate=9%2F25%2F2015&lat={lat}&long={lon}&startdate=9%2F19%2F2015");
            ///MainWindow.Location
            // 2. Make this an HTTP POST request. (Remember, GET/POST/UPDATE/DELETE)
            httpRequest.Method = "GET";

            // 3. Add headers to this HTTP request
            httpRequest.Headers.Add("X-Mashape-Key", "BEMSEuC7z3mshotw4vSCrc6oM8g6p15uKaSjsn7m5vIxhZXf7j");
            httpRequest.Accept = "application/json";


            // 4. Get our response
            var httpResponse = httpRequest.GetResponse();
            // 5. Read the response (which is JSON) and turn it into a Quote object.
            
            
            // 5a. Get the stream from the response
            var httpResponseStream = httpResponse.GetResponseStream();

            // 5b. Create an object that can read this Stream in an easy way
            using (var streamReader = new StreamReader(httpResponseStream))

               {
                // 5c. Read the JSON
                string json = streamReader.ReadToEnd();
               List<CriminalInfo> crminals =  JsonConvert.DeserializeObject <List<CriminalInfo>>(json);


                return crminals;
              }
        }
    }
}