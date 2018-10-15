using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;


namespace SignalValidator.IOProcessor
{
    public class JsonReader
    {
        public string file_name;

        /// <summary>
        /// Reads Json file and returs as List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> ReadJson<T>()
        {
            String file = file_name;
            var DataList = new List<T>();

            try
            {
                string Json = System.IO.File.ReadAllText(file);
                Json = Json.Replace("value_type", "valuetype");
                JavaScriptSerializer ser = new JavaScriptSerializer();
                DataList = ser.Deserialize<List<T>>(Json);
               
            }
            catch (Exception e)
            {
                Console.Write("Error Occured: " + e);
            }

            return DataList;
        }
    }
   
}
