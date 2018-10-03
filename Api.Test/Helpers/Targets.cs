using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Test.Helpers
{
    public class Targets
    {
        [JsonProperty(PropertyName = "urls")]
        public List<string> Urls { get; set; }

        [JsonIgnoreAttribute]
        public List<UrlsErrors> UrlsError { get; set; }

        public Targets()
        {
            UrlsError = new List<Targets.UrlsErrors>();
        }
        public class UrlsErrors
        {
            public string Url { get; set; }
            public string ErrorDescription { get; set; }
        }
    }
}
