using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

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
    }
}

