using Kentor.PU_Adapter.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kentor.PU_Adapter.Test
{
    public static class CommonData
    {
        public const string TolvanPknodResult = @"07040000191212121212191212121912121212121TOLVANSSON, TOLVAN                  TOLVAR STIGEN              12345STOCKHOLM                           00000000000000000000    0000018019200244  200801162008011600000000                                                                                                                                                                                    00000000000000000000        132204  03132204  V[STRA KUNGSHOLMEN            17101648M22V[STRA KUNGSHOLMEN                                STOCKHOLM/EKER\     1734    CENTRALA STOCKHOLMS PSYKIATRIS1329999                                               8                                                              _";
        public const string TolvanPknodPlusResult = @"13270000191212121212191212121912121212121Tolvansson, Tolvan                  TOLVAR STIGEN              12345STOCKHOLM                           00000000000000000000    0000018019200244  200801162008011600000000                                                                                                                                                                                    00000000000000000000        132204  03132204  Västra Kungsholmen            17101648M22Västra Kungsholmen                                Stockholm/Ekerö     1734    Centrala Stockholms psykiatris1329999                                               8                                                               Tolvan                                                                                                                  Tolvansson                                                                                                                                                                                                                                                                                                                                                                                                                                                                                000000000000  000000000000  _";
        public const string InvalidPersonNumberResult = @"13270020                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      _";
        public const string SöktPersonSaknasResult = @"13270001                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      _";

        public static string TolvanFelaktigtLän
        {
            get
            {
                return "07040112" + TolvanPknodResult.Substring(8);
            }
        }
        public static string AvlidenPerson
        {
            get
            {
                return TestPersonsPuData.PuDataList[20];
            }
        }

        public static string TolvanWithPlusAddress
        {
            get
            {
                // Tolvan does not have a PlusAddress in PU, but we fake it here for testing purposes.
                // When using the PU-Adapter, make sure to use PKNOD address if PKNODPLUS address is empty
                var sb = new System.Text.StringBuilder(TolvanPknodPlusResult);
                sb
                    .OverWrite(954, "TOLVAN PLUS STIGEN")
                    .OverWrite(994, "STOCKHOLMPLUS")
                    .OverWrite(989, "98765");
                return sb.ToString();
            }
        }

        public static string TolvanWithKalmarLän
        {
            get
            {
                var sb = new System.Text.StringBuilder(TolvanPknodResult);
                sb
                    .OverWrite(040, "2") // 2 = Utomlänspatient, ordinarie personnummer
                    .OverWrite(173, "0821 ");// Kalmar / Högsby
                return sb.ToString();
            }
        }

        public static string TolvanWithTillsalsnamn
        {
            get
            {
                var sb = new System.Text.StringBuilder(TolvanPknodResult);
                sb
                    .OverWrite(041, "TOLVANSSON, TOLVAN/LARS/ERIK");
                return sb.ToString();
            }
        }

        public static string TolvanPlusWithTillsalsnamn
        {
            get
            {
                var sb = new System.Text.StringBuilder(TolvanPknodPlusResult);
                sb
                    .OverWrite(704, "Tolvan/Lars/Erik");
                return sb.ToString();
            }
        }
    }
}
