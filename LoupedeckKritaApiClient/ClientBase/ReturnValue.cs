using System.Reflection.Metadata.Ecma335;

namespace LoupedeckKritaApiClient.ClientBase
{
    public class ReturnValue
    {
        public required string Type { get; set; }
        public required object Value { get; set; }
    }
}
