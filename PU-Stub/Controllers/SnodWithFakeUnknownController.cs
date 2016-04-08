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
    public class SnodWithFakeUnknownController : SnodController
    {
        [Route("~/SnodWithFakeUnknown/PKNODPLUS/")]
        public override Task<HttpResponseMessage> PKNODPLUS(string arg)
        {
            return base.PKNODPLUS(arg);
        }

        [Route("~/SnodWithFakeUnknown/PKNOD/")]
        public override Task<HttpResponseMessage> PKNOD(string arg)
        {
            return base.PKNOD(arg);
        }

        [Route("~/SnodWithFakeUnknown/PKNODH/")]
        public override Task<HttpResponseMessage> PKNODH(string arg)
        {
            return base.PKNOD(arg);
        }

        protected override string GetTestPerson(string arg)
        {
            if (arg.Length != 12)
            {
                // Felaktigt format på inmatat personnummer
                return "13270020                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      _";
            }
            string result;
            if (!TestPersons.TryGetValue(arg, out result))
            {
                result = TestPersons["191212121212"];
                result = result.Replace("191212121212", arg).Replace("Tolvan    ", "Testperson").Replace("Tolvansson", "tEfternamn");
            }

            return result;
        }
    }
}
