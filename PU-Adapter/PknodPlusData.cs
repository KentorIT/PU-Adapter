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
                return GetStringFieldFromPosition(FieldDefinitions.PknodPlus.Förnamn_0705);
            }
        }

        /// <summary>
        /// Mellannamn
        /// </summary>
        public string Field_Mellannamn
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.PknodPlus.Mellannamn_0785);
            }
        }

        /// <summary>
        /// Efternamn
        /// </summary>
        public string Field_Efternamn
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.PknodPlus.Efternamn_0825);
            }
        }

        /// <summary>
        /// Folkbokföring co-adress
        /// </summary>
        public string Field_Folkbokföring_co_adress
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.PknodPlus.Folkbokföringsutdelningsadress1_0920);
            }
        }

        /// <summary>
        /// Gårdsnamn, populärnamn etc 
        /// </summary>
        public string Field_Folkbokföringsutdelningsadress1
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.PknodPlus.Folkbokföringsutdelningsadress1_0920);
            }
        }

        /// <summary>
        /// Gatuadress 
        /// </summary>
        public string Field_Folkbokföringsutdelningsadress2
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.PknodPlus.Folkbokföringsutdelningsadress2_0955);
            }
        }

        /// <summary>
        /// Folkbokföringspostnummer
        /// </summary>
        public string Field_Folkbokföringspostnummer
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.PknodPlus.Folkbokföringspostnummer_0990);
            }
        }

        /// <summary>
        /// Folkbokföringspostort
        /// </summary>
        public string Field_Folkbokföringspostort
        {
            get
            {
                return GetStringFieldFromPosition(FieldDefinitions.PknodPlus.Folkbokföringspostort_0995);
            }
        }
    }
}
