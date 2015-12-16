using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurdep.NET.Format.v2_1.Enums
{
    public sealed class Constraint
    {
        private readonly string name;

        private static readonly Dictionary<string, Constraint> instance = new Dictionary<string, Constraint>();

        public static readonly Constraint GT = new Constraint(">");
        public static readonly Constraint LT = new Constraint("<");
 
        private Constraint(string name)
        {
            this.name = name;
            instance[this.name] = this;
        }

        public static explicit operator Constraint(string str)
        {
            Constraint result;
            if (instance.TryGetValue(str, out result))
                return result;
            else
                throw new InvalidCastException();
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
