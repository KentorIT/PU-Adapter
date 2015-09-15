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
    }
}
