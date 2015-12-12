using Kentor.PU_Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public async Task<HttpResponseMessage> PKNODPLUS(string arg)
        {
            await Task.Delay(30); // Introduce production like latency

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
            result = "0\n0\n1327\n" + result; // add magic initial lines, like production PU does
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, System.Text.Encoding.GetEncoding("ISO-8859-1"), "text/plain");
            return resp;
        }

        [HttpGet]
        public HttpResponseMessage AllPersons()
        {
            var allData = Kentor.PU_Adapter.TestData.TestPersonsPuData.PuDataList.Select(data => new PknodPlusData(data));
            return this.Request.CreateResponse(HttpStatusCode.OK, allData);
        }
    }
}
