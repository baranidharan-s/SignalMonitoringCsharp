using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalValidator.IOProcessor;
using SignalValidator.BL;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace SignalValidator.BLTest
{
    public class TestInput : SignalValue
    {

        public String Error
        {
            get;
            set;
        }

        public TestInput()
        {
            Signal = string.Empty;
            Value = string.Empty;
            Error = string.Empty;
        }
    }

    [TestClass()]
    public class Validator_UT
    {

        [TestMethod()]
        public void ValidateBL()
        {
            Rules rul = new Rules();
            JsonReader jr = new JsonReader();
            JsonPrinter jp = new JsonPrinter();
            Validator val = new Validator();

            //Generate output
            jr.file_name = "../../IOFiles/raw_data.Json";
            IEnumerable<RawInput> jsonInput = jr.ReadJson<RawInput>();


            jr.file_name = "../../Input/rules.json";
            IEnumerable<Rules> jsonRules = jr.ReadJson<Rules>();

            val.Validation(jsonRules, jsonInput);
            jp.PrintResult("../../IOFiles/Result.Json");

            //Actual output
            jr.file_name = "../../IOFiles/Result.Json";
            IEnumerable<TestInput> utOutput = jr.ReadJson<TestInput>();

            //Expected output
            jr.file_name = "../../IOFiles/UT_Result.Json";
            IEnumerable<TestInput> utCompare = jr.ReadJson<TestInput>();

            Compare(utOutput, utCompare);
        }

        /// <summary>
        /// Compares the Result file with the expected result file
        /// </summary>
        /// <param name="utOutput"></param>
        /// <param name="utCompare"></param>
        private void Compare(IEnumerable<TestInput> utOutput, IEnumerable<TestInput> utCompare)
        {
            
            Assert.AreEqual(utOutput.Count(), utCompare.Count());
            if (utOutput.Count() == utCompare.Count())
            {
                foreach (TestInput ut in utCompare)
                {
                    IEnumerable<TestInput> utCompareResult;
                    utCompareResult = utOutput.Cast<TestInput>().Where(x => x.Signal.ToLower() == ut.Signal.ToLower() && x.Value.ToLower() == ut.Value.ToLower() && x.Error.ToLower() == ut.Error.ToLower()).ToList();
                    Assert.IsTrue(utCompareResult.Count() > 0);
                }
            }
        }

    }
}
