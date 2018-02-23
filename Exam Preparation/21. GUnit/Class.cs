using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.GUnit
{
    public class Class
    {
        public Class(string className, List<Method> methods)
        {
            ClassName = className;
            Methods = methods;
        }

        public string ClassName { get; set; }
        public List<Method> Methods { get; set; }
    }
}
