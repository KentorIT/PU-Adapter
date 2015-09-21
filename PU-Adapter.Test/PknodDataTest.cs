using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Kentor.PU_Adapter;

namespace Kentor.PU_Adapter.Test
{
    [TestClass]
    public class PknodDataTest
    {
        [TestMethod]
        public void LengthFieldReadsOk()
        {
            var pknodData = new PknodData(CommonData.TolvanPknodResult);
            pknodData.Field_Svarslängd.Should().Be(704);

            var pknodPlusData = new PknodPlusData(CommonData.TolvanPknodPlusResult);
            pknodPlusData.Field_Svarslängd.Should().Be(1327);
        }

        [TestMethod]
        public void CantCreateInvalidLengths()
        {
            Action a1 = () => new PknodData(CommonData.TolvanPknodResult + "PAD");
            a1.ShouldThrow<ArgumentException>().Where(ex => ex.Message.StartsWith("PKNOD length parameter does not match content length"));

            Action a2 = () => new PknodPlusData(CommonData.TolvanPknodPlusResult + "PAD");
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
            Action a1 = () => new PknodData(CommonData.TolvanPknodResult.Replace("_", "-"));
            a1.ShouldThrow<ArgumentException>().Where(ex => ex.Message.StartsWith("Invalid end marker"));

            Action a2 = () => new PknodPlusData(CommonData.TolvanPknodPlusResult.Replace("_", "-"));
            a2.ShouldThrow<ArgumentException>().Where(ex => ex.Message.StartsWith("Invalid end marker"));
        }

        [TestMethod]
        public void TestReturnCode()
        {
            var pknodData = new PknodData(CommonData.TolvanPknodResult);
            pknodData.Field_Returkod.Should().Be(Enums.ReturnCode.Tjänsten_utförd);

            var pknodDataFail = new PknodData(CommonData.TolvanFelaktigtLän);
            pknodDataFail.Field_Returkod.Should().Be(Enums.ReturnCode.Län_felaktigt);
        }

        [TestMethod]
        public void TestPersonnummer()
        {
            var pknodData = new PknodData(CommonData.TolvanPknodResult);
            pknodData.Field_Personnummer_Reservnummer.Should().Be("191212121212");
        }

        [TestMethod]
        public void TestAktuelltPersonnummer()
        {
            var pknodData = new PknodData(CommonData.TolvanPknodResult);
            pknodData.Field_Aktuellt_Personnummer.Should().Be("191212121212");
        }

        [TestMethod]
        public void TestPersonnummerPersonIdTyp()
        {
            var pknodData = new PknodData(CommonData.TolvanPknodResult);
            pknodData.Field_PersonIDTyp.Should().Be(Enums.PersonType.Uppgift_från_RSV__ordinarie_personnummer);
        }

        [TestMethod]
        public void TestNamn()
        {
            var pknodData = new PknodData(CommonData.TolvanPknodResult);
            pknodData.Field_Namn.Should().Be("TOLVANSSON, TOLVAN");

            var pknodPlusData = new PknodPlusData(CommonData.TolvanPknodPlusResult);
            pknodPlusData.Field_Namn.Should().Be("Tolvansson, Tolvan");
        }

        [TestMethod]
        public void TestAdress()
        {
            var pknodData = new PknodData(CommonData.TolvanPknodResult);
            pknodData.Field_Adress.Should().Be("TOLVAR STIGEN");
            pknodData.Field_Postnummer.Should().Be("12345");
            pknodData.Field_Postort.Should().Be("STOCKHOLM");
        }

        [TestMethod]
        public void TestLKF()
        {
            var pknodData = new PknodData(CommonData.TolvanPknodResult);
            pknodData.Field_Län.Should().Be("01"); // Stockholms län
            pknodData.Field_Kommun.Should().Be("80"); // Stockholm
            pknodData.Field_Församling.Should().Be("19"); // Västermalm
        }

        [TestMethod]
        public void TestAvgångskod()
        {
            var pknodData = new PknodPlusData(CommonData.TolvanPknodPlusResult);
            pknodData.Field_Avgångskod.Should().BeNull();

            var pknodDataAvliden = new PknodPlusData(CommonData.AvlidenPerson);
            pknodDataAvliden.Field_Avgångskod.Should().Be(Enums.Avgångskod.Avliden);
        }

        [TestMethod]
        public void TestCivilståndsdatum()
        {
            var pknodData = new PknodPlusData(CommonData.TolvanPknodPlusResult);
            pknodData.Field_Civilståndsdatum.Should().Be(null);

            var pknodDataAvliden = new PknodPlusData(CommonData.AvlidenPerson);
            pknodDataAvliden.Field_Civilståndsdatum.Should().Be(new DateTime(2005, 02, 21));
        }

        [TestMethod]
        public void TestBasområde()
        {
            var pknodData = new PknodData(CommonData.TolvanPknodResult);
            pknodData.Field_Basområde.Should().Be("1329999");
        }

        [TestMethod]
        public void TestPlusNamn()
        {
            var pknodPlusData = new PknodPlusData(CommonData.TolvanPknodPlusResult);
            pknodPlusData.Field_Förnamn.Should().Be("Tolvan");
            pknodPlusData.Field_Efternamn.Should().Be("Tolvansson");
        }

        [TestMethod]
        public void TestPlusAdress()
        {
            var pknodPlusData = new PknodPlusData(CommonData.TolvanWithPlusAddress);
            pknodPlusData.Field_Folkbokföringspostort.Should().Be("STOCKHOLMPLUS");
            pknodPlusData.Field_Folkbokföringspostnummer.Should().Be("98765");
            pknodPlusData.Field_Folkbokföringsutdelningsadress2.Should().Be("TOLVAN PLUS STIGEN");
        }

        [TestMethod]
        public void TestInvalidPersonNumber()
        {
            var pknodPlusData = new PknodPlusData(CommonData.InvalidPersonNumberResult);
            pknodPlusData.Field_Returkod.Should().Be(Enums.ReturnCode.Felaktigt_format_på_inmatat_personnummer);
        }

        [TestMethod]
        public void SenastRegDatum()
        {
            var pknodData = new PknodData(CommonData.TolvanPknodResult);
            pknodData.Field_SenasteRegDatum.Should().Be(new DateTime(2008, 01, 16));
        }
    }
}
