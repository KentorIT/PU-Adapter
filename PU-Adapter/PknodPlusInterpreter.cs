using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter
{
    public class PknodPlusInterpreter : PknodInterpreter
    {
        private readonly PknodPlusData pknodPlusData;

        public PknodPlusInterpreter(PknodPlusData pknodPlusData) : base(pknodPlusData)
        {
            this.pknodPlusData = pknodPlusData;
        }
    }
}
