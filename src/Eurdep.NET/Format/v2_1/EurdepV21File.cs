using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Eurdep.NET.Format.v2_1
{
    public class EurdepV21File
    {
        public IList<Locality> LocalityList { get; set; } 

        public EurdepV21File()
        {
            this.LocalityList = new List<Locality>();
        }

        private void BuildLocalitySection()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"\BEGIN_LOCALITY;");
            sb.AppendLine(@"\FIELD_LIST LOCALITY_CODE,LOCALITY_NAME,LONGITUDE,LATITUDE,HEIGHT_ABOVE_SEA,HEIGHT_ABOVE_LAND;");

            foreach (var l in this.LocalityList)
            {
                sb.Append(l.LocalityCode).Append(",");
                sb.Append(l.LocalityName).Append(",");
                
            }

            sb.AppendLine(@"\END_LOCALITY;");
        }
    }
}
