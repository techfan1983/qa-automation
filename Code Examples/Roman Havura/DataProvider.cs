using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNUnit.Utils
{
    class DataProvider : IEnumerable
    {
        private static readonly string calculationDataJson = 
            File.ReadAllText($@"{TestContext.CurrentContext.WorkDirectory}\..\..\TestData\calculationData.json");
        private static readonly JObject calculationData = JObject.Parse(calculationDataJson);

        public IEnumerator GetEnumerator()
        {
            yield return (string)calculationData["firstCalculation"];
            yield return (string)calculationData["secondCalculation"];
        }
    }
}
