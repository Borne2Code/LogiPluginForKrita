using System.Reflection.Metadata.Ecma335;

namespace LogiKritaApiClient.ClientBase
{
    public class ReturnValue
    {
        public required string Type { get; set; }
        public required object Value { get; set; }
    }
}
