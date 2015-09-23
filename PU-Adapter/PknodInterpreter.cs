using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter
{
    public class PknodInterpreter
    {
        private readonly PknodData pknodData;

        public PknodData PknodData { get { return pknodData; } }

        public PknodInterpreter(PknodData pknodData)
        {
            this.pknodData = pknodData;
        }

        public PknodInterpreter(string pknodString) : this(new PknodData(pknodString))
        {
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
                if (string.IsNullOrWhiteSpace(pknodData.Field_Län))
                {
                    return Enums.Länskoder.SAKNAS_ELLER_FELAKTIGT;
                }
                return (Enums.Länskoder)int.Parse(pknodData.Field_Län);
            }
        }

        public Enums.Kommunkoder Kommun
        {
            get
            {
                if (string.IsNullOrWhiteSpace(pknodData.Field_Län))
                {
                    return Enums.Kommunkoder.SAKNAS_ELLER_FELAKTIGT;
                }
                if (string.IsNullOrWhiteSpace(pknodData.Field_Kommun))
                {
                    return Enums.Kommunkoder.SAKNAS_ELLER_FELAKTIGT;
                }
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

        private IEnumerable<string> FörnamnListRaw
        {
            get
            {
                var fornamnString = FörnamnString;
                var firstSlash = fornamnString.IndexOf("/");
                var lastSlash = fornamnString.LastIndexOf("/");
                if (firstSlash >= 0)
                {
                    if (lastSlash < firstSlash)
                    {
                        throw new InvalidOperationException("Name strings contains only one slash");
                    }
                    var part1 = fornamnString.Substring(0, firstSlash);
                    var part2 = fornamnString.Substring(firstSlash + 1, lastSlash - firstSlash - 1);
                    var part3 = fornamnString.Substring(lastSlash + 1);
                    fornamnString = part1 + " /" + part2.Trim() + "/ " + part3;
                }

                return fornamnString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
        public IEnumerable<string> Förnamn
        {
            get
            {
                return FörnamnListRaw.Select(f => f.Trim('/'));
            }
        }

        public virtual string Efternamn
        {
            get
            {
                return pknodData.Field_Namn.Split(',').Select(n => n.Trim()).FirstOrDefault();
            }
        }

        public int TilltalsnamnIndex
        {
            get
            {
                var idx = FörnamnListRaw.ToList().FindIndex(f => f.StartsWith("/"));
                if (idx >= 0)
                {
                    return idx;
                }
                return 0; // First namn is implicit "tilltalsnamn"
            }
        }

        public string Tilltalsnamn
        {
            get
            {
                return Förnamn.Skip(TilltalsnamnIndex).FirstOrDefault();
            }
        }

        public bool Avliden
        {
            get
            {
                return pknodData.Field_Avgångskod == Enums.Avgångskod.Avliden;
            }
        }

        public DateTime? AvlidenDatum
        {
            get
            {
                if (Avliden)
                {
                    return pknodData.Field_Civilståndsdatum;
                }
                return null;
            }
        }
    }
}
