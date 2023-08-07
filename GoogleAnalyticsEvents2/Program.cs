using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnalyticsEvents2
{

    using RestSharp;
    using Newtonsoft.Json;

    public class GoogleAnalyticsEvent
    {
        public string name { get; set; }
    }

    public class GoogleAnalyticsRequest
    {
        public string client_id { get; set; }
        public GoogleAnalyticsEvent[] events { get; set; }
    }

    public class GoogleAnalyticsClient
    {
        public void SendGoogleAnalyticsEvent()
        {
            const string measurementId = "G------------";
            const string apiSecret = "q--------------";

            var client = new RestClient("https://www.google-analytics.com/mp/collect");
            var request = new RestRequest(Method.POST);

            var googleAnalyticsRequest = new GoogleAnalyticsRequest
            {
                client_id = Guid.NewGuid().ToString(),
                events = new GoogleAnalyticsEvent[]
                {
                new GoogleAnalyticsEvent { name = "suggested_page_allvendors" }
                }
            };

            string jsonBody = JsonConvert.SerializeObject(googleAnalyticsRequest);

            request.AddParameter("measurement_id", measurementId);
            request.AddParameter("api_secret", apiSecret);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // The request was successful
                // You can handle the response here if needed
            }
            else
            {
                // Handle the error
            }
        }
    }

    // Usage example
    public class Program
    {
        static void Main()
        {
            var googleAnalyticsClient = new GoogleAnalyticsClient();
            googleAnalyticsClient.SendGoogleAnalyticsEvent();
        }
    }

}
