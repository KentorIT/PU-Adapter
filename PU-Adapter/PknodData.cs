using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter
{
    public class PknodData
    {
        protected readonly string pknodData;

        protected PknodData(string pknodData, int dataLength)
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
            if (pknodData.Last() != '_')
            {
                throw new ArgumentException("Invalid end marker", nameof(pknodData));
            }

            if (pknodData.Length != dataLength)
            {
                throw new ArgumentException("PKNOD Data should be exactly " + dataLength.ToString() + " bytes", nameof(pknodData));
            }
        }

        public PknodData(string pknodData) : this(pknodData, 704)
        {
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
