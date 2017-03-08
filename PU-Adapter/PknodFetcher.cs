using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Kentor.PU_Adapter
{
    public class PknodFetcher
    {
        private static readonly byte[] PuProdCertThumbPrint = { (byte)105, (byte)250, (byte)179, (byte)83, (byte)56, (byte)17, (byte)243, (byte)154, (byte)4, (byte)203, (byte)20, (byte)176, (byte)213, (byte)218, (byte)61, (byte)198, (byte)166, (byte)53, (byte)23, (byte)118 };

        public string Password { get; set; }
        public Uri PknodUrl { get; set; }
        public string UserName { get; set; }
        public PknodFetcher()
        {
            this.PknodUrl = new Uri(Properties.Settings.Default.PknodUrl);
            this.UserName = Properties.Settings.Default.UserName;
            this.Password = Properties.Settings.Default.Password;
        }

        public async Task<PknodPlusInterpreter> FetchPknodPlusInterpreter(string personnummer)
        {
            return new PknodPlusInterpreter(await FetchPknodPlusString(personnummer));
        }

        public async Task<PknodPlusData> FetchPknodPlusData(string personnummer)
        {
            return new PknodPlusData(await FetchPknodPlusString(personnummer));
        }

        public async Task<PknodData> FetchPkNodHData(string personnummer, DateTime datum)
        {
            return new PknodData(await FetchPknodHString(personnummer, datum));
        }

        public async Task<string> FetchPknodPlusString(string personnummer)
        {
            personnummer = VerifyAndFormatPersonNumber(personnummer);
            return await FetchFromPu(personnummer, "PKNODPLUS");
        }

        public async Task<string> FetchPknodString(string personnummer)
        {
            personnummer = VerifyAndFormatPersonNumber(personnummer);
            return await FetchFromPu(personnummer, "PKNOD");
        }
        public async Task<string> FetchPknodHString(string personnummer, DateTime datum)
        {
            personnummer = VerifyAndFormatPersonNumber(personnummer);
            var arg = personnummer + datum.ToString("yyyyMMdd");
            return await FetchFromPu(arg, "PKNODH");
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

        private async Task<string> FetchFromPu(string personnummer, string serviceName)
        {
            var requestUrl = new Uri(PknodUrl, serviceName + "?arg=" + Uri.EscapeDataString(personnummer));

            string data;
            using (var handler = new WebRequestHandler())
            {
                handler.ServerCertificateValidationCallback = ValidateUntrustedCert;

                using (var client = new HttpClient(handler))
                {
                    var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{UserName}:{Password}")));

                    client.DefaultRequestHeaders.Authorization = authValue;

                    using (var stream = await client.GetStreamAsync(requestUrl))
                    {
                        using (var sr = new StreamReader(stream, Encoding.GetEncoding("ISO-8859-1")))
                        {
                            data = sr.ReadToEnd();
                        }
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
            return dataAsRows.FirstOrDefault(l => l.Length >= 100);
        }

        private static bool ValidateUntrustedCert(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            if (certificate.GetCertHash().SequenceEqual(PuProdCertThumbPrint))
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
