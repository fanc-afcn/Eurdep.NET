using System;
using System.Collections.Generic;

namespace Eurdep.NET.Format.v2_1.Enums
{
    public sealed class MeasuringUnit
    {
        private readonly string name;

        private static readonly Dictionary<string, MeasuringUnit> instance = new Dictionary<string, MeasuringUnit>();

        public static readonly MeasuringUnit Percentage = new MeasuringUnit(@"%");
        public static readonly MeasuringUnit _95TH_PCT = new MeasuringUnit(@"95TH PCT");
        public static readonly MeasuringUnit _99TH_PCT = new MeasuringUnit(@"99TH PCT");
        public static readonly MeasuringUnit BQ = new MeasuringUnit(@"BQ");
        public static readonly MeasuringUnit BQ_H_M3 = new MeasuringUnit(@"BQ.H/M3");
        public static readonly MeasuringUnit BQ_S_M3 = new MeasuringUnit(@"BQ.S/M3");
        public static readonly MeasuringUnit BQ_D = new MeasuringUnit(@"BQ/D");
        public static readonly MeasuringUnit BQ_D_P = new MeasuringUnit(@"BQ/D.P");
        public static readonly MeasuringUnit BQ_D_CAP = new MeasuringUnit(@"BQ/D/CAP");
        public static readonly MeasuringUnit BQ_EGG = new MeasuringUnit(@"BQ/EGG");
        public static readonly MeasuringUnit BQ_G = new MeasuringUnit(@"BQ/G");
        public static readonly MeasuringUnit BQ_G_CA = new MeasuringUnit(@"BQ/G-CA");
        public static readonly MeasuringUnit BQ_G_K = new MeasuringUnit(@"BQ/G-K");
        public static readonly MeasuringUnit BQ_KG = new MeasuringUnit(@"BQ/KG");
        public static readonly MeasuringUnit BQ_L = new MeasuringUnit(@"BQ/L");
        public static readonly MeasuringUnit BQ_M2 = new MeasuringUnit(@"BQ/M2");
        public static readonly MeasuringUnit BQ_M2_D = new MeasuringUnit(@"BQ/M2/D");
        public static readonly MeasuringUnit BQ_M3 = new MeasuringUnit(@"BQ/M3");
        public static readonly MeasuringUnit CI_KM2 = new MeasuringUnit(@"CI/KM2");
        public static readonly MeasuringUnit CM = new MeasuringUnit(@"CM");
        public static readonly MeasuringUnit G = new MeasuringUnit(@"G");
        public static readonly MeasuringUnit G_KG = new MeasuringUnit(@"G/KG");
        public static readonly MeasuringUnit G_L = new MeasuringUnit(@"G/L");
        public static readonly MeasuringUnit KBQ_KG = new MeasuringUnit(@"KBQ/KG");
        public static readonly MeasuringUnit KBQ_L = new MeasuringUnit(@"KBQ/L");
        public static readonly MeasuringUnit KBQ_M2 = new MeasuringUnit(@"KBQ/M2");
        public static readonly MeasuringUnit KBQ_M3 = new MeasuringUnit(@"KBQ/M3");
        public static readonly MeasuringUnit KG = new MeasuringUnit(@"KG");
        public static readonly MeasuringUnit KG_M2 = new MeasuringUnit(@"KG/M2");
        public static readonly MeasuringUnit KG_M3 = new MeasuringUnit(@"KG/M3");
        public static readonly MeasuringUnit KKBQ_KM2 = new MeasuringUnit(@"KKBQ/KM2");
        public static readonly MeasuringUnit KKBQ_M2 = new MeasuringUnit(@"KKBQ/M2");
        public static readonly MeasuringUnit L = new MeasuringUnit(@"L");
        public static readonly MeasuringUnit L_M2 = new MeasuringUnit(@"L/M2");
        public static readonly MeasuringUnit M = new MeasuringUnit(@"M");
        public static readonly MeasuringUnit M2 = new MeasuringUnit(@"M2");
        public static readonly MeasuringUnit MBQ_GCA = new MeasuringUnit(@"MBQ/GCA");
        public static readonly MeasuringUnit MBQ_GK = new MeasuringUnit(@"MBQ/GK");
        public static readonly MeasuringUnit MBQ_KG = new MeasuringUnit(@"MBQ/KG");
        public static readonly MeasuringUnit MBQ_L = new MeasuringUnit(@"MBQ/L");
        public static readonly MeasuringUnit MBQ_M2 = new MeasuringUnit(@"MBQ/M2");
        public static readonly MeasuringUnit MBQ_M3 = new MeasuringUnit(@"MBQ/M3");
        public static readonly MeasuringUnit MG_KG = new MeasuringUnit(@"MG/KG");
        public static readonly MeasuringUnit MG_L = new MeasuringUnit(@"MG/L");
        public static readonly MeasuringUnit MM = new MeasuringUnit(@"MM");
        public static readonly MeasuringUnit MM_M2 = new MeasuringUnit(@"MM/M2");
        public static readonly MeasuringUnit NBQ_L = new MeasuringUnit(@"NBQ/L");
        public static readonly MeasuringUnit NBQ_M3 = new MeasuringUnit(@"NBQ/M3");
        public static readonly MeasuringUnit NCI_KG = new MeasuringUnit(@"NCI/KG");
        public static readonly MeasuringUnit NCI_M2 = new MeasuringUnit(@"NCI/M2");
        public static readonly MeasuringUnit NGY_H = new MeasuringUnit(@"NGY/H");
        public static readonly MeasuringUnit NSV_H = new MeasuringUnit(@"NSV/H");
        public static readonly MeasuringUnit PCI_CM2 = new MeasuringUnit(@"PCI/CM2");
        public static readonly MeasuringUnit PCI_G = new MeasuringUnit(@"PCI/G");
        public static readonly MeasuringUnit PCI_L = new MeasuringUnit(@"PCI/L");
        public static readonly MeasuringUnit PCI_M3 = new MeasuringUnit(@"PCI/M3");
        public static readonly MeasuringUnit PERCENT = new MeasuringUnit(@"PERCENT");
        public static readonly MeasuringUnit RATIO = new MeasuringUnit(@"RATIO");
        public static readonly MeasuringUnit UBQ_KG = new MeasuringUnit(@"UBQ/KG");
        public static readonly MeasuringUnit UBQ_M3 = new MeasuringUnit(@"UBQ/M3");
        public static readonly MeasuringUnit UR_H = new MeasuringUnit(@"UR/H");
        public static readonly MeasuringUnit USV_H = new MeasuringUnit(@"USV/H");



        private MeasuringUnit(string name)
        {
            this.name = name;
            instance[this.name] = this;
        }

        public static explicit operator MeasuringUnit(string str)
        {
            MeasuringUnit result;
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
