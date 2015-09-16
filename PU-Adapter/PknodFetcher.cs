using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Kentor.PU_Adapter
{
    public class PknodFetcher
    {
        public string Password { get; private set; }
        public Uri PknodUrl { get; private set; }
        public string UserName { get; private set; }
        public PknodFetcher()
        {
            this.PknodUrl = new Uri(Properties.Settings.Default.PknodUrl);
            this.UserName = Properties.Settings.Default.UserName;
            this.Password = Properties.Settings.Default.Password;
        }

        public string FetchPkNodplusString(string personNumber)
        {
            WebClient wc = new WebClient();
            if (!string.IsNullOrEmpty(UserName))
            {
                wc.Credentials = new NetworkCredential(UserName, Password);
            }
            var data = wc.DownloadData(new Uri(PknodUrl, "PKNODPLUS?arg=" + Uri.EscapeDataString(personNumber)));
            var latin1 = Encoding.GetEncoding("ISO-8859-1");
            var allDataAsText = latin1.GetString(data);
            var allDataAsRows = allDataAsText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return allDataAsRows.LastOrDefault();
        }
    }
}
