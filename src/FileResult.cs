
namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a file downloaded from AvaTax
    /// </summary>
    public class FileResult
    {
        /// <summary>
        /// Raw bytes of the file
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Name of the file when downloaded as an attachment
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// MIME type of the file
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="r"></param>
        public FileResult(AvaTaxCallResult r)
        {
            Data = r.ResponseBytes;
            Filename = r.ResponseFileName;
            ContentType = r.ResponseContentType;
        }
    }
}
