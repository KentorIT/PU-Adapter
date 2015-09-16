using Kentor.PU_Adapter.Enums;
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

        /// <summary>
        /// Längden på svarssträngen, räknat fr.o.m. detta fält t.o.m det avslutande underlinetecknet.
        /// </summary>
        public int Field_Svarslängd
        {
            get
            {
                return int.Parse(pknodData.Substring(0, 4));
            }
        }

        /// <summary>
        /// Status från anropet
        /// </summary>
        public ReturnCode Field_Returkod
        {
            get
            {
                return (ReturnCode)int.Parse(pknodData.Substring(4, 4));
            }
        }

        /// <summary>
        /// Personnummer från anropssträngen på formen SSÅÅMMDDNNNC eller reservnummer från anropssträngen på formen 99ÅÅÅÅNNNNNC
        /// </summary>
        public string Field_Personnummer_Reservnummer
        {
            get
            {
                return pknodData.Substring(8, 12);
            }
        }

        /// <summary>
        /// Personens aktuellaste identitet på formen SSÅÅMMDDNNNN. Kan vara annat än identiteten i anropet.
        /// </summary>
        public string Field_Aktuellt_Personnummer
        {
            get
            {
                return pknodData.Substring(28, 12);
            }
        }

        /// <summary>
        /// Personidentitetstyp
        /// </summary>
        public PersonType Field_PersonIDTyp
        {
            get
            {
                return (PersonType)int.Parse(pknodData.Substring(40, 1));
            }
        }

        /// <summary>
        /// Aktuellt namn = efternamn och ev. mellannamn, samtliga förnamn (tilltalsnamnet inom // om sådant finns anmält).
        /// </summary>
        public virtual string Field_Namn
        {
            get
            {
                return pknodData.Substring(41, 36).Trim();
            }
        }

        /// <summary>
        /// Aktuell gatuadress (gatuadress för särskild postadress om sådan finns anmäld, annars för folkbokföringsadressen)
        /// </summary>
        public string Field_Adress
        {
            get
            {
                return pknodData.Substring(77, 27).Trim();
            }
        }

        /// <summary>
        /// Aktuellt postnummer (postnummer för särskild postadress om sådan finns anmäld, annars för folkbokföringsadressen)
        /// </summary>
        public string Field_Postnummer
        {
            get
            {
                return pknodData.Substring(104, 5).Trim();
            }
        }

        /// <summary>
        /// Aktuell postadress (postadress för särskild postadress om sådan finns anmäld, annars för folkbokföringsadressen)
        /// </summary>
        public virtual string Field_Postort
        {
            get
            {
                return pknodData.Substring(109, 13).Trim();
            }
        }

        /// <summary>
        /// Länskod
        /// </summary>
        public string Field_Län
        {
            get
            {
                return pknodData.Substring(173, 2);
            }
        }
        /// <summary>
        /// Kommunkod
        /// </summary>
        public string Field_Kommun
        {
            get
            {
                return pknodData.Substring(175, 2);
            }
        }
        /// <summary>
        /// Församlingskod
        /// </summary>
        public string Field_Församling
        {
            get
            {
                return pknodData.Substring(177, 2);
            }
        }

        /// <summary>
        /// Avgångskod
        /// </summary>
        public Avgångskod? Field_Avgångskod
        {
            get
            {
                var code = pknodData.Substring(185, 1);
                if (code == " ")
                {
                    return null;
                }
                return (Avgångskod)int.Parse(code);
            }
        }
    }
}
