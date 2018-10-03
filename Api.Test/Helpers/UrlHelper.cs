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
                    var request = HttpWebRequest.Create(url);
                    request.Method = "HEAD";
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
