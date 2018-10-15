using SignalValidator.IOProcessor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SignalValidator
{
    public class JsonPrinter
    {
        private static String jsonResult = string.Empty;
        /// <summary>
        /// Gathers the result in Json format
        /// </summary>
        /// <param name="result"></param>
        /// <param name="msg"></param>
        public void PrintResult(IEnumerable<RawInput> result, String msg)
        {
            try
            {
                if (result.Count() > 0)
                {
                    foreach (RawInput ri in result)
                    {
                        jsonResult += "{\"signal\":\"" + ri.Signal + "\", \"value\":\"" + ri.Value + "\", \"error\":\"" + msg + "\"},";
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write("Error Occured: " + e);
            }
        }

        /// <summary>
        /// Prints the result in output file. This will rewrite the file, if the file already exists
        /// </summary>
        /// <param name="outputFileName"></param>
        public void PrintResult(String outputFileName)
        {
            try
            {
                if (jsonResult.Length > 1)
                {
                    StreamWriter sw = new StreamWriter(@outputFileName, false);
                    jsonResult = "[" + jsonResult.Substring(0, jsonResult.Length - 1) + "]";
                    sw.WriteLine(jsonResult);
                    sw.Close();
                    Console.Write("Result file Generated!");
                }
                else
                {
                    Console.Write("No Error found!");
                }
            }
            catch (Exception e)
            {
                Console.Write("Error Occured: " + e);
            }
        }
    }
}
