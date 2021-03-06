﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Kentor.PU_Adapter.TestData;
using System.Linq;

namespace Kentor.PU_Adapter.Test
{
    [TestClass]
    public class PknodInterpreterTest
    {
        [TestMethod]
        public void Utomlänare()
        {
            var interpreter = new PknodInterpreter(CommonData.TolvanPknodResult);
            interpreter.Utomlänare.Should().Be(false);
            interpreter.Län.Should().Be(Enums.Länskoder.Stockholms_län);
            interpreter.Kommun.Should().Be(Enums.Kommunkoder.Stockholm);

            var interpreterKalmar = new PknodInterpreter(CommonData.TolvanWithKalmarLän);
            interpreterKalmar.Utomlänare.Should().Be(true);
            interpreterKalmar.Län.Should().Be(Enums.Länskoder.Kalmar_län);
            interpreterKalmar.Kommun.Should().Be(Enums.Kommunkoder.Högsby);
        }

        [TestMethod]
        public void SaknarLän()
        {
            var interpreter = new PknodPlusInterpreter(TestPersonsPuData.PuDataList[33]); // 19300807-7723
            interpreter.Län.Should().Be(Enums.Länskoder.SAKNAS_ELLER_FELAKTIGT);
        }

        [TestMethod]
        public void SaknarKommun()
        {
            var interpreter = new PknodPlusInterpreter(TestPersonsPuData.PuDataList[33]); // 19300807-7723
            interpreter.Kommun.Should().Be(Enums.Kommunkoder.SAKNAS_ELLER_FELAKTIGT);
        }

        [TestMethod]
        public void Efternamn()
        {
            var interpreter = new PknodInterpreter(CommonData.TolvanWithTillsalsnamn);
            interpreter.Efternamn.Should().Be("TOLVANSSON");
        }

        [TestMethod]
        public void Förnamn()
        {
            var interpreter = new PknodInterpreter(CommonData.TolvanWithTillsalsnamn);
            interpreter.Förnamn.ShouldBeEquivalentTo(new[] { "TOLVAN", "LARS", "ERIK" });

            var pknodPlusData = new PknodPlusData(CommonData.TolvanPlusWithTillsalsnamn);
            var plusInterpreter = new PknodPlusInterpreter(pknodPlusData);
            plusInterpreter.Förnamn.ShouldBeEquivalentTo(new[] { "Tolvan", "Lars", "Erik" });
        }

        [TestMethod]
        public void FörnamnWithOnlyOneSlash()
        {
            // Badly truncated data
            var interpreter = new PknodInterpreter(CommonData.TolvanWithOnlyOneSlashInTilltalsnamn);
            interpreter.Förnamn.ShouldBeEquivalentTo(new[] { "TOLVAN", "LARS", "ERIK" });
            interpreter.Tilltalsnamn.Should().Be("ERIK");
        }

        [TestMethod]
        public void FörnamnWithSpaceInTilltalsnamn()
        {
            // Badly truncated data
            var interpreter = new PknodInterpreter(CommonData.TolvanWithSpaceInTillsalsnamn);
            interpreter.Förnamn.ShouldBeEquivalentTo(new[] { "TOLVAN", "LARS OLA", "BENGT" });
            interpreter.Tilltalsnamn.Should().Be("LARS OLA");
        }

        [TestMethod]
        public void Tilltalsnamn()
        {
            var interpreter = new PknodInterpreter(CommonData.TolvanWithTillsalsnamn);
            interpreter.TilltalsnamnIndex.Should().Be(1);
            interpreter.Tilltalsnamn.Should().Be("LARS");
        }


        [TestMethod]
        public void SaknarFornamn()
        {
            var interpreter = new PknodPlusInterpreter(CommonData.TolvanWithEmptyFörnamn);
            interpreter.TilltalsnamnIndex.Should().Be(0);
            interpreter.Tilltalsnamn.Should().BeNull();
            interpreter.Förnamn.ShouldBeEquivalentTo(Enumerable.Empty<string>());
        }

        [TestMethod]
        public void TestAvliden()
        {
            var interpreter = new PknodPlusInterpreter(CommonData.TolvanPknodPlusResult);
            interpreter.Avliden.Should().BeFalse();
            interpreter.AvlidenDatum.Should().Be(null);

            var pknodDataAvliden = new PknodPlusData(CommonData.AvlidenPerson);
            var avlidenInterpreted = new PknodPlusInterpreter(pknodDataAvliden);
            avlidenInterpreted.Avliden.Should().BeTrue();
            avlidenInterpreted.AvlidenDatum.Should().Be(new DateTime(2005, 02, 21));
        }

        [TestMethod]
        public void GetCompositeAdresses()
        {
            var interpreter = new PknodInterpreter(CommonData.TolvanPknodResult);
            interpreter.Adress.AdressRad1.Should().Be("TOLVAR STIGEN");
            interpreter.Adress.AdressRad2.Should().BeEmpty();
            interpreter.Adress.Co_adress.Should().BeEmpty();
            interpreter.Adress.Postnummer.Should().Be("12345");
            interpreter.Adress.Postort.Should().Be("STOCKHOLM");

            // Fallback to PKNOD data
            var interpreterPlus = new PknodPlusInterpreter(CommonData.TolvanPknodPlusResult);
            interpreterPlus.Adress.AdressRad1.Should().Be("TOLVAR STIGEN");
            interpreterPlus.Adress.AdressRad2.Should().BeEmpty();
            interpreterPlus.Adress.Co_adress.Should().BeEmpty();
            interpreterPlus.Adress.Postnummer.Should().Be("12345");
            interpreterPlus.Adress.Postort.Should().Be("STOCKHOLM");
            // No utdelningsadress specified
            interpreterPlus.SärskildUtdelningsAdress.Should().BeNull();

            interpreterPlus = new PknodPlusInterpreter(CommonData.TolvanWithPlusAddress);
            interpreterPlus.Adress.AdressRad1.Should().Be("Folkbokföringsadress1");
            interpreterPlus.Adress.AdressRad2.Should().Be("Folkbokföringsadress2");
            interpreterPlus.Adress.Co_adress.Should().Be("Tolvan_CO_Folkbokföringsadress");
            interpreterPlus.Adress.Postnummer.Should().Be("98765");
            interpreterPlus.Adress.Postort.Should().Be("StockholmFolkbokföringsadr.");

            interpreterPlus.SärskildUtdelningsAdress.AdressRad1.Should().Be("SärskildAdress1");
            interpreterPlus.SärskildUtdelningsAdress.AdressRad2.Should().Be("SärskildAdress2");
            interpreterPlus.SärskildUtdelningsAdress.Co_adress.Should().Be("Tolvan_CO_SärskildAdress");
            interpreterPlus.SärskildUtdelningsAdress.Postnummer.Should().Be("45678");
            interpreterPlus.SärskildUtdelningsAdress.Postort.Should().Be("StockholmSärskildAdr.");
        }
    }
}

