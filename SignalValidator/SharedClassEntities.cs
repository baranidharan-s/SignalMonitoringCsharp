using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalValidator.IOProcessor
{
    public class SignalValue
    {
        public String Signal
        {
            get;
            set;
        }
        public String Value
        {
            get;
            set;
        }
    }
    public class RawInput: SignalValue
    {
       
        public String ValueType
        {
            get;
            set;
        }

        public RawInput()
        {
            Signal = string.Empty;
            ValueType = string.Empty;
            Value = string.Empty;
        }
    }

    public class Rules : RawInput
    {
        public String Rule
        {
            get;
            set;
        }

        public Rules()
        {
            Rule = string.Empty;
        }
    }
}
