using System;
using System.Collections.Generic;

namespace Eurdep.NET.Format.v2_1.Enums
{
    public sealed class UncertaintyType
    {
        private readonly string name;

        private static readonly Dictionary<string, UncertaintyType> instance = new Dictionary<string, UncertaintyType>();

        public static readonly UncertaintyType A = new UncertaintyType(@"A");
        public static readonly UncertaintyType B = new UncertaintyType(@"B");
        public static readonly UncertaintyType C = new UncertaintyType(@"C");
        public static readonly UncertaintyType D = new UncertaintyType(@"D");
        public static readonly UncertaintyType E = new UncertaintyType(@"E");
        public static readonly UncertaintyType F = new UncertaintyType(@"F");
        public static readonly UncertaintyType G = new UncertaintyType(@"G");
        public static readonly UncertaintyType H = new UncertaintyType(@"H");
        public static readonly UncertaintyType I = new UncertaintyType(@"I");
        public static readonly UncertaintyType J = new UncertaintyType(@"J");
        public static readonly UncertaintyType K = new UncertaintyType(@"K");
        public static readonly UncertaintyType L = new UncertaintyType(@"L");
        public static readonly UncertaintyType M = new UncertaintyType(@"M");
        public static readonly UncertaintyType Z = new UncertaintyType(@"Z");

        private UncertaintyType(string name)
        {
            this.name = name;
            instance[this.name] = this;
        }

        public static explicit operator UncertaintyType(string str)
        {
            UncertaintyType result;
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
