using Kentor.PU_Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage PKNODPLUS(string arg)
        {
            System.Threading.Thread.Sleep(30); // Introduce production like latency

            string result;
            if (!TestPersons.TryGetValue(arg, out result))
            {
                // Returkod: 0001 = Sökt person saknas i registren 
                result = "13270001                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      _";
            }
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, System.Text.Encoding.GetEncoding("ISO-8859-1"), "text/plain");
            return resp;
        }
    }
}
