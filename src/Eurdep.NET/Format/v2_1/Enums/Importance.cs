using System;
using System.Collections.Generic;

namespace Eurdep.NET.Format.v2_1.Enums
{
    public sealed class Importance
    {
        private readonly string name;

        private static readonly Dictionary<string, Importance> instance = new Dictionary<string, Importance>();

        public static readonly Importance TEST = new Importance("TEST");
        public static readonly Importance NORMAL = new Importance("NORMAL");
        public static readonly Importance ROUTINE = new Importance("ROUTINE");
        public static readonly Importance EMERGENCY = new Importance("EMERGENCY");

        private Importance(string name)
        {
            this.name = name;
            instance[this.name] = this;
        }

        public static explicit operator Importance(string str)
        {
            Importance result;
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
