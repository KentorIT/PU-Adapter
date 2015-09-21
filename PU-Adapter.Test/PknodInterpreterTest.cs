using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Kentor.PU_Adapter.TestData;

namespace Kentor.PU_Adapter.Test
{
    [TestClass]
    public class PknodInterpreterTest
    {
        [TestMethod]
        public void Utomlänare()
        {
            var pknodData = new PknodData(CommonData.TolvanPknodResult);
            var interpreter = new PknodInterpreter(pknodData);
            interpreter.Utomlänare.Should().Be(false);
            interpreter.Län.Should().Be(Enums.Länskoder.Stockholms_län);
            interpreter.Kommun.Should().Be(Enums.Kommunkoder.Stockholm);

            var kalmarLän = new PknodData(CommonData.TolvanWithKalmarLän);
            var interpreterKalmar = new PknodInterpreter(kalmarLän);
            interpreterKalmar.Utomlänare.Should().Be(true);
            interpreterKalmar.Län.Should().Be(Enums.Länskoder.Kalmar_län);
            interpreterKalmar.Kommun.Should().Be(Enums.Kommunkoder.Högsby);
        }

        [TestMethod]
        public void SaknarLän()
        {
            var pknodData = new PknodPlusData(TestPersonsPuData.PuDataList[33]); // 19300807-7723
            var interpreter = new PknodInterpreter(pknodData);
            interpreter.Län.Should().Be(Enums.Länskoder.SAKNAS_ELLER_FELAKTIGT);
        }

        [TestMethod]
        public void SaknarKommun()
        {
            var pknodData = new PknodPlusData(TestPersonsPuData.PuDataList[33]); // 19300807-7723
            var interpreter = new PknodInterpreter(pknodData);
            interpreter.Kommun.Should().Be(Enums.Kommunkoder.SAKNAS_ELLER_FELAKTIGT);
        }

        [TestMethod]
        public void Efternamn()
        {
            var pknodData = new PknodData(CommonData.TolvanWithTillsalsnamn);
            var interpreter = new PknodInterpreter(pknodData);
            interpreter.Efternamn.Should().Be("TOLVANSSON");
        }

        [TestMethod]
        public void Förnamn()
        {
            var pknodData = new PknodData(CommonData.TolvanWithTillsalsnamn);
            var interpreter = new PknodInterpreter(pknodData);
            interpreter.Förnamn.ShouldBeEquivalentTo(new[] { "TOLVAN", "LARS", "ERIK" });

            var pknodPlusData = new PknodPlusData(CommonData.TolvanPlusWithTillsalsnamn);
            var plusInterpreter = new PknodPlusInterpreter(pknodPlusData);
            plusInterpreter.Förnamn.ShouldBeEquivalentTo(new[] { "Tolvan", "Lars", "Erik" });
        }

        [TestMethod]
        public void Tilltalsnamn()
        {
            var pknodData = new PknodData(CommonData.TolvanWithTillsalsnamn);
            var interpreter = new PknodInterpreter(pknodData);
            interpreter.TilltalsnamnIndex.Should().Be(1);
            interpreter.Tilltalsnamn.Should().Be("LARS");
        }

        [TestMethod]
        public void TestAvliden()
        {
            var pknodData = new PknodPlusData(CommonData.TolvanPknodPlusResult);
            var interpreter = new PknodPlusInterpreter(pknodData);
            interpreter.Avliden.Should().BeFalse();
            interpreter.AvlidenDatum.Should().Be(null);

            var pknodDataAvliden = new PknodPlusData(CommonData.AvlidenPerson);
            var avlidenInterpreted = new PknodPlusInterpreter(pknodDataAvliden);
            avlidenInterpreted.Avliden.Should().BeTrue();
            avlidenInterpreted.AvlidenDatum.Should().Be(new DateTime(2005, 02, 21));
        }
    }
}

