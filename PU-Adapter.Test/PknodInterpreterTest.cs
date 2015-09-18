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

            var kalmarLän = new PknodData(CommonData.TolvanWithKalmarLän);
            var interpreterKalmar = new PknodInterpreter(kalmarLän);
            interpreterKalmar.Utomlänare.Should().Be(true);
        }
    }
}

