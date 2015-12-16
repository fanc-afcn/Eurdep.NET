using System;
using System.Collections.Generic;

namespace Eurdep.NET.Format.v2_1.Enums
{
    public sealed class ValueType
    {
        private readonly string name;

        private static readonly Dictionary<string, ValueType> instance = new Dictionary<string, ValueType>();

        public static readonly ValueType A = new ValueType(@"A");
        public static readonly ValueType B = new ValueType(@"B");
        public static readonly ValueType C = new ValueType(@"C");
        public static readonly ValueType D = new ValueType(@"D");
        public static readonly ValueType E = new ValueType(@"E");
        public static readonly ValueType F = new ValueType(@"F");
        public static readonly ValueType G = new ValueType(@"G");
        public static readonly ValueType H = new ValueType(@"H");
        public static readonly ValueType I = new ValueType(@"I");
        public static readonly ValueType J = new ValueType(@"J");
        public static readonly ValueType K = new ValueType(@"K");
        public static readonly ValueType L = new ValueType(@"L");
        public static readonly ValueType M = new ValueType(@"M");
        public static readonly ValueType N = new ValueType(@"N");
        public static readonly ValueType O = new ValueType(@"O");
        public static readonly ValueType P = new ValueType(@"P");

        private ValueType(string name)
        {
            this.name = name;
            instance[this.name] = this;
        }

        public static explicit operator ValueType(string str)
        {
            ValueType result;
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
