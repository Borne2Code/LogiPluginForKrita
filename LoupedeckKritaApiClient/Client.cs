using System.Net.Sockets;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace LoupedeckKritaApiClient
{
    public class Client: IDisposable
    {
        private Socket client;

        public Client() 
        {
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

        public async Task<object> ExecuteCall(string objectName, string methodName, params object[] parameters)
        {
            var parametersListString = "[" + string.Join(',', parameters
                .Select<object, string>((val) =>
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
                            _ => $"{val.ToString().Replace(',','.')}"
                        };
                        return $"{{\"type\": \"{type}\",\"value\":{value}}}";
                    })
                ) + "]";

            var messageBytes = Encoding.UTF8.GetBytes($"{{\"context\":null,\"method\":\"{methodName}\",\"object\":\"{objectName}\",\"parameters\":{parametersListString}}}");
            _ = await client.SendAsync(messageBytes, SocketFlags.None);

            var responseBytes = new byte[1024];
            if (await client.ReceiveAsync(responseBytes, SocketFlags.None) > 0)
            {
                dynamic response = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(responseBytes));

                if (response.result == "OK")
                    return response.returnValue.Value;
                else
                    throw new Exception((string)response.error);
            }

            return null;
        }

        public void Dispose()
        {
            if (client.Connected)
            {
                client.Close();
            }
            client.Dispose();
        }
    }
}
