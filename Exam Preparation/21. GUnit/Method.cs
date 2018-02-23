using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.GUnit
{
    public class Method
    {
        public Method(string methodName, List<string> tests)
        {
            MethodName = methodName;
            Tests = tests;
        }

        public string MethodName { get; set; }
        public List<string> Tests { get; set; }
    }
}
