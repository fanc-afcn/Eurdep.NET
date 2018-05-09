using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task WriteToStreamAsync(Stream targetStream)
        {
            using (var sw = new StreamWriter(targetStream))
            {
                await sw.WriteLineAsync(@"\BEGIN_EURDEP;");
                await sw.WriteLineAsync();

                await this.BuildHeaderSectionAsync(sw);
                await sw.WriteLineAsync();

                if (this.LocalityItemList.Any())
                {
                    await this.BuildLocalitySectionAsync(sw);
                    await sw.WriteLineAsync();
                }

                if (this.RadiologicalItemList.Any())
                {
                    await this.BuildRadiologicalSectionAsync(sw);
                    await sw.WriteLineAsync();
                }

                await sw.WriteLineAsync();
                await sw.WriteLineAsync(@"\END_EURDEP;");
            }
        }

        public static async Task<EurdepFile> ReadFromStream(Stream sourceStream)
        {
            return null;
        }

        #region Private Methods

        private async Task BuildHeaderSectionAsync(StreamWriter sw)
        {
            await sw.WriteLineAsync(@"\BEGIN_HEADER;");
            await this.BuildHeaderItemsAsync(sw);
            await sw.WriteLineAsync(@"\END_HEADER;");
        }

        private async Task BuildLocalitySectionAsync(StreamWriter sw)
        {
            await sw.WriteLineAsync(@"\BEGIN_LOCALITY;");
            await this.BuildItemListAsync(sw, this.LocalityItemList);
            await sw.WriteLineAsync(@"\END_LOCALITY;");
        }

        private async Task BuildRadiologicalSectionAsync(StreamWriter sw)
        {
            await sw.WriteLineAsync(@"\BEGIN_RADIOLOGICAL;");
            await this.BuildItemListAsync(sw, this.RadiologicalItemList);
            await sw.WriteLineAsync(@"\END_RADIOLOGICAL;");
        }

        private async Task BuildHeaderItemsAsync(StreamWriter sw)
        {
            if (this.Header != null)
            {
                var member = typeof(Header);
                var properties = member.GetProperties().Where(p => Attribute.IsDefined(p, typeof(EurdepFieldAttribute))).ToList();
                var mandatoryProperties =
                    properties.Where(
                        p =>
                            ((EurdepFieldAttribute)Attribute.GetCustomAttribute(p, typeof(EurdepFieldAttribute)))
                                .Mandatory).ToList();

                var propertiesContainingData = new List<PropertyInfo>();
                propertiesContainingData.AddRange(properties.Where(p => p.GetValue(this.Header) != null));

                var neededProperties = mandatoryProperties.Union(propertiesContainingData).ToList();

                foreach (var prop in neededProperties.OrderBy(p => ((EurdepFieldAttribute)Attribute.GetCustomAttribute(p, typeof(EurdepFieldAttribute))).Order))
                {
                    var eurdepFieldAttr = (EurdepFieldAttribute)Attribute.GetCustomAttribute(prop, typeof(EurdepFieldAttribute));
                    var value = prop.GetValue(this.Header);
                    await sw.WriteLineAsync(@"\" + eurdepFieldAttr.FieldName + " " + this.FormatObjectForDisplay(value) + ";");
                }
            }
        }

        private async Task BuildItemListAsync<T>(StreamWriter sw, IList<T> itemList)
        {
            await sw.WriteAsync(@"\FIELD_LIST ");

            var member = typeof(T);
            var properties = member.GetProperties().Where(p => Attribute.IsDefined(p, typeof(EurdepFieldAttribute))).ToList();
            var mandatoryProperties =
                properties.Where(
                    p =>
                        ((EurdepFieldAttribute)Attribute.GetCustomAttribute(p, typeof(EurdepFieldAttribute)))
                            .Mandatory).ToList();

            var propertiesContainingData = new List<PropertyInfo>();

            foreach (var item in itemList)
            {
                propertiesContainingData.AddRange(properties.Where(p => p.GetValue(item) != null));
            }

            propertiesContainingData = propertiesContainingData.Distinct().ToList();

            var neededProperties = mandatoryProperties.Union(propertiesContainingData).ToList();

            var sbTemp = new StringBuilder();
            foreach (var prop in neededProperties.OrderBy(p => ((EurdepFieldAttribute)Attribute.GetCustomAttribute(p, typeof(EurdepFieldAttribute))).Order))
            {
                var eurdepFieldAttr = (EurdepFieldAttribute)Attribute.GetCustomAttribute(prop, typeof(EurdepFieldAttribute));
                sbTemp.Append(eurdepFieldAttr.FieldName).Append(",");
            }
            sbTemp.Length--;
            sbTemp.AppendLine(";");

            await sw.WriteAsync(sbTemp.ToString());

            foreach (var item in itemList)
            {
                await sw.WriteAsync(@"\");

                sbTemp = new StringBuilder();
                foreach (var prop in neededProperties.OrderBy(p => ((EurdepFieldAttribute)Attribute.GetCustomAttribute(p, typeof(EurdepFieldAttribute))).Order))
                {
                    object value = prop.GetValue(item);
                    sbTemp.Append(this.FormatObjectForDisplay(value)).Append(",");
                }
                sbTemp.Length--;
                sbTemp.AppendLine(";");

                await sw.WriteAsync(sbTemp.ToString());
            }
        }

        private string FormatObjectForDisplay(object value)
        {
            if (value == null)
                return null;

            return value is DateTime dt ? dt.ToString("yyyy-MM-ddTHH:mm:ssZ") : value.ToString();
        }



        #endregion


    }
}
