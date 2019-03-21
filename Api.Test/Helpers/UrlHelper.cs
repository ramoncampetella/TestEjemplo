using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Api.Test.Helpers
{
    public class UrlHelper
    {
        public Targets ObtenerTarget(string file) {

            
            Targets targets = JsonConvert.DeserializeObject<Targets>(File.ReadAllText(file));

            return targets;
            
        }

        public void TestUrlTargets(Targets targets)
        {
            

            foreach (var url in targets.Urls)
            {
                HttpStatusCode result = default(HttpStatusCode);
                try
                {
                    var request = (HttpWebRequest)HttpWebRequest.Create(url);
                    //request.ContentType = "text/html";
                    request.AllowAutoRedirect = false;
                    request.Method = "GET";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                    request.Headers.Add("Upgrade-Insecure-Requests", "1");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                    request.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.155 Safari/537.36";

                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response != null)
                        {
                            result = response.StatusCode;
                            response.Close();
                        }
                    }

                }
                catch (WebException ex)
                {
                    targets.UrlsError.Add(new Targets.UrlsErrors() { Url = url, ErrorDescription = ex.Message });
                }

            }

        }
    }
}


