using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter
{
    public abstract class PknodBaseData
    {
        protected readonly string pknodData;

        public PknodBaseData(string pknodData)
        {
            this.pknodData = pknodData;
            if (pknodData == null)
            {
                throw new ArgumentNullException(nameof(pknodData));
            }
            if (string.IsNullOrWhiteSpace(pknodData))
            {
                throw new ArgumentException("PKNOD data can't be empty", nameof(pknodData));
            }
            if (pknodData.Length != this.Field_Svarslängd)
            {
                throw new ArgumentException("PKNOD length parameter does not match content length", nameof(pknodData));
            }
            if(pknodData.Last() != '_')
            {
                throw new ArgumentException("Invalid end marker", nameof(pknodData));
            }
        }

        public int Field_Svarslängd
        {
            get
            {
                return int.Parse(pknodData.Substring(0, 4));
            }
        }
    }
}
