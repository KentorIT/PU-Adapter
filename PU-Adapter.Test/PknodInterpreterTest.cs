using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Kentor.PU_Adapter.Test
{
    [TestClass]
    public class PknodInterpreterTest
    {
        [TestMethod]
        public void TestUtomlänare()
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
    }
}

