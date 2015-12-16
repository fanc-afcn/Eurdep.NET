using System;
using System.Collections.Generic;

namespace Eurdep.NET.Format.v2_1.Enums
{
    public sealed class Carrier
    {
        private readonly string name;

        private static readonly Dictionary<string, Carrier> instance = new Dictionary<string, Carrier>();

        public static readonly Carrier FTP = new Carrier("FTP");
        public static readonly Carrier EMAIL = new Carrier("EMAIL");
        public static readonly Carrier MIRROR = new Carrier("MIRROR");
        public static readonly Carrier HTTP = new Carrier("HTTP");
        public static readonly Carrier FILE = new Carrier("FILE");

        private Carrier(string name)
        {
            this.name = name;
            instance[this.name] = this;
        }

        public static explicit operator Carrier(string str)
        {
            Carrier result;
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
