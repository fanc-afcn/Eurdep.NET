using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurdep.NET
{
    public static class Extensions
    {
        public static string ReadToString(this StreamReader sr, string splitString)
        {
            char nextChar;
            StringBuilder line = new StringBuilder();
            int matchIndex = 0;

            while (sr.Peek() > 0)
            {
                nextChar = (char)sr.Read();
                line.Append(nextChar);
                if (nextChar == splitString[matchIndex])
                {
                    if (matchIndex == splitString.Length - 1)
                    {
                        return line.ToString().Substring(0, line.Length - splitString.Length);
                    }
                    matchIndex++;
                }
                else
                {
                    matchIndex = 0;
                }
            }

            return line.Length == 0 ? null : line.ToString();
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }

        public static string CleanEurdepLine(this string s)
        {
            var result = s.Replace("\n", "").Replace("\t", " ");
            while (result.IndexOf("  ", StringComparison.Ordinal) > 0)
            {
                result = result.Replace("  ", " ");
            }

            result = result.TrimStart('\\');

            return result;
        }
    }
}
