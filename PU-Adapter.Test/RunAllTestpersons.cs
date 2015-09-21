using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kentor.PU_Adapter.Test
{
    [TestClass]
    public class RunAllTestpersons
    {
        [TestMethod]
        public void PknodPlusParse()
        {
            foreach (var data in TestPersonsPuData.PuDataList)
            {
                var pknodPlusdata = new PknodPlusData(data);
                var allData = Newtonsoft.Json.JsonConvert.SerializeObject(pknodPlusdata);
            }
        }

        [TestMethod]
        public void PknodPlusInterpret()
        {
            foreach (var data in TestPersonsPuData.PuDataList)
            {
                var pknodPlusdata = new PknodPlusData(data);
                var interpretedData = new PknodPlusInterpreter(pknodPlusdata);
                var allData = Newtonsoft.Json.JsonConvert.SerializeObject(interpretedData);
            }
        }
    }
}
