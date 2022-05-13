using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace Kentor.PU_Adapter
{
    public class PknodFetcher
    {
        private static string PuProdCertThumbPrint = "69FAB3533811F39A04CB14B0D5DA3DC6A6351776";
        private static string PuTestCertThumbPrint = "66F05F2ACD8B20EDCC570CE595E3ABEEE19B2FEB";

        public string Password { get; set; }
        public Uri PknodUrl { get; set; }
        public string UserName { get; set; }
        public bool AllowUnsafePuProdCert { get; set; }
        public bool AllowUnsafePuTestCert { get; set; }
        public X509Certificate2 Certificate2 { get; set; }
        public PknodFetcher()
        {
            this.PknodUrl = new Uri(Properties.Settings.Default.PknodUrl);
            this.UserName = Properties.Settings.Default.UserName;
            this.Password = Properties.Settings.Default.Password;
            this.AllowUnsafePuProdCert = Properties.Settings.Default.AllowUnsafePuProdCert;
            this.AllowUnsafePuTestCert = Properties.Settings.Default.AllowUnsafePuTestCert;
        }

        public PknodPlusInterpreter FetchPknodPlusInterpreter(string personnummer)
        {
            return new PknodPlusInterpreter(FetchPknodPlusString(personnummer));
        }

        public PknodPlusInterpreter FetchPknodPlusInterpreter(string personnummer, X509Certificate2 certificate2) 
        {
            return new PknodPlusInterpreter(FetchPknodPlusString(personnummer,certificate2));
        }

        public PknodPlusData FetchPknodPlusData(string personnummer)
        {
            return new PknodPlusData(FetchPknodPlusString(personnummer));
        }

        public PknodData FetchPkNodHData(string personnummer, DateTime datum)
        {
            return new PknodData(FetchPknodHString(personnummer, datum));
        }

        public string FetchPknodPlusString(string personnummer)
        {
            personnummer = VerifyAndFormatPersonNumber(personnummer);
            return FetchFromPu(personnummer, "PKNODPLUS");
        }

        public string FetchPknodPlusString(string personnummer, X509Certificate2 certificate)
        {
            personnummer = VerifyAndFormatPersonNumber(personnummer);
            return FetchFromPUWithCert(personnummer, "PKNODPLUS", certificate);
        }

        public string FetchPknodString(string personnummer)
        {
            personnummer = VerifyAndFormatPersonNumber(personnummer);
            return FetchFromPu(personnummer, "PKNOD");
        }
        public string FetchPknodHString(string personnummer, DateTime datum)
        {
            personnummer = VerifyAndFormatPersonNumber(personnummer);
            var arg = personnummer + datum.ToString("yyyyMMdd");
            return FetchFromPu(arg, "PKNODH");
        }

        private static string VerifyAndFormatPersonNumber(string personnummer)
        {
            if (personnummer == null)
            {
                throw new ArgumentNullException(nameof(personnummer), "Personnummer can't be null");
            }
            personnummer = personnummer.Replace("-", "").Replace(" ", "");
            return personnummer;
        }

        private string FetchFromPUWithCert(string personnummer, string serviceName, X509Certificate2 certificate) 
        {
            var requestUrl = new Uri(PknodUrl, serviceName + "?arg=" + Uri.EscapeDataString(personnummer));

            HttpWebRequest request = WebRequest.CreateHttp(requestUrl);
            if (!string.IsNullOrEmpty(UserName))
            {
                request.PreAuthenticate = true;
                request.Credentials = new NetworkCredential(UserName, Password);
            }
            request.ServerCertificateValidationCallback += ValidateUntrustedCert;                            
            request.ClientCertificates.Add(certificate);            
            
            string data;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream, Encoding.GetEncoding("ISO-8859-1")))
                    {
                        data = sr.ReadToEnd();
                    }
                }
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new WebException($"Fetch from PU responded with {(int)response.StatusCode} - {response.StatusDescription}Data:{Environment.NewLine}{data}");
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
            var significantRows = dataAsRows.Where(l => l.Length >= 100);
            if (significantRows.Count() != 1)
            {
                throw new InvalidOperationException($"PU Response did not contained {significantRows.Count()} significant rows. Expected 1. Data:{Environment.NewLine}----------------{Environment.NewLine}{data}{Environment.NewLine}----------------");
            }
            return significantRows.Single();
        }

        private string FetchFromPu(string personnummer, string serviceName)
        {
            var requestUrl = new Uri(PknodUrl, serviceName + "?arg=" + Uri.EscapeDataString(personnummer));

            HttpWebRequest request = WebRequest.CreateHttp(requestUrl);
            if (!string.IsNullOrEmpty(UserName))
            {
                request.PreAuthenticate = true;
                request.Credentials = new NetworkCredential(UserName, Password);
            }
            request.ServerCertificateValidationCallback += ValidateUntrustedCert;

            string data;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream, Encoding.GetEncoding("ISO-8859-1")))
                    {
                        data = sr.ReadToEnd();
                    }
                }
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new WebException($"Fetch from PU responded with {(int)response.StatusCode} - {response.StatusDescription}Data:{Environment.NewLine}{data}");
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
            var significantRows = dataAsRows.Where(l => l.Length >= 100);
            if (significantRows.Count() != 1)
            {
                throw new InvalidOperationException($"PU Response did not contained {significantRows.Count()} significant rows. Expected 1. Data:{Environment.NewLine}----------------{Environment.NewLine}{data}{Environment.NewLine}----------------");
            }
            return significantRows.Single();
        }

        private bool ValidateUntrustedCert(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            var certificateThumbPrint = certificate.GetCertHashString();
            if (certificateThumbPrint == PuProdCertThumbPrint)
            {
                if (AllowUnsafePuProdCert)
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
            else if (certificateThumbPrint == PuTestCertThumbPrint)
            {
                if (AllowUnsafePuTestCert)
                {
                    return true;
                }
                throw new ApplicationException(@"PU test does have a self signed certificate.
To allow the use of the well known self signed certificate add the setting
      <setting name=""AllowUnsafePuTestCert"" serializeAs=""String"">
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
