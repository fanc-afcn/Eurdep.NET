using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Eurdep.NET.Format.v2_1
{
    /// <summary>
    /// Represents a EURDEP v2.1 file and a the actions that can be performed with it
    /// </summary>
    public class EurdepFile
    {
        public IList<Locality> LocalityList { get; set; } 

        public EurdepFile()
        {
            this.LocalityList = new List<Locality>();
        }

        public void BuildFile()
        {
            this.BuildLocalitySection();
        }

        private void BuildLocalitySection()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"\BEGIN_LOCALITY;");
            sb.Append(this.BuildItemList(this.LocalityList));
            sb.AppendLine(@"\END_LOCALITY;");

            string s = sb.ToString();
        }

        private string BuildItemList<T>(IList<T> itemList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"\FIELD_LIST ");

            var member = typeof(T);
            var properties = member.GetProperties().Where(p => Attribute.IsDefined(p, typeof(EurdepFieldAttribute)));
            List<PropertyInfo> mandatoryProperties =
                properties.Where(
                    p =>
                        ((EurdepFieldAttribute)Attribute.GetCustomAttribute(p, typeof(EurdepFieldAttribute)))
                            .Mandatory).ToList();

            List<PropertyInfo> propertiesContainingData = new List<PropertyInfo>();

            foreach (var item in itemList)
            {
                propertiesContainingData.AddRange(properties.Where(p => p.GetValue(item) != null));
            }

            propertiesContainingData = propertiesContainingData.Distinct().ToList();

            List<PropertyInfo> neededProperties = mandatoryProperties.Union(propertiesContainingData).ToList();

            foreach (var prop in neededProperties.OrderBy(p => ((EurdepFieldAttribute)Attribute.GetCustomAttribute(p, typeof(EurdepFieldAttribute))).Order))
            {
                var eurdepFieldAttr = (EurdepFieldAttribute)Attribute.GetCustomAttribute(prop, typeof(EurdepFieldAttribute));
                sb.Append(eurdepFieldAttr.FieldName).Append(",");
            }
            sb.Length--;
            sb.AppendLine(";");

            foreach (var item in itemList)
            {
                sb.Append(@"\");
                foreach (var prop in neededProperties.OrderBy(p => ((EurdepFieldAttribute)Attribute.GetCustomAttribute(p, typeof(EurdepFieldAttribute))).Order))
                {
                    sb.Append(prop.GetValue(item)).Append(",");
                }
                sb.Length--;
                sb.AppendLine(";");
            }
            return sb.ToString();
        }
    }
}
