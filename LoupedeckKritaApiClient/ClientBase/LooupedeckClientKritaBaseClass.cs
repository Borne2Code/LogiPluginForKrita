namespace LoupedeckKritaApiClient.ClientBase
{
    public class LooupedeckClientKritaBaseClass(Client client, string objectName)
    {
        private Client Client = client;
        private string ObjectName = objectName;

        public async Task Execute(string methodName, params object[] parameters)
        {
            await Client.ExecuteCall(ObjectName, methodName, parameters);
        }

        public async Task<float> GetFloat(string methodName, params object[] parameters)
        {
            var returnValue = await Client.ExecuteCall(ObjectName, methodName, parameters);

            if (returnValue.Type != "float")
            {
                throw new Exception($"The method call didn't return a float ({returnValue.Type}");
            }

            return (float)(double)returnValue.Value;
        }

        public async Task<int> GetInt(string methodName, params object[] parameters)
        {
            var returnValue = await Client.ExecuteCall(ObjectName, methodName, parameters);

            if (returnValue.Type != "int")
            {
                throw new Exception($"The method call didn't return a int ({returnValue.Type}");
            }

            return (int)(long)returnValue.Value;
        }

        public async Task<string> GetStr(string methodName, params object[] parameters)
        {
            var returnValue = await Client.ExecuteCall(ObjectName, methodName, parameters);

            if (returnValue.Type != "str")
            {
                throw new Exception($"The method call didn't return a str ({returnValue.Type}");
            }

            return (string)returnValue.Value;
        }
    }
}
