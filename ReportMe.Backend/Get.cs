using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using Gurock.TestRail;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ReportMe.Backend
{
    public class Get
    {
        public JToken Trequest(string call, string PID, string user, string pass)
        {
            JToken res;

            APIClient client = new APIClient("https://testrail/");

            client.User = user;
            client.Password = pass;
            try
            {
                res = JToken.FromObject(client.SendGet(call + PID));
            }
            catch (Gurock.TestRail.APIException e)
            {
                res = null;
            }


            return res;

        }
        async Task<string> GetResponseString(HttpResponseMessage a)
        {
            var js = "";
            using (HttpContent content = a.Content)
            {
                string json = await content.ReadAsStringAsync();
                js = json;
            }
            return js;
        }
        public string Jrequest(string jiraInstanceNumber, string call, string va, string auth)
        {

            string jsonResponse;
            HttpClientHandler handler = new HttpClientHandler();
            var client = new HttpClient(handler);
            var byteArray = Encoding.ASCII.GetBytes(auth);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", auth);
            client.BaseAddress = new Uri($"https://mdc-tomcat-jira{jiraInstanceNumber}.ubisoft.org/jira/rest/api/2/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                                                                                                                                     //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "filter/favourite");
            var result = client.GetAsync(call + va).Result;

            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest || result.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                jsonResponse = "errorMessages";
            }
            else
            {
                Task<string> ret = GetResponseString(result);
                jsonResponse = ret.Result;
            }

            return jsonResponse;
        }
    }
}
