using System;
using System.Collections.Generic;

namespace Eurdep.NET.Format.v2_1.Enums
{
    public sealed class SampleTreatment
    {
        private readonly string name;

        private static readonly Dictionary<string, SampleTreatment> instance = new Dictionary<string, SampleTreatment>();

        public static readonly SampleTreatment _1 = new SampleTreatment(@"1");
        public static readonly SampleTreatment _2 = new SampleTreatment(@"2");
        public static readonly SampleTreatment A = new SampleTreatment(@"A");
        public static readonly SampleTreatment B = new SampleTreatment(@"B");
        public static readonly SampleTreatment C = new SampleTreatment(@"C");
        public static readonly SampleTreatment D = new SampleTreatment(@"D");
        public static readonly SampleTreatment E = new SampleTreatment(@"E");
        public static readonly SampleTreatment F = new SampleTreatment(@"F");
        public static readonly SampleTreatment G = new SampleTreatment(@"G");
        public static readonly SampleTreatment H = new SampleTreatment(@"H");
        public static readonly SampleTreatment I = new SampleTreatment(@"I");
        public static readonly SampleTreatment J = new SampleTreatment(@"J");
        public static readonly SampleTreatment K = new SampleTreatment(@"K");
        public static readonly SampleTreatment L = new SampleTreatment(@"L");
        public static readonly SampleTreatment M = new SampleTreatment(@"M");
        public static readonly SampleTreatment N = new SampleTreatment(@"N");
        public static readonly SampleTreatment O = new SampleTreatment(@"O");
        public static readonly SampleTreatment P = new SampleTreatment(@"P");
        public static readonly SampleTreatment Q = new SampleTreatment(@"Q");
        public static readonly SampleTreatment R = new SampleTreatment(@"R");
        public static readonly SampleTreatment S = new SampleTreatment(@"S");
        public static readonly SampleTreatment T = new SampleTreatment(@"T");
        public static readonly SampleTreatment U = new SampleTreatment(@"U");
        public static readonly SampleTreatment V = new SampleTreatment(@"V");
        public static readonly SampleTreatment W = new SampleTreatment(@"W");
        public static readonly SampleTreatment X = new SampleTreatment(@"X");
        public static readonly SampleTreatment Y = new SampleTreatment(@"Y");
        public static readonly SampleTreatment Z = new SampleTreatment(@"Z");



        private SampleTreatment(string name)
        {
            this.name = name;
            instance[this.name] = this;
        }

        public static explicit operator SampleTreatment(string str)
        {
            SampleTreatment result;
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
