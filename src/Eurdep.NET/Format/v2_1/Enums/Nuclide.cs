using System;
using System.Collections.Generic;

namespace Eurdep.NET.Format.v2_1.Enums
{
    public sealed class Nuclide
    {
        private readonly string name;

        private static readonly Dictionary<string, Nuclide> instance = new Dictionary<string, Nuclide>();

        public static readonly Nuclide BA_LA140 = new Nuclide(@"(BA+LA)140");
        public static readonly Nuclide NB_ZR95 = new Nuclide(@"(NB+ZR)95");
        public static readonly Nuclide RU_RH106 = new Nuclide(@"(RU+RH)106");
        public static readonly Nuclide TE_I132 = new Nuclide(@"(TE+I)132");
        public static readonly Nuclide AC_228 = new Nuclide(@"AC-228");
        public static readonly Nuclide AG_110 = new Nuclide(@"AG-110");
        public static readonly Nuclide AG_110M = new Nuclide(@"AG-110M");
        public static readonly Nuclide AM_241 = new Nuclide(@"AM-241");
        public static readonly Nuclide AS_76 = new Nuclide(@"AS-76");
        public static readonly Nuclide BA_140 = new Nuclide(@"BA-140");
        public static readonly Nuclide BE_7 = new Nuclide(@"BE-7");
        public static readonly Nuclide BI_212 = new Nuclide(@"BI-212");
        public static readonly Nuclide BI_214 = new Nuclide(@"BI-214");
        public static readonly Nuclide C_14 = new Nuclide(@"C-14");
        public static readonly Nuclide CA = new Nuclide(@"CA");
        public static readonly Nuclide CD_109 = new Nuclide(@"CD-109");
        public static readonly Nuclide CE_141 = new Nuclide(@"CE-141");
        public static readonly Nuclide CE_142 = new Nuclide(@"CE-142");
        public static readonly Nuclide CE_144 = new Nuclide(@"CE-144");
        public static readonly Nuclide CM_242 = new Nuclide(@"CM-242");
        public static readonly Nuclide CM_244 = new Nuclide(@"CM-244");
        public static readonly Nuclide CO_57 = new Nuclide(@"CO-57");
        public static readonly Nuclide CO_58 = new Nuclide(@"CO-58");
        public static readonly Nuclide CO_60 = new Nuclide(@"CO-60");
        public static readonly Nuclide COSMIC = new Nuclide(@"COSMIC");
        public static readonly Nuclide CR_51 = new Nuclide(@"CR-51");
        public static readonly Nuclide CS134_137 = new Nuclide(@"CS(134+137)");
        public static readonly Nuclide CS134_137_ratio = new Nuclide(@"CS(134/137)");
        public static readonly Nuclide CS_131 = new Nuclide(@"CS-131");
        public static readonly Nuclide CS_132 = new Nuclide(@"CS-132");
        public static readonly Nuclide CS_134 = new Nuclide(@"CS-134");
        public static readonly Nuclide CS_136 = new Nuclide(@"CS-136");
        public static readonly Nuclide CS_137 = new Nuclide(@"CS-137");
        public static readonly Nuclide DEBIT = new Nuclide(@"DEBIT");
        public static readonly Nuclide EU_152 = new Nuclide(@"EU-152");
        public static readonly Nuclide EU_154 = new Nuclide(@"EU-154");
        public static readonly Nuclide EU_155 = new Nuclide(@"EU-155");
        public static readonly Nuclide EXT_RAD = new Nuclide(@"EXT-RAD");
        public static readonly Nuclide FE_59 = new Nuclide(@"FE-59");
        public static readonly Nuclide H_3 = new Nuclide(@"H-3");
        public static readonly Nuclide HG_203 = new Nuclide(@"HG-203");
        public static readonly Nuclide I_131 = new Nuclide(@"I-131");
        public static readonly Nuclide I_131G = new Nuclide(@"I-131(G)");
        public static readonly Nuclide I_131P = new Nuclide(@"I-131(P)");
        public static readonly Nuclide I_131P_G = new Nuclide(@"I-131(P+G)");
        public static readonly Nuclide I_132 = new Nuclide(@"I-132");
        public static readonly Nuclide I_133 = new Nuclide(@"I-133");
        public static readonly Nuclide K_40 = new Nuclide(@"K-40");
        public static readonly Nuclide LA_140 = new Nuclide(@"LA-140");
        public static readonly Nuclide MN_54 = new Nuclide(@"MN-54");
        public static readonly Nuclide MO_99 = new Nuclide(@"MO-99");
        public static readonly Nuclide MO99_TC99M = new Nuclide(@"MO99+TC99M");
        public static readonly Nuclide NA_22 = new Nuclide(@"NA-22");
        public static readonly Nuclide NB_95 = new Nuclide(@"NB-95");
        public static readonly Nuclide NB_97 = new Nuclide(@"NB-97");
        public static readonly Nuclide ND_147 = new Nuclide(@"ND-147");
        public static readonly Nuclide NP_237 = new Nuclide(@"NP-237");
        public static readonly Nuclide NP_239 = new Nuclide(@"NP-239");
        public static readonly Nuclide PB_210 = new Nuclide(@"PB-210");
        public static readonly Nuclide PB_212 = new Nuclide(@"PB-212");
        public static readonly Nuclide PB_214 = new Nuclide(@"PB-214");
        public static readonly Nuclide PO_210 = new Nuclide(@"PO-210");
        public static readonly Nuclide PR_144 = new Nuclide(@"PR-144");
        public static readonly Nuclide PU239_240 = new Nuclide(@"PU(239+240)");
        public static readonly Nuclide PU_238 = new Nuclide(@"PU-238");
        public static readonly Nuclide PU_239 = new Nuclide(@"PU-239");
        public static readonly Nuclide PU_240 = new Nuclide(@"PU-240");
        public static readonly Nuclide PU238_AM24 = new Nuclide(@"PU238+AM24");
        public static readonly Nuclide PU238_AM241 = new Nuclide(@"PU238+AM241");
        public static readonly Nuclide R_BETA = new Nuclide(@"R-BETA");
        public static readonly Nuclide RA_226 = new Nuclide(@"RA-226");
        public static readonly Nuclide RH_106 = new Nuclide(@"RH-106");
        public static readonly Nuclide RU_103 = new Nuclide(@"RU-103");
        public static readonly Nuclide RU_104 = new Nuclide(@"RU-104");
        public static readonly Nuclide RU_106 = new Nuclide(@"RU-106");
        public static readonly Nuclide SB_124 = new Nuclide(@"SB-124");
        public static readonly Nuclide SB_125 = new Nuclide(@"SB-125");
        public static readonly Nuclide SB_127 = new Nuclide(@"SB-127");
        public static readonly Nuclide SE_75 = new Nuclide(@"SE-75");
        public static readonly Nuclide SR89_90 = new Nuclide(@"SR(89+90)");
        public static readonly Nuclide SR89_90_ratio = new Nuclide(@"SR(89/90)");
        public static readonly Nuclide SR_RARE = new Nuclide(@"SR+RARE");
        public static readonly Nuclide SR_85 = new Nuclide(@"SR-85");
        public static readonly Nuclide SR_89 = new Nuclide(@"SR-89");
        public static readonly Nuclide SR_90 = new Nuclide(@"SR-90");
        public static readonly Nuclide T_ALFA = new Nuclide(@"T-ALFA");
        public static readonly Nuclide T_BETA = new Nuclide(@"T-BETA");
        public static readonly Nuclide T_CA = new Nuclide(@"T-CA");
        public static readonly Nuclide T_GAMMA = new Nuclide(@"T-GAMMA");
        public static readonly Nuclide T_K = new Nuclide(@"T-K");
        public static readonly Nuclide T_NA = new Nuclide(@"T-NA");
        public static readonly Nuclide T_U = new Nuclide(@"T-U");
        public static readonly Nuclide TC_99 = new Nuclide(@"TC-99");
        public static readonly Nuclide TC_99M = new Nuclide(@"TC-99M");
        public static readonly Nuclide TE_129 = new Nuclide(@"TE-129");
        public static readonly Nuclide TE_129M = new Nuclide(@"TE-129M");
        public static readonly Nuclide TE_131 = new Nuclide(@"TE-131");
        public static readonly Nuclide TE_131M = new Nuclide(@"TE-131M");
        public static readonly Nuclide TE_132 = new Nuclide(@"TE-132");
        public static readonly Nuclide TH = new Nuclide(@"TH");
        public static readonly Nuclide TH_232 = new Nuclide(@"TH-232");
        public static readonly Nuclide TH_234 = new Nuclide(@"TH-234");
        public static readonly Nuclide U_234 = new Nuclide(@"U-234");
        public static readonly Nuclide U_238 = new Nuclide(@"U-238");
        public static readonly Nuclide U_RA = new Nuclide(@"U-RA");
        public static readonly Nuclide XE_131M = new Nuclide(@"XE-131M");
        public static readonly Nuclide XE_133 = new Nuclide(@"XE-133");
        public static readonly Nuclide XE_135 = new Nuclide(@"XE-135");
        public static readonly Nuclide Y_90 = new Nuclide(@"Y-90");
        public static readonly Nuclide Y_91 = new Nuclide(@"Y-91");
        public static readonly Nuclide ZN_65 = new Nuclide(@"ZN-65");
        public static readonly Nuclide ZR_95 = new Nuclide(@"ZR-95");
        public static readonly Nuclide ZR_97 = new Nuclide(@"ZR-97");



        private Nuclide(string name)
        {
            this.name = name;
            instance[this.name] = this;
        }

        public static explicit operator Nuclide(string str)
        {
            Nuclide result;
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
