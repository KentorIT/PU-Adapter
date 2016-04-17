using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Kentor.PU_Adapter;

namespace Kentor.PU_Adapter.Test
{
    [TestClass]
    public class FieldDataTest
    {
        [TestMethod]
        public void ParseGivenPosition()
        {
            var pknodData = new PknodData(CommonData.TolvanPknodResult);
            pknodData.GetStringFieldFromPosition(new FieldDefinitions.FieldDefinition(3, 12)).Should().Be("040000191212");
        }
    }
}
