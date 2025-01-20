using System.Net.Sockets;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace LoupedeckKritaApiClient.ClientBase
{
    public class Client : IDisposable
    {
        private Socket client;
        private KritaInstance _kritaInstance;
        private Canvas _currentCanvas;
        private Document _currentDocument;

        public Client()
        {
            _kritaInstance = new KritaInstance()
            {
                Client = this,
                ObjectName = "kritaInstance"
            };
            _currentCanvas = new Canvas()
            {
                Client = this,
                ObjectName = "currentCanvas"
            };
            _currentDocument = new Document()
            {
                Client = this,
                ObjectName = "currentDocument"
            };
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
                        string type;
                        object value;

                        switch (val.GetType().Name)
                        {
                            case "String":
                                {
                                    type = "str";
                                    value = $"\"{val.ToString()}\"";
                                }; break;
                            case "Int32":
                                {
                                    type = "int";
                                    value = $"{val.ToString()}";
                                }; break;
                            case "Single":
                                {
                                    type = "float";
                                    value = $"{val.ToString().Replace(',', '.')}";
                                }; break;
                            case "Boolean":
                                {
                                    type = "bool";
                                    value = $"{val.ToString().ToLower()}";
                                }; break;
                            default:
                                {
                                    if (typeof(LoupedeckClientKritaBaseClass).IsInstanceOfType(val))
                                    {
                                        type = val.GetType().Name;
                                        value = $"\"{((LoupedeckClientKritaBaseClass)val).ObjectName}\"";
                                    }
                                    else
                                        throw new ArgumentException($"Unmanaged argument type: {val.GetType().Name}");
                                }; break;
                        }

                        return $"{{\"type\":\"{type}\",\"value\":{value}}}";
                    })
                ) + "]";

            var messageBytes = Encoding.UTF8.GetBytes($"{{\"method\":\"{methodName}\",\"object\":\"{objectName}\",\"parameters\":{parametersListString}}}");
            _ = await client.SendAsync(messageBytes, SocketFlags.None);

            var responseBytes = new byte[1024];
            if (await client.ReceiveAsync(responseBytes, SocketFlags.None) > 0)
            {
                dynamic response = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(responseBytes));

                if (response.result == "OK")
                    if (response.returnType.Value == "list")
                        return new ReturnValue
                        {
                            Type = response.returnType.Value,
                            Value = ((JArray)response.returnValue).Select(node => node.Value<string>())
                        };
                    else
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

        public KritaInstance KritaInstance { get => _kritaInstance; }
        public Canvas CurrentCanvas { get => _currentCanvas; }
        public Document CurrentDocument { get => _currentDocument; }
    }
}
