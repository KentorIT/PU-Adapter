using Kentor.PU_Adapter.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter
{
    public class PknodData
    {
        protected readonly string pknodData;

        /// <summary>
        /// The row pknod string
        /// </summary>
        public string Raw { get { return pknodData; } }

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
        /// Födelsedatum
        /// </summary>
        public DateTime? Field_Födelsedatum
        {
            get
            {
                var rawDate = pknodData.Substring(20, 8);
                DateTime date;
                if (DateTime.TryParseExact(rawDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }
                return null;
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
        public string Field_Namn
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
        public string Field_Postort
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

        /// <summary>
        /// Civilståndsdatum
        /// </summary>
        public Enums.Civilstånd? Field_Civilstånd
        {
            get
            {
                var rawDate = pknodData.Substring(144, 1);
                switch (rawDate)
                {
                    case "A":
                        return Enums.Civilstånd.A_Ogift;
                    case "B":
                        return Enums.Civilstånd.B_Gift;
                    case "C":
                        return Enums.Civilstånd.C_Änka_eller_änkling;
                    case "D":
                        return Enums.Civilstånd.D_Skild;
                    case "E":
                        return Enums.Civilstånd.E_Registrerad_partner;
                    case "F":
                        return Enums.Civilstånd.F_Skild_partner;
                    case "G":
                        return Enums.Civilstånd.G_Efterlevande_partner;
                    case "6":
                        return Enums.Civilstånd._6_Avliden_person;
                }
                return null;
            }
        }

        /// <summary>
        /// Civilståndsdatum
        /// </summary>
        public DateTime? Field_Civilståndsdatum
        {
            get
            {
                var rawDate = pknodData.Substring(145, 8);
                DateTime date;
                if (DateTime.TryParseExact(rawDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }
                return null;
            }
        }


        /// <summary>
        /// Senaste datum för ändring av personuppgifterna 
        /// </summary>
        public DateTime? Field_SenasteRegDatum
        {
            get
            {
                var rawDate = pknodData.Substring(187, 8);
                DateTime date;
                if (DateTime.TryParseExact(rawDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }
                return null;
            }
        }

        /// <summary>
        /// Basområde
        /// </summary>
        public string Field_Basområde
        {
            get
            {
                return pknodData.Substring(586, 8).Trim();
            }
        }

        public override string ToString()
        {
            return this.Field_Aktuellt_Personnummer + ": " + this.Field_Namn;
        }
    }
}
