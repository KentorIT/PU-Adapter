using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Kentor.PU_Adapter
{
    public class PknodFetcher
    {
        private static string PuProdCertThumbPrint = "69FAB3533811F39A04CB14B0D5DA3DC6A6351776";

        public string Password { get; set; }
        public Uri PknodUrl { get; set; }
        public string UserName { get; set; }
        public PknodFetcher()
        {
            this.PknodUrl = new Uri(Properties.Settings.Default.PknodUrl);
            this.UserName = Properties.Settings.Default.UserName;
            this.Password = Properties.Settings.Default.Password;
        }

        public PknodPlusInterpreter FetchPknodPlusInterpreter(string personnummer)
        {
            return new PknodPlusInterpreter(FetchPknodPlusString(personnummer));
        }

        public PknodPlusData FetchPknodPlusData(string personnummer)
        {
            return new PknodPlusData(FetchPknodPlusString(personnummer));
        }

        public string FetchPknodPlusString(string personnummer)
        {
            return FetchFromPknod(personnummer, true);
        }

        public string FetchPknodString(string personnummer)
        {
            return FetchFromPknod(personnummer, false);
        }

        private string FetchFromPknod(string personnummer, bool plusString)
        {
            var requestUrl = new Uri(PknodUrl, (plusString ? "PKNODPLUS" : "PKNOD") + "?arg=" + Uri.EscapeDataString(personnummer));
            personnummer = personnummer.Replace("-", "").Replace(" ", "");
            HttpWebRequest request = HttpWebRequest.CreateHttp(requestUrl);
            if (!string.IsNullOrEmpty(UserName))
            {
                request.Credentials = new NetworkCredential(UserName, Password);
            }
            request.ServerCertificateValidationCallback += ValidateUntrustedCert;

            string data;
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream, Encoding.GetEncoding("ISO-8859-1")))
                    {
                        data = sr.ReadToEnd();
                    }
                }
            }

            // Data is in the format
            // -----------------------------------------------------
            //0
            //0
            //704
            //07040000191212121212191212121912121212121TOLVANSSON, TOLVAN TOLVAR STIGEN              12345STOCKHOLM                           00000000000000000000    0000018019200244  200801162008011600000000                                                                                                                                                                                    00000000000000000000        132204  03132204  V[STRA KUNGSHOLMEN            17101648M22V[STRA KUNGSHOLMEN                                STOCKHOLM / EKER\     1734    CENTRALA STOCKHOLMS PSYKIATRIS1329999                                               8                                                              _
            // -----------------------------------------------------
            // (between the dashed lines). We need to pick the first long line. Lets say long as > 100 characters
            var dataAsRows = data.Split(new[] { Environment.NewLine, "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            return dataAsRows.Where(l => l.Length >= 100).FirstOrDefault();
        }

        private static bool ValidateUntrustedCert(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            if (certificate.GetCertHashString() == PuProdCertThumbPrint)
            {
                if (Properties.Settings.Default.AllowUnsafePuProdCert)
                {
                    return true;
                }
                throw new ApplicationException(@"PU prod does have a self signed certificate.
To allow the use of the well known self signed certificate add the setting
      <setting name=""AllowUnsafePuProdCert"" serializeAs=""String"">
        <value>True</value>
      </setting>
to your app/web.config
This is not enabled by default to make sure you are aware that you trust a self signed certificate.
");
            }
            return sslPolicyErrors == System.Net.Security.SslPolicyErrors.None;
        }
    }
}
