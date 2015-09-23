using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter
{
    public class PknodPlusData : PknodData
    {
        public PknodPlusData(string pknodData) : base(pknodData, 1327)
        {
        }

        /// <summary>
        /// Förnamn, med snedsträck / runt tilltalsnamn
        /// </summary>
        public string Field_Förnamn
        {
            get
            {
                return pknodData.Substring(704, 80).Trim();
            }
        }

        /// <summary>
        /// Mellannamn
        /// </summary>
        public string Field_Mellannamn
        {
            get
            {
                return pknodData.Substring(784, 40).Trim();
            }
        }

        /// <summary>
        /// Efternamn
        /// </summary>
        public string Field_Efternamn
        {
            get
            {
                return pknodData.Substring(824, 60).Trim();
            }
        }

        /// <summary>
        /// Folkbokföring co-adress
        /// </summary>
        public string Field_Folkbokföring_co_adress
        {
            get
            {
                return pknodData.Substring(919, 35).Trim();
            }
        }

        /// <summary>
        /// Gårdsnamn, populärnamn etc 
        /// </summary>
        public string Field_Folkbokföringsutdelningsadress1
        {
            get
            {
                return pknodData.Substring(919, 35).Trim();
            }
        }

        /// <summary>
        /// Gatuadress 
        /// </summary>
        public string Field_Folkbokföringsutdelningsadress2
        {
            get
            {
                return pknodData.Substring(954, 35).Trim();
            }
        }

        /// <summary>
        /// Folkbokföringspostnummer
        /// </summary>
        public string Field_Folkbokföringspostnummer
        {
            get
            {
                return pknodData.Substring(989, 5).Trim();
            }
        }

        /// <summary>
        /// Folkbokföringspostort
        /// </summary>
        public string Field_Folkbokföringspostort
        {
            get
            {
                return pknodData.Substring(994, 27).Trim();
            }
        }
    }
}
