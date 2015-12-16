using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eurdep.NET.Format.v2_1.Enums;

namespace Eurdep.NET.Format.v2_1
{
    public class Header
    {
        [EurdepField("COUNTRY_CODE", false, 1)]
        public string CountryCode { get; set; }

        [EurdepField("IMPORTANCE", true, 2)]
        public Importance Importance { get; set; }

        [EurdepField("SOFTWARE_VERSION", false, 3)]
        public string SoftwareVersion { get; set; }

        [EurdepField("ORIGINATOR", true, 4)]
        public string Originator { get; set; }

        [EurdepField("CARRIER", false, 5)]
        public Carrier Carrier { get; set; }

        [EurdepField("SENT", true, 6)]
        public DateTime SentUTC { get; set; }

        [EurdepField("FORMAT_VERSION", false, 7)]
        public string FormatVersion { get; set; }

        [EurdepField("MESSAGE_ID", true, 8)]
        public string MessageId { get; set; }

        [EurdepField("FILENAME", false, 9)]
        public string FileName { get; set; }

        public Header()
        {
            this.SentUTC = DateTime.UtcNow;
        }
    }
}
