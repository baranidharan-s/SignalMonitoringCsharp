using System;
using System.Collections.Generic;
using System.Configuration;
using SignalValidator.IOProcessor;
using SignalValidator.BL;

namespace SignalValidator.App
{
    class Application
    {
        static void Main(string[] args)
        {
            try
            {
                Rules rul = new Rules();
                JsonReader jr = new JsonReader();
                JsonPrinter jp = new JsonPrinter();
                Validator val = new Validator();

                //Loading input file
                jr.file_name = ConfigurationManager.AppSettings.Get("InputFileLocation"); 
                IEnumerable<RawInput> jsonInput = jr.ReadJson<RawInput>();

                //Loading Rules file
                jr.file_name = ConfigurationManager.AppSettings.Get("RulesFileLocation");
                IEnumerable<Rules> jsonRules = jr.ReadJson<Rules>();

                //Validating Signals
                val.Validation(jsonRules, jsonInput);

                //Print result in json format
                jp.PrintResult(ConfigurationManager.AppSettings.Get("OutputFileLocation"));

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.Write("Error Occured: " + e);
            }
        }

    }
}
