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

        public Enums.Länskoder Län
        {
            get
            {
                return (Enums.Länskoder)int.Parse(pknodData.Field_Län);
            }
        }

        public Enums.Kommunkoder Kommun
        {
            get
            {
                return (Enums.Kommunkoder)int.Parse(pknodData.Field_Län + pknodData.Field_Kommun);
            }
        }

        protected virtual string FörnamnString
        {
            get
            {
                return pknodData.Field_Namn.Split(',').Select(n => n.Trim()).Skip(1).FirstOrDefault();
            }
        }
        public IEnumerable<string> Förnamn
        {
            get
            {
                return FörnamnString.Replace("/", " ").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public virtual string Efternamn
        {
            get
            {
                return pknodData.Field_Namn.Split(',').Select(n => n.Trim()).FirstOrDefault();
            }
        }
    }
}
