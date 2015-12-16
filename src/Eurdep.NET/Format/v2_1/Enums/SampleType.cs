using System;
using System.Collections.Generic;

namespace Eurdep.NET.Format.v2_1.Enums
{
    public sealed class SampleType
    {
        private readonly string name;

        private static readonly Dictionary<string, SampleType> instance = new Dictionary<string, SampleType>();

        public static readonly SampleType A = new SampleType(@"A");
        public static readonly SampleType A1 = new SampleType(@"A1");
        public static readonly SampleType A11 = new SampleType(@"A11");
        public static readonly SampleType A2 = new SampleType(@"A2");
        public static readonly SampleType A20 = new SampleType(@"A20");
        public static readonly SampleType A21 = new SampleType(@"A21");
        public static readonly SampleType A210 = new SampleType(@"A210");
        public static readonly SampleType A211 = new SampleType(@"A211");
        public static readonly SampleType A212 = new SampleType(@"A212");
        public static readonly SampleType A213 = new SampleType(@"A213");
        public static readonly SampleType A214 = new SampleType(@"A214");
        public static readonly SampleType A215 = new SampleType(@"A215");
        public static readonly SampleType A216 = new SampleType(@"A216");
        public static readonly SampleType A22 = new SampleType(@"A22");
        public static readonly SampleType A220 = new SampleType(@"A220");
        public static readonly SampleType A221 = new SampleType(@"A221");
        public static readonly SampleType A222 = new SampleType(@"A222");
        public static readonly SampleType A223 = new SampleType(@"A223");
        public static readonly SampleType A224 = new SampleType(@"A224");
        public static readonly SampleType A225 = new SampleType(@"A225");
        public static readonly SampleType A23 = new SampleType(@"A23");
        public static readonly SampleType A230 = new SampleType(@"A230");
        public static readonly SampleType A231 = new SampleType(@"A231");
        public static readonly SampleType A2Z1 = new SampleType(@"A2Z1");
        public static readonly SampleType A2Z2 = new SampleType(@"A2Z2");
        public static readonly SampleType A3 = new SampleType(@"A3");
        public static readonly SampleType A31 = new SampleType(@"A31");
        public static readonly SampleType A310 = new SampleType(@"A310");
        public static readonly SampleType A311 = new SampleType(@"A311");
        public static readonly SampleType A312 = new SampleType(@"A312");
        public static readonly SampleType A313 = new SampleType(@"A313");
        public static readonly SampleType A314 = new SampleType(@"A314");
        public static readonly SampleType A315 = new SampleType(@"A315");
        public static readonly SampleType A316 = new SampleType(@"A316");
        public static readonly SampleType A317 = new SampleType(@"A317");
        public static readonly SampleType A318 = new SampleType(@"A318");
        public static readonly SampleType A319 = new SampleType(@"A319");
        public static readonly SampleType A31A = new SampleType(@"A31A");
        public static readonly SampleType A31B = new SampleType(@"A31B");
        public static readonly SampleType A32 = new SampleType(@"A32");
        public static readonly SampleType A33 = new SampleType(@"A33");
        public static readonly SampleType A4 = new SampleType(@"A4");
        public static readonly SampleType A40 = new SampleType(@"A40");
        public static readonly SampleType A41 = new SampleType(@"A41");
        public static readonly SampleType A410 = new SampleType(@"A410");
        public static readonly SampleType A411 = new SampleType(@"A411");
        public static readonly SampleType A412 = new SampleType(@"A412");
        public static readonly SampleType A413 = new SampleType(@"A413");
        public static readonly SampleType A42 = new SampleType(@"A42");
        public static readonly SampleType A420 = new SampleType(@"A420");
        public static readonly SampleType A421 = new SampleType(@"A421");
        public static readonly SampleType A422 = new SampleType(@"A422");
        public static readonly SampleType A423 = new SampleType(@"A423");
        public static readonly SampleType A43 = new SampleType(@"A43");
        public static readonly SampleType A44 = new SampleType(@"A44");
        public static readonly SampleType A5 = new SampleType(@"A5");
        public static readonly SampleType A6 = new SampleType(@"A6");
        public static readonly SampleType AZ = new SampleType(@"AZ");

        private SampleType(string name)
        {
            this.name = name;
            instance[this.name] = this;
        }

        public static explicit operator SampleType(string str)
        {
            SampleType result;
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
