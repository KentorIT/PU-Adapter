using Kentor.PU_Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace PU_Stub.Controllers
{
    public class SnodController : ApiController
    {
        private static readonly IDictionary<string, string> TestPersons;
        static SnodController()
        {
            TestPersons = Kentor.PU_Adapter.TestData.TestPersonsPuData.PuDataList
                .ToDictionary(p => p.Substring(8, 12)); // index by person number
        }

        [HttpGet]
        [Route("~/snod/PKNODPLUS/")]
        public async Task<HttpResponseMessage> PKNODPLUS(string arg)
        {
            await Task.Delay(30); // Introduce production like latency

            string result = GetTestPerson(arg);
            result = "0\n0\n1327\n" + result; // add magic initial lines, like production PU does
            return SendResponse(result);
        }

        [HttpGet]
        [Route("~/snod/PKNOD/")]
        public async Task<HttpResponseMessage> PKNOD(string arg)
        {
            await Task.Delay(30); // Introduce production like latency
            string result = GetTestPerson(arg);
            result = "0\n0\n704\n0704" + result.Substring(4, 699)
                .ToUpper().Replace('Ö', '\\')
                .Replace('Ä', '[')
                .Replace('Å', ']') + "_"; // add magic initial lines, like production PU does
            return SendResponse(result);
        }

        [HttpGet]
        public HttpResponseMessage AllPersons()
        {
            var allData = Kentor.PU_Adapter.TestData.TestPersonsPuData.PuDataList.Select(data => new PknodPlusData(data));
            var resp = this.Request.CreateResponse(HttpStatusCode.OK, allData);
            return SetCacheOneDay(resp);
        }

        private HttpResponseMessage SetCacheOneDay(HttpResponseMessage response)
        {
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                Public = true,
                MaxAge = new TimeSpan(1, 0, 0, 0),
            };

            return response;
        }

        private HttpResponseMessage SendResponse(string result)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, System.Text.Encoding.GetEncoding("ISO-8859-1"), "text/plain");
            return SetCacheOneDay(resp);
        }

        private static string GetTestPerson(string arg)
        {
            string result;
            if (!TestPersons.TryGetValue(arg, out result))
            {
                if (arg.StartsWith("99"))
                {
                    // Returkod: 0102 = Sökt reservnummer saknas i registren 
                    result = "13270102                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      _";
                }
                else
                {
                    // Returkod: 0001 = Sökt person saknas i registren 
                    result = "13270001                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      _";
                }
            }

            return result;
        }
    }
}
