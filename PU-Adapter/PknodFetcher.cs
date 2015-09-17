using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Kentor.PU_Adapter
{
    public class PknodFetcher
    {
        public string Password { get; set; }
        public Uri PknodUrl { get; set; }
        public string UserName { get; set; }
        public PknodFetcher()
        {
            this.PknodUrl = new Uri(Properties.Settings.Default.PknodUrl);
            this.UserName = Properties.Settings.Default.UserName;
            this.Password = Properties.Settings.Default.Password;
        }

        public string FetchPkNodplusString(string personNumber)
        {
            try
            {
                WebClient wc = new WebClient();
                if (!string.IsNullOrEmpty(UserName))
                {
                    wc.Credentials = new NetworkCredential(UserName, Password);
                }
                var data = wc.DownloadData(new Uri(PknodUrl, "PKNODPLUS?arg=" + Uri.EscapeDataString(personNumber)));
                var latin1 = Encoding.GetEncoding("ISO-8859-1");

                // Data is in the format
                // -----------------------------------------------------
                //0
                //0
                //704
                //07040000191212121212191212121912121212121TOLVANSSON, TOLVAN TOLVAR STIGEN              12345STOCKHOLM                           00000000000000000000    0000018019200244  200801162008011600000000                                                                                                                                                                                    00000000000000000000        132204  03132204  V[STRA KUNGSHOLMEN            17101648M22V[STRA KUNGSHOLMEN                                STOCKHOLM / EKER\     1734    CENTRALA STOCKHOLMS PSYKIATRIS1329999                                               8                                                              _
                // -----------------------------------------------------
                // (between the dashed lines). We need to pick the first long line. Lets say long as > 100 characters
                var allDataAsText = latin1.GetString(data);
                var allDataAsRows = allDataAsText.Split(new[] { Environment.NewLine, "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                return allDataAsRows.Where(l => l.Length >= 100).FirstOrDefault();
            }
            catch (WebException wex)
            {
                if (wex.InnerException is System.Security.Authentication.AuthenticationException && (wex.InnerException as System.Security.Authentication.AuthenticationException).Message == "The remote certificate is invalid according to the validation procedure.")
                {
                    throw new ApplicationException(@"PKNOD prod does have a self signed certificate. To ignore all certificate errors in your application add the following code in your application startup
Use with caution, this is suceptible to man in the middle attacks.

//Change SSL checks so that all checks pass
ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
", wex);
                }
                else
                {
                    // Just pass on
                    throw;
                }
            }
        }
    }
}
