using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Kentor.PU_Adapter;

namespace Kentor.PU_Adapter.Test
{
    [TestClass]
    public class PknodDataTest
    {
        private const string TolvanPknodResult = @"07040000191212121212191212121912121212121TOLVANSSON, TOLVAN                  TOLVAR STIGEN              12345STOCKHOLM                           00000000000000000000    0000018019200244  200801162008011600000000                                                                                                                                                                                    00000000000000000000        132204  03132204  V[STRA KUNGSHOLMEN            17101648M22V[STRA KUNGSHOLMEN                                STOCKHOLM/EKER\     1734    CENTRALA STOCKHOLMS PSYKIATRIS1329999                                               8                                                              _";
        private const string TolvanPknodPlusResult = @"13270000191212121212191212121912121212121Tolvansson, Tolvan                  TOLVAR STIGEN              12345STOCKHOLM                           00000000000000000000    0000018019200244  200801162008011600000000                                                                                                                                                                                    00000000000000000000        132204  03132204  Västra Kungsholmen            17101648M22Västra Kungsholmen                                Stockholm/Ekerö     1734    Centrala Stockholms psykiatris1329999                                               8                                                               Tolvan                                                                                                                  Tolvansson                                                                                                                                                                                                                                                                                                                                                                                                                                                                                000000000000  000000000000  _";

        private string TolvanFelaktigtLän
        {
            get
            {
                return "07040112" + TolvanPknodResult.Substring(8);
            }
        }
        private string TolvanAvliden
        {
            get
            {
                return TolvanPknodResult.Substring(0, 145) + "19120101" + TolvanPknodResult.Substring(153, 185 - 153) + "1" + TolvanPknodResult.Substring(186);
            }
        }

        [TestMethod]
        public void LengthFieldReadsOk()
        {
            var pknodData = new PknodData(TolvanPknodResult);
            pknodData.Field_Svarslängd.Should().Be(704);

            var pknodPlusData = new PknodPlusData(TolvanPknodPlusResult);
            pknodPlusData.Field_Svarslängd.Should().Be(1327);
        }

        [TestMethod]
        public void CantCreateInvalidLengths()
        {
            Action a1 = () => new PknodData(TolvanPknodResult + "PAD");
            a1.ShouldThrow<ArgumentException>().Where(ex => ex.Message.StartsWith("PKNOD length parameter does not match content length"));

            Action a2 = () => new PknodPlusData(TolvanPknodPlusResult + "PAD");
            a2.ShouldThrow<ArgumentException>().Where(ex => ex.Message.StartsWith("PKNOD length parameter does not match content length"));

            Action a3 = () => new PknodData(null);
            a3.ShouldThrow<ArgumentNullException>();

            Action a4 = () => new PknodPlusData("   ");
            a4.ShouldThrow<ArgumentException>().Where(ex => ex.Message.StartsWith("PKNOD data can't be empty"));

            Action a5 = () => new PknodData("0010xxxxx_");
            a5.ShouldThrow<ArgumentException>().Where(ex => ex.Message.StartsWith("PKNOD Data should be exactly 704 bytes"));

            Action a6 = () => new PknodPlusData("0010xxxxx_");
            a6.ShouldThrow<ArgumentException>().Where(ex => ex.Message.StartsWith("PKNOD Data should be exactly 1327 bytes"));

        }

        [TestMethod]
        public void MakeSureEndingCharacterIsUnderscore()
        {
            Action a1 = () => new PknodData(TolvanPknodResult.Replace("_", "-"));
            a1.ShouldThrow<ArgumentException>().Where(ex => ex.Message.StartsWith("Invalid end marker"));

            Action a2 = () => new PknodPlusData(TolvanPknodPlusResult.Replace("_", "-"));
            a2.ShouldThrow<ArgumentException>().Where(ex => ex.Message.StartsWith("Invalid end marker"));
        }

        [TestMethod]
        public void TestReturnCode()
        {
            var pknodData = new PknodData(TolvanPknodResult);
            pknodData.Field_Returkod.Should().Be(Enums.ReturnCode.Tjänsten_utförd);

            var pknodDataFail = new PknodData(TolvanFelaktigtLän);
            pknodDataFail.Field_Returkod.Should().Be(Enums.ReturnCode.Län_felaktigt);
        }

        [TestMethod]
        public void TestPersonnummer()
        {
            var pknodData = new PknodData(TolvanPknodResult);
            pknodData.Field_Personnummer_Reservnummer.Should().Be("191212121212");
        }

        [TestMethod]
        public void TestAktuelltPersonnummer()
        {
            var pknodData = new PknodData(TolvanPknodResult);
            pknodData.Field_Aktuellt_Personnummer.Should().Be("191212121212");
        }

        [TestMethod]
        public void TestPersonnummerPersonIdTyp()
        {
            var pknodData = new PknodData(TolvanPknodResult);
            pknodData.Field_PersonIDTyp.Should().Be(Enums.PersonType.Uppgift_från_RSV__ordinarie_personnummer);
        }

        [TestMethod]
        public void TestNamn()
        {
            var pknodData = new PknodData(TolvanPknodResult);
            pknodData.Field_Namn.Should().Be("TOLVANSSON, TOLVAN");

            var pknodPlusData = new PknodPlusData(TolvanPknodPlusResult);
            pknodPlusData.Field_Namn.Should().Be("Tolvansson, Tolvan");
        }

        [TestMethod]
        public void TestAdress()
        {
            var pknodData = new PknodData(TolvanPknodResult);
            pknodData.Field_Adress.Should().Be("TOLVAR STIGEN");
            pknodData.Field_Postnummer.Should().Be("12345");
            pknodData.Field_Postort.Should().Be("STOCKHOLM");
        }

        [TestMethod]
        public void TestLKF()
        {
            var pknodData = new PknodData(TolvanPknodResult);
            pknodData.Field_Län.Should().Be("01"); // Stockholms län
            pknodData.Field_Kommun.Should().Be("80"); // Stockholm
            pknodData.Field_Församling.Should().Be("19"); // Västermalm
        }

        [TestMethod]
        public void TestAvgångskod()
        {
            var pknodData = new PknodData(TolvanPknodResult);
            pknodData.Field_Avgångskod.Should().BeNull();

            var pknodDataAvliden = new PknodData(TolvanAvliden);
            pknodDataAvliden.Field_Avgångskod.Should().Be(Enums.Avgångskod.Avliden);
        }
    }
}
