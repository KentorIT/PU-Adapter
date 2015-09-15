using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter
{
    public class PknodPlusData : PknodBaseData
    {
        public PknodPlusData(string pknodData) : base(pknodData)
        {
            if (pknodData.Length != 1327)
            {
                throw new ArgumentException("PKNOD Data should be exactly 1327 bytes", nameof(pknodData));
            }
        }
    }
}
