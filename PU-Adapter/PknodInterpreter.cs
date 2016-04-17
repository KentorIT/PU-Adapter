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

        private IEnumerable<string> ParseFörnamnListRaw(out int tilltalsnamnIndex)
        {
            tilltalsnamnIndex = 0;
            var fornamnString = FörnamnString;
            if (fornamnString == null)
            {
                return Enumerable.Empty<string>();
            }
            var firstSlash = fornamnString.IndexOf("/");
            var lastSlash = fornamnString.LastIndexOf("/");
            var afterLastSlash = lastSlash + 1;
            if (firstSlash >= 0)
            {
                if (lastSlash == firstSlash)
                {
                    // No end slash, assume tilltalsnamn is until the end of the string
                    lastSlash = fornamnString.Length;
                    afterLastSlash = lastSlash;
                }
                var part1 = fornamnString.Substring(0, firstSlash);
                var part2 = fornamnString.Substring(firstSlash + 1, lastSlash - firstSlash - 1);
                var part3 = fornamnString.Substring(afterLastSlash);

                var part1List = part1.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var part3List = part3.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                tilltalsnamnIndex = part1List.Count();
                // Don't split tilltalsnamn, since it may contain spaces, like "Lars Ola"
                return part1List.Concat(new[] { part2 }).Concat(part3List);
            }
            else
            {
                return fornamnString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public IEnumerable<string> Förnamn
        {
            get
            {
                int tmp;
                return ParseFörnamnListRaw(out tmp);
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
                int idx;
                ParseFörnamnListRaw(out idx);
                return idx;
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
