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
                throw new ArgumentException("PKNOD Data should be exactly " + dataLength + " bytes", nameof(pknodData));
            }
        }

        public PknodData(string pknodData) : this(pknodData, 704)
        {
        }

        public string GetStringFieldFromPosition(FieldDefinitions.FieldDefinition position)
        {
            return pknodData.Substring(position.StartPosition - 1, position.Length).Trim();
        }

        public int? GetIntFieldFromPosition(FieldDefinitions.FieldDefinition position)
        {
            var parsedString = GetStringFieldFromPosition(position);
            if (string.IsNullOrWhiteSpace(parsedString))
            {
                return null;
            }
            return int.Parse(parsedString);
        }

        public DateTime? GetDateFieldFromPosition(FieldDefinitions.FieldDefinition position)
        {
            var rawDate = GetStringFieldFromPosition(position);
            DateTime date;
            if (DateTime.TryParseExact(rawDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date;
            }
            return null;
        }

        /// <summary>
        /// Längden på svarssträngen, räknat fr.o.m. detta fält t.o.m det avslutande underlinetecknet.
        /// </summary>
        public int Field_Svarslängd
        {
            get
            {
                return GetIntFieldFromPosition(FieldDefinitions.Pknod.Svarslängd_0001).Value;
            }
        }

        /// <summary>
        /// Status från anropet
        /// </summary>
        public ReturnCode Field_Returkod
        {
            get
            {
                return (ReturnCode)GetIntFieldFromPosition(FieldDefinitions.Pknod.Returkod_0005);
            }
        }

        /// <summary>
        /// Personnummer från anropssträngen på formen SSÅÅMMDDNNNC eller reservnummer från anropssträngen på formen 99ÅÅÅÅNNNNNC
        /// </summary>
        public string Field_Personnummer_Reservnummer
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.Pknod.Pnr_Rnr_0009);
            }
        }

        /// <summary>
        /// Födelsedatum
        /// </summary>
        public DateTime? Field_Födelsedatum
        {
            get
            {
                return GetDateFieldFromPosition(FieldDefinitions.Pknod.Födelsedatum_0021);
            }
        }

        /// <summary>
        /// Personens aktuellaste identitet på formen SSÅÅMMDDNNNN. Kan vara annat än identiteten i anropet.
        /// </summary>
        public string Field_Aktuellt_Personnummer
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.Pknod.Aktuellt_pnr_0029);
            }
        }

        /// <summary>
        /// Personidentitetstyp
        /// </summary>
        public PersonType Field_PersonIDTyp
        {
            get
            {
                return (PersonType)GetIntFieldFromPosition(FieldDefinitions.Pknod.PersonIDTyp_0041);
            }
        }

        /// <summary>
        /// Aktuellt namn = efternamn och ev. mellannamn, samtliga förnamn (tilltalsnamnet inom // om sådant finns anmält).
        /// </summary>
        public string Field_Namn
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.Pknod.Namn_0042);
            }
        }

        /// <summary>
        /// Aktuell gatuadress (gatuadress för särskild postadress om sådan finns anmäld, annars för folkbokföringsadressen)
        /// </summary>
        public string Field_Adress
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.Pknod.Adress_0078);
            }
        }

        /// <summary>
        /// Aktuellt postnummer (postnummer för särskild postadress om sådan finns anmäld, annars för folkbokföringsadressen)
        /// </summary>
        public string Field_Postnummer
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.Pknod.Postnummer_0105);
            }
        }

        /// <summary>
        /// Aktuell postadress (postadress för särskild postadress om sådan finns anmäld, annars för folkbokföringsadressen)
        /// </summary>
        public string Field_Postort
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.Pknod.Postort_0110);
            }
        }

        /// <summary>
        /// Länskod
        /// </summary>
        public string Field_Län
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.Pknod.Län_0174);
            }
        }
        /// <summary>
        /// Kommunkod
        /// </summary>
        public string Field_Kommun
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.Pknod.Kommun_0176);
            }
        }

        /// <summary>
        /// Församlingskod
        /// </summary>
        public string Field_Församling
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.Pknod.Församling_0178);
            }
        }

        /// <summary>
        /// Avgångskod
        /// </summary>
        public Avgångskod? Field_Avgångskod
        {
            get
            {
                return (Avgångskod?)GetIntFieldFromPosition(FieldDefinitions.Pknod.Avgångskod_0186);
            }
        }

        /// <summary>
        /// Civilståndsdatum
        /// </summary>
        public Enums.Civilstånd? Field_Civilstånd
        {
            get
            {
                var rawDate = GetStringFieldFromPosition(FieldDefinitions.Pknod.Civilstånd_0145);
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
                return GetDateFieldFromPosition(FieldDefinitions.Pknod.Civilståndsdatum_0146);
            }
        }


        /// <summary>
        /// Senaste datum för ändring av personuppgifterna 
        /// </summary>
        public DateTime? Field_SenasteRegDatum
        {
            get
            {
                return GetDateFieldFromPosition(FieldDefinitions.Pknod.Senaste_reg_datum_0188);
            }
        }

        /// <summary>
        /// Basområde
        /// </summary>
        public string Field_Basområde
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.Pknod.Basområde_från_fastighet_eller_församling_0587);
            }
        }

        public override string ToString()
        {
            return this.Field_Aktuellt_Personnummer + ": " + this.Field_Namn;
        }
    }
}


