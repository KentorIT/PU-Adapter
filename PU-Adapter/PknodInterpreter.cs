using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter
{
    public class PknodInterpreter
    {
        private readonly PknodData pknodData;

        public PknodInterpreter(PknodData pknodData)
        {
            this.pknodData = pknodData;
        }

        public bool Utomlänare
        {
            get
            {
                return pknodData.Field_PersonIDTyp == Enums.PersonType.Utomlänspatient__ordinarie_personnummer ||
                    pknodData.Field_PersonIDTyp == Enums.PersonType.Utomlänspatient__samordningsnummer;
            }
        }

    }
}
