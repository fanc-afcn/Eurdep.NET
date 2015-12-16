using System;
using System.Collections.Generic;

namespace Eurdep.NET.Format.v2_1.Enums
{
    public sealed class ApparatusType
    {
        private readonly string name;

        private static readonly Dictionary<string, ApparatusType> instance = new Dictionary<string, ApparatusType>();

        public static readonly ApparatusType A = new ApparatusType(@"A");
        public static readonly ApparatusType B = new ApparatusType(@"B");
        public static readonly ApparatusType C = new ApparatusType(@"C");
        public static readonly ApparatusType D = new ApparatusType(@"D");
        public static readonly ApparatusType E = new ApparatusType(@"E");
        public static readonly ApparatusType F = new ApparatusType(@"F");
        public static readonly ApparatusType G = new ApparatusType(@"G");
        public static readonly ApparatusType H = new ApparatusType(@"H");
        public static readonly ApparatusType I = new ApparatusType(@"I");
        public static readonly ApparatusType J = new ApparatusType(@"J");
        public static readonly ApparatusType K = new ApparatusType(@"K");
        public static readonly ApparatusType L = new ApparatusType(@"L");
        public static readonly ApparatusType M = new ApparatusType(@"M");
        public static readonly ApparatusType N = new ApparatusType(@"N");
        public static readonly ApparatusType O = new ApparatusType(@"O");
        public static readonly ApparatusType P = new ApparatusType(@"P");
        public static readonly ApparatusType Q = new ApparatusType(@"Q");
        public static readonly ApparatusType R = new ApparatusType(@"R");
        public static readonly ApparatusType S = new ApparatusType(@"S");
        public static readonly ApparatusType T = new ApparatusType(@"T");
        public static readonly ApparatusType U = new ApparatusType(@"U");
        public static readonly ApparatusType V = new ApparatusType(@"V");
        public static readonly ApparatusType W = new ApparatusType(@"W");
        public static readonly ApparatusType X = new ApparatusType(@"X");
        public static readonly ApparatusType Y = new ApparatusType(@"Y");
        public static readonly ApparatusType Z = new ApparatusType(@"Z");
        public static readonly ApparatusType _1 = new ApparatusType(@"1");


        private ApparatusType(string name)
        {
            this.name = name;
            instance[this.name] = this;
        }

        public static explicit operator ApparatusType(string str)
        {
            ApparatusType result;
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
