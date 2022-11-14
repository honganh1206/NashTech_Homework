using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace CoreRestSharpFW.APICore
{
    public class APIClient
    {
        public Uri baseUrl { get; set; }
        public string apiKey { get; set; }
        public RestClient RestClient { get; set; }

        public RestClient SetURL(Uri baseUrl)
        {
            this.baseUrl = baseUrl;
            RestClient = new RestClient(baseUrl);
            return RestClient;
        }
    }
}
