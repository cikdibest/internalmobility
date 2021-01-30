using IM.Web.Model;

namespace IM.CsvConverter
{
    public interface ICsvAssetReader
    {
        CsvAssetReaderReturnModel ReadCSVFile(ProcessCsvFileRequestModel requestModel);
    }
}
