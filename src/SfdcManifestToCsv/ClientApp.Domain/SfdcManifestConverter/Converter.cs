using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ClientApp.Domain.SfdcManifestConverter
{
    public class Converter : IConverter
    {
        public Package Convert(byte[] fileContents)
        {
            var serializer = new XmlSerializer(typeof(Package));
            using var reader = new MemoryStream(fileContents);
            
            // Call the Deserialize method to restore the object's state.
            var i = serializer.Deserialize(reader) as Package;
            return i;
            
        }
    

        public string BuildCsvFile(IEnumerable<Types> types)
        {
            var sb = new StringBuilder();
            sb.Append("Component name, Component type")
                .AppendLine()
                .AppendSequence(types,
                    (builder, types1) => builder.AppendSequence(types1.Members,
                        (stringBuilder, s) => stringBuilder
                            .AppendFormattedLine("{0},{1}", s, types1.Name)));

            return sb.ToString();
        }
    }
}