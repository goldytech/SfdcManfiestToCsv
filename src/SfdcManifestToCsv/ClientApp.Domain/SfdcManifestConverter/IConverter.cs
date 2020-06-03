using System.Collections.Generic;

namespace ClientApp.Domain.SfdcManifestConverter
{
    public interface IConverter
    {
        Package Convert(byte[] fileContents);
        string BuildCsvFile(IEnumerable<Types> types);
    }
}