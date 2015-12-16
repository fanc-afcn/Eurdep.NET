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
        public Header Header { get; set; }
        public IList<LocalityItem> LocalityItemList { get; set; }
        public IList<RadiologicalItem> RadiologicalItemList { get; set; } 

        public EurdepFile()
        {
            this.LocalityItemList = new List<LocalityItem>();
            this.RadiologicalItemList = new List<RadiologicalItem>();
        }

        public StringBuilder BuildFile()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"\BEGIN_EURDEP;");
            sb.AppendLine();

            sb.Append(this.BuildHeaderSection());
            sb.AppendLine();

            if (this.LocalityItemList.Any())
            {
                sb.Append(this.BuildLocalitySection());
                sb.AppendLine();
            }

            if (this.RadiologicalItemList.Any())
            {
                sb.Append(this.BuildRadiologicalSection());
                sb.AppendLine();
            }
            
            sb.AppendLine(@"\END_EURDEP;");

            return sb;
        }

        private StringBuilder BuildHeaderSection()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"\BEGIN_HEADER;");
            sb.Append(this.BuildHeaderItems());
            sb.AppendLine(@"\END_HEADER;");

            return sb;
        }

        private StringBuilder BuildLocalitySection()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"\BEGIN_LOCALITY;");
            sb.Append(this.BuildItemList(this.LocalityItemList));
            sb.AppendLine(@"\END_LOCALITY;");

            return sb;
        }

        private StringBuilder BuildRadiologicalSection()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"\BEGIN_RADIOLOGICAL;");
            sb.Append(this.BuildItemList(this.RadiologicalItemList));
            sb.AppendLine(@"\END_RADIOLOGICAL;");

            return sb;
        }

        private StringBuilder BuildHeaderItems()
        {
            StringBuilder sb = new StringBuilder();

            if (this.Header != null)
            {
                var member = typeof(Header);
                var properties = member.GetProperties().Where(p => Attribute.IsDefined(p, typeof(EurdepFieldAttribute)));
                List<PropertyInfo> mandatoryProperties =
                    properties.Where(
                        p =>
                            ((EurdepFieldAttribute)Attribute.GetCustomAttribute(p, typeof(EurdepFieldAttribute)))
                                .Mandatory).ToList();

                List<PropertyInfo> propertiesContainingData = new List<PropertyInfo>();
                propertiesContainingData.AddRange(properties.Where(p => p.GetValue(this.Header) != null));

                List<PropertyInfo> neededProperties = mandatoryProperties.Union(propertiesContainingData).ToList();

                foreach (var prop in neededProperties.OrderBy(p => ((EurdepFieldAttribute)Attribute.GetCustomAttribute(p, typeof(EurdepFieldAttribute))).Order))
                {
                    var eurdepFieldAttr = (EurdepFieldAttribute)Attribute.GetCustomAttribute(prop, typeof(EurdepFieldAttribute));
                    object value = prop.GetValue(this.Header);
                    sb.AppendLine(@"\" + eurdepFieldAttr.FieldName + " " + this.FormatObjectForDisplay(value) + ";");
                }
            }

            return sb;
        }

        private StringBuilder BuildItemList<T>(IList<T> itemList)
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
                    object value = prop.GetValue(item);
                    sb.Append(this.FormatObjectForDisplay(value)).Append(",");
                }
                sb.Length--;
                sb.AppendLine(";");
            }
            return sb;
        }

        private string FormatObjectForDisplay(object value)
        {
            if (value == null)
                return null;

            if (value is DateTime)
                return ((DateTime)value).ToString("yyyy-MM-ddTHH:mm:ssZ");

            return value.ToString();
        }
    }
}
