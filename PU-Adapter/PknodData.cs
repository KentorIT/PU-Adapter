using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter
{
    public class PknodData : PknodBaseData
    {
        public PknodData(string pknodData) : base(pknodData)
        {
            if (pknodData.Length != 704)
            {
                throw new ArgumentException("PKNOD Data should be exactly 704 bytes", nameof(pknodData));
            }
        }
    }
}
