using System.Net.Sockets;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace LoupedeckKritaApiClient.ClientBase
{
    public class Client : IDisposable
    {
        private Socket client;
        private CurrentCanvas _currentCanvas;
        private CurrentDocument _currentDocument;

        public Client()
        {
            _currentCanvas = new CurrentCanvas(this);
            _currentDocument = new CurrentDocument(this);
        }

        public async Task Connect()
        {
            var hostName = Dns.GetHostName();
            IPHostEntry localhost = await Dns.GetHostEntryAsync(hostName);
            IPAddress localIpAddress = localhost.AddressList[0];
            IPEndPoint ipEndPoint = new(IPAddress.Parse("127.0.0.1"), 1247);

            client = new(
                ipEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);
            await client.ConnectAsync(ipEndPoint);
        }

        internal async Task<ReturnValue> ExecuteCall(string objectName, string methodName, params object[] parameters)
        {
            var parametersListString = "[" + string.Join(',', parameters
                .Select((val) =>
                    {
                        var type = val.GetType().Name switch
                        {
                            "String" => "str",
                            "Int32" => "int",
                            "Single" => "float",
                            _ => "Unknown"
                        };
                        var value = val.GetType().Name switch
                        {
                            "String" => $"\"{val.ToString()}\"",
                            _ => $"{val.ToString().Replace(',', '.')}"
                        };
                        return $"{{\"type\": \"{type}\",\"value\":{value}}}";
                    })
                ) + "]";

            var messageBytes = Encoding.UTF8.GetBytes($"{{\"method\":\"{methodName}\",\"object\":\"{objectName}\",\"parameters\":{parametersListString}}}");
            _ = await client.SendAsync(messageBytes, SocketFlags.None);

            var responseBytes = new byte[1024];
            if (await client.ReceiveAsync(responseBytes, SocketFlags.None) > 0)
            {
                dynamic response = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(responseBytes));

                if (response.result == "OK")
                    return new ReturnValue
                    {
                        Type = response.returnType.Value,
                        Value = response.returnValue.Value
                    };
                else
                    throw new Exception((string)response.error);
            }

            throw new Exception("Could not get a return");
        }

        public void Dispose()
        {
            if (client.Connected)
            {
                client.Close();
            }
            client.Dispose();
        }

        public CurrentCanvas CurrentCanvas { get => _currentCanvas; }
        public CurrentDocument CurrentDocument { get => _currentDocument; }
    }
}
