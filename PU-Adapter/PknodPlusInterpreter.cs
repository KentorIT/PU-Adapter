using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter
{
    public class PknodPlusInterpreter : PknodInterpreter
    {
        private readonly PknodPlusData pknodPlusData;

        public PknodPlusData PknodPlusData { get { return pknodPlusData; } }

        public PknodPlusInterpreter(PknodPlusData pknodPlusData) : base(pknodPlusData)
        {
            this.pknodPlusData = pknodPlusData;
        }

        public PknodPlusInterpreter(string pknodPlusString) : this(new PknodPlusData(pknodPlusString))
        {
        }

        protected override string FörnamnString
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(pknodPlusData.Field_Förnamn))
                {
                    return pknodPlusData.Field_Förnamn;
                }
                return base.FörnamnString;
            }
        }

        public override string Efternamn
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(pknodPlusData.Field_Efternamn))
                {
                    return pknodPlusData.Field_Efternamn;
                }
                return base.Efternamn;

            }
        }

        /// <summary>
        /// Folkbokföringsadress
        /// Fallback till pknod adress
        /// </summary>
        public override Composite.Adress Adress
        {
            get
            {
                var adressRad1 = pknodPlusData.Field_Folkbokföringsutdelningsadress1;
                var adressRad2 = pknodPlusData.Field_Folkbokföringsutdelningsadress2;
                var postnummer = pknodPlusData.Field_Folkbokföringspostnummer;
                var postort = pknodPlusData.Field_Folkbokföringspostort;
                var coAdress = pknodPlusData.Field_Folkbokföring_co_adress;
                if (string.IsNullOrEmpty(adressRad1) && string.IsNullOrEmpty(adressRad2))
                {
                    // Fallback to PKNOD data
                    return base.Adress;
                }
                return new Composite.Adress
                {
                    AdressRad1 = adressRad1,
                    AdressRad2 = adressRad2,
                    Co_adress = coAdress,
                    Postnummer = postnummer,
                    Postort = postort,
                };
            }
        }

        /// <summary>
        /// Särskild utdelningsadress om angiven
        /// annars null
        /// </summary>
        public Composite.Adress SärskildUtdelningsAdress
        {
            get
            {
                // No fallbacks
                var adressRad1 = pknodPlusData.GetStringFieldFromPosition(FieldDefinitions.PknodPlus.Särskild_utdelningsadress1_1057);
                var adressRad2 = pknodPlusData.GetStringFieldFromPosition(FieldDefinitions.PknodPlus.Särskild_utdelningsadress2_1092);
                var postnummer = pknodPlusData.GetStringFieldFromPosition(FieldDefinitions.PknodPlus.Särskild_postnummer_1127);
                var postort = pknodPlusData.GetStringFieldFromPosition(FieldDefinitions.PknodPlus.Särskild_postort_1132);
                var coAdress = pknodPlusData.GetStringFieldFromPosition(FieldDefinitions.PknodPlus.Särskild_co_adress_1022);
                if (string.IsNullOrEmpty(adressRad1) && string.IsNullOrEmpty(adressRad2))
                {
                    // No fallback, return null if no SärskildUtdelningsAdress exists
                    return null;
                }
                return new Composite.Adress
                {
                    AdressRad1 = adressRad1,
                    AdressRad2 = adressRad2,
                    Co_adress = coAdress,
                    Postnummer = postnummer,
                    Postort = postort,
                };
            }
        }

    }
}
