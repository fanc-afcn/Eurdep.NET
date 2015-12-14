using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurdep.NET.Format.v2_1
{
    public enum ImportanceEnum
    {
        TEST = 1,
        NORMAL = 2,
        ROUTINE = 3,
        EMERGENCY = 4
    }

    public enum CarrierEnum
    {
        FTP = 1,
        EMAIL = 2,
        MIRROR = 3,
        HTTP = 4,
        FILE = 5
    }
}
