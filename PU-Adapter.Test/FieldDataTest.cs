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

        [TestMethod]
        public void GetIntFieldFromPositionShouldThrowSensibleErrorsForNonParsableData()
        {
            var pknodData = new PknodData(CommonData.TolvanPknodResult);
            Action a = () => pknodData.GetIntFieldFromPosition(FieldDefinitions.Pknod.Namn_0042); // Namn is not an int, should throw an error

            a.ShouldThrow<InvalidOperationException>().WithMessage("Could not parse \"TOLVANSSON, TOLVAN\" (position 42) as int");
        }
    }
}
