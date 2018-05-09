using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
        private FileSection? section;
        private Dictionary<FileSection, List<string>> sectionFieldList;
        private Dictionary<FileSection, Dictionary<string, string>> sectionDefaults;

        private bool inDefaultSubsection = false;

        public Header Header { get; set; }
        public IList<LocalityItem> LocalityItemList { get; set; }
        public IList<RadiologicalItem> RadiologicalItemList { get; set; } 

        public EurdepFile()
        {
            this.Header = new Header();
            this.LocalityItemList = new List<LocalityItem>();
            this.RadiologicalItemList = new List<RadiologicalItem>();

            this.sectionFieldList = new Dictionary<FileSection, List<string>>();
            this.sectionDefaults = new Dictionary<FileSection, Dictionary<string, string>>();
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
            var target = new EurdepFile();

            using (var sr = new StreamReader(sourceStream))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadToString(";");
                    ParseLine(line, target);
                }
            }

            return target;
        }

        #region Private Writing Methods

        private async Task BuildHeaderSectionAsync(StreamWriter sw)
        {
            await sw.WriteLineAsync(@"\BEGIN_HEADER;");
            await this.BuildHeaderItemsAsync(sw);
            await sw.WriteLineAsync(@"\END_HEADER;");
        }

        private async Task BuildLocalitySectionAsync(StreamWriter sw)
        {
            await sw.WriteLineAsync(@"\BEGIN_LOCALITY;");
            await this.BuildItemListAsync(this.LocalityItemList, sw);
            await sw.WriteLineAsync(@"\END_LOCALITY;");
        }

        private async Task BuildRadiologicalSectionAsync(StreamWriter sw)
        {
            await sw.WriteLineAsync(@"\BEGIN_RADIOLOGICAL;");
            await this.BuildItemListAsync(this.RadiologicalItemList, sw);
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

        private async Task BuildItemListAsync<T>(IList<T> itemList, StreamWriter sw)
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

        #region Private Reading Methods

        private static void ParseLine(string line, EurdepFile target)
        {
            line = line.CleanEurdepLine();
            bool detailedParsingNeeded = false;

            //determine section
            if (line.StartsWith(@"BEGIN_HEADER", StringComparison.OrdinalIgnoreCase))
            {
                target.section = FileSection.Header;
            }
            else if (line.StartsWith(@"BEGIN_LOCALITY", StringComparison.OrdinalIgnoreCase))
            {
                target.section = FileSection.Locality;
            }
            else if (line.StartsWith(@"BEGIN_RADIOLOGICAL", StringComparison.OrdinalIgnoreCase))
            {
                target.section = FileSection.Radiological;
            }
            else if (line.StartsWith(@"END_HEADER", StringComparison.OrdinalIgnoreCase) ||
                     line.StartsWith(@"END_LOCALITY", StringComparison.OrdinalIgnoreCase) ||
                     line.StartsWith(@"END_RADIOLOGICAL", StringComparison.OrdinalIgnoreCase))
            {
                target.section = null;
            }
            else if (line.StartsWith(@"BEGIN_DEFAULT", StringComparison.OrdinalIgnoreCase))
            {
                target.inDefaultSubsection = true;
            }
            else if (line.StartsWith(@"END_DEFAULT", StringComparison.OrdinalIgnoreCase))
            {
                target.inDefaultSubsection = false;
            }
            else
                detailedParsingNeeded = true;
            

            //call the section parser accordingly
            if (detailedParsingNeeded)
            {
                if(target.section == FileSection.Header)
                    ParseHeaderLine(line, target);
                else if (target.section == FileSection.Locality || target.section == FileSection.Radiological)
                {
                    ParseItemListLine(line, target, target.section.Value);
                }
                    
            }
        }

        private static void ParseHeaderLine(string line, EurdepFile target)
        {
            if(!string.IsNullOrWhiteSpace(line))
            {
                var lineItems = line.Split(' ');
                var eurdepFieldName = lineItems.FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(eurdepFieldName) && lineItems.Length > 1)
                {
                    string value = "";
                    for (int i = 1; i < lineItems.Length; i++)
                        value = value + " " + lineItems[i];

                    value = value.Trim();

                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        SetEurdepFieldValue(target.Header, eurdepFieldName, value);
                    }
                }
            }
        }

        private static void ParseItemListLine(string line, EurdepFile target, FileSection section)
        {
            if(!string.IsNullOrWhiteSpace(line))
            {
                if (line.StartsWith(@"FIELD_LIST", StringComparison.OrdinalIgnoreCase)) //field list
                {
                    var fieldsStr = line.Replace(@"FIELD_LIST", "").Trim();
                    var fieldList = fieldsStr.Split(',').Select(x => x.Trim()).ToList();

                    target.sectionFieldList.Add(section, fieldList);
                }
                else if(!target.inDefaultSubsection) //item record
                {
                    var valuesList = line.Split(',').Select(x => x.Trim()).ToList();

                    if (section == FileSection.Locality)
                    {
                        var item = new LocalityItem();
                        int arrayPosition = 0;
                        foreach (var value in valuesList)
                        {
                            var eurdepFieldName = target.sectionFieldList[section][arrayPosition];

                            if (section == FileSection.Locality)
                            {
                                SetEurdepFieldValue(item, eurdepFieldName, value);
                            }

                            arrayPosition++;
                        }

                        target.LocalityItemList.Add(item);
                    } 
                }
            }
        }

        private static void SetEurdepFieldValue<T>(T target, string eurdepFieldName, string value)
        {
            try
            {
                var type = target.GetType();
                var prop = type.GetProperties().FirstOrDefault(p =>
                    Attribute.IsDefined(p, typeof(EurdepFieldAttribute)) &&
                    ((EurdepFieldAttribute)Attribute.GetCustomAttribute(p, typeof(EurdepFieldAttribute))).FieldName.Equals(
                        eurdepFieldName, StringComparison.OrdinalIgnoreCase));

                if (prop != null)
                {
                    prop.SetValue(target, value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }



        #endregion


    }
}
