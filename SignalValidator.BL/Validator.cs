using SignalValidator.IOProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SignalValidator.BL
{
    public class Validator
    {
        /// <summary>
        /// Validates the Input Json file with the User defined Signal Rules
        /// </summary>
        /// <param name="jsonRules"></param>
        /// <param name="jsonInput"></param>
        public void Validation(IEnumerable<Rules> jsonRules, IEnumerable<RawInput> jsonInput)
        {
            JsonPrinter jp = new JsonPrinter();
            try
            {
                foreach (Rules rl in jsonRules)
                {
                    IEnumerable<RawInput> inputFiltered;
                    IEnumerable<RawInput> err;

                    inputFiltered = jsonInput.Cast<RawInput>().Where(x => x.Signal.ToLower() == rl.Signal.ToLower() && x.ValueType.ToLower() == rl.ValueType.ToLower()).ToList();

                    if (inputFiltered.Count() > 0)
                    {

                        if (rl.ValueType == "Integer")
                        {
                            switch (rl.Rule)
                            {
                                case ">":
                                    err = inputFiltered.Cast<RawInput>().Where(x => Convert.ToDecimal(x.Value) > Convert.ToDecimal(rl.Value)).ToList();
                                    jp.PrintResult(err, "Value should not Greater than " + rl.Value);
                                    break;
                                case "=":
                                    err = inputFiltered.Cast<RawInput>().Where(x => Convert.ToDecimal(x.Value) == Convert.ToDecimal(rl.Value)).ToList();
                                    jp.PrintResult(err, "Value should not equal to " + rl.Value);
                                    break;
                                case ">=":
                                    err = inputFiltered.Cast<RawInput>().Where(x => Convert.ToDecimal(x.Value) >= Convert.ToDecimal(rl.Value)).ToList();
                                    jp.PrintResult(err, "Value should not Greater than or equal to " + rl.Value);
                                    break;
                                case "!=":
                                    err = inputFiltered.Cast<RawInput>().Where(x => Convert.ToDecimal(x.Value) != Convert.ToDecimal(rl.Value)).ToList();
                                    jp.PrintResult(err, "Value should be equal to " + rl.Value);
                                    break;
                                case "<=":
                                    err = inputFiltered.Cast<RawInput>().Where(x => Convert.ToDecimal(x.Value) <= Convert.ToDecimal(rl.Value)).ToList();
                                    jp.PrintResult(err, "Value should not less than or equal to" + rl.Value);
                                    break;
                                case "<":
                                    err = inputFiltered.Cast<RawInput>().Where(x => Convert.ToDecimal(x.Value) < Convert.ToDecimal(rl.Value)).ToList();
                                    jp.PrintResult(err, "Value should not less than " + rl.Value);
                                    break;
                                default:
                                    Console.WriteLine("ERROR: Invalid RULE for the Signal {0} and Value Type {1} as {2}", rl.Signal, rl.ValueType, rl.Rule);
                                    break;
                            }
                        }
                        else if (rl.ValueType == "String")
                        {
                            switch (rl.Rule)
                            {
                                case "=":
                                    err = inputFiltered.Cast<RawInput>().Where(x => x.Value.ToLower() == rl.Value.ToLower()).ToList();
                                    jp.PrintResult(err, "Value should not equal to " + rl.Value);
                                    break;
                                case "!=":
                                    err = inputFiltered.Cast<RawInput>().Where(x => x.Value.ToLower() != rl.Value.ToLower()).ToList();
                                    jp.PrintResult(err, "Value should be equal to " + rl.Value);
                                    break;
                                default:
                                    Console.WriteLine("ERROR: Invalid RULE for the Signal {0} and Value Type {1} as {2}", rl.Signal, rl.ValueType, rl.Rule);
                                    break;
                            }
                        }
                        else if (rl.ValueType == "DateTime")
                        {
                            switch (rl.Rule.ToLower())
                            {
                                case "today":
                                    err = inputFiltered.Cast<RawInput>().Where(x => DateTimeConvertor(x.Value) > DateTime.Now).ToList();
                                    jp.PrintResult(err, "Value should not Greater than " + rl.Value);
                                    break;
                                case ">":
                                    err = inputFiltered.Cast<RawInput>().Where(x => DateTimeConvertor(x.Value) > DateTimeConvertor(rl.Value)).ToList();
                                    jp.PrintResult(err, "Value should not Greater than " + rl.Value);
                                    break;
                                case "=":
                                    err = inputFiltered.Cast<RawInput>().Where(x => DateTimeConvertor(x.Value) == DateTimeConvertor(rl.Value)).ToList();
                                    jp.PrintResult(err, "Value should not equal to " + rl.Value);
                                    break;
                                case ">=":
                                    err = inputFiltered.Cast<RawInput>().Where(x => DateTimeConvertor(x.Value) >= DateTimeConvertor(rl.Value)).ToList();
                                    jp.PrintResult(err, "Value should not Greater than or equal to " + rl.Value);
                                    break;
                                case "!=":
                                    err = inputFiltered.Cast<RawInput>().Where(x => DateTimeConvertor(x.Value) != DateTimeConvertor(rl.Value)).ToList();
                                    jp.PrintResult(err, "Value should be equal to " + rl.Value);
                                    break;
                                case "<=":
                                    err = inputFiltered.Cast<RawInput>().Where(x => DateTimeConvertor(x.Value) <= DateTimeConvertor(rl.Value)).ToList();
                                    jp.PrintResult(err, "Value should not less than or equal to" + rl.Value);
                                    break;
                                case "<":
                                    err = inputFiltered.Cast<RawInput>().Where(x => DateTimeConvertor(x.Value) < DateTimeConvertor(rl.Value)).ToList();
                                    jp.PrintResult(err, "Value should not less than " + rl.Value);
                                    break;
                                default:
                                    Console.WriteLine("ERROR: Invalid RULE for the Signal {0} and Value Type {1} as {2}", rl.Signal, rl.ValueType, rl.Rule);
                                    break;
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.Write("Error Occured: " + e);
            }
        }

        private DateTime DateTimeConvertor(String val)
        {
            if (val.Length > 19)
            {
                return Convert.ToDateTime(val.Substring(0, 19));
            }
            else
            {
                return Convert.ToDateTime(val);
            }

        }
    }
}
