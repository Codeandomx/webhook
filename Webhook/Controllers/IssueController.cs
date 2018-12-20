using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webhook.Class;

namespace Webhook.Controllers
{
    public class IssueController : ApiController
    {

        // GET: api/Issue
        public string Get()
        {
            // Obtenemos una busqueda generica
            string result = JiraCreateClient.RunQuery("https://pandr01.atlassian.net/rest/api/latest/search");

            dynamic json = JsonConvert.DeserializeObject(result);

            return result;
        }

        // GET: api/Issue/5
        public string Get(string key)
        {
            // Base uri
            string uri = "https://pandr01.atlassian.net/rest/api/issue/";

            // Obtenemos una issue predeterminada
            string result = JiraCreateClient.RunQuery(uri+key);

            dynamic json = JsonConvert.DeserializeObject(result);

            return json.ToString();
        }

        // POST: api/Issue
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Issue/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Issue/5
        public void Delete(int id)
        {
        }
    }
}
