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

        protected override string FörnamnString
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(pknodPlusData.Field_Förnamn))
                {
                    return pknodPlusData.Field_Förnamn;
                }
                return base.FörnamnString;
            }
        }

        public override string Efternamn
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(pknodPlusData.Field_Efternamn))
                {
                    return pknodPlusData.Field_Efternamn;
                }
                return base.Efternamn;

            }
        }
    }
}
