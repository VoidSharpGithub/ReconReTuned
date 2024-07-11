using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Objects
{
    public class SOAPActionObject
    {
        public string Name { get; set; }
        public List<SOAPActionArgument>? Arguments { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
    public class SOAPActionArgument
    {
        public string Name { get; set; }
        public string Direction { get; set; }
        public string RelatedStateVariable { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class SOAPActionDataGridArgument
    {
        public SOAPActionArgument Argument { get; set; } 
        public string Value { get; set; } 
        public string ControlType { get; set; }
        public SOAPActionStateVariable Variable { get; set; }

        public SOAPActionDataGridArgument(SOAPActionArgument argument)
        {
            Argument = argument;
            Value = "";
            ControlType = "Text"; //Default
        }
        public SOAPActionDataGridArgument(SOAPActionArgument argument, string controlType, SOAPActionStateVariable variable)
        {
            Argument = argument;
            Value = "";
            ControlType = controlType;
            Variable = variable;
        }
    }

    public class SOAPActionStateVariable
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public ValueRange? AllowedValueRange { get; set; }
        public List<string>? AllowedValues { get; set; }
    }
    public class ValueRange
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }
}
