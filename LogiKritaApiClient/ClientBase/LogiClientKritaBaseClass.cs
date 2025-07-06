namespace LogiKritaApiClient.ClientBase
{
    public abstract class LogiClientKritaBaseClass: IAsyncDisposable
    {
        internal Client? Client { get; set; }
        internal string? Reference { get; set; }
        internal string? PrimitiveName { get; set; }

        public LogiClientKritaBaseClass() { }

        protected async Task Execute(string methodName, params object[] parameters)
        {
            ValidateInstance();

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await Client.ExecuteCall(Reference ?? PrimitiveName, methodName, parameters);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.
        }


        protected async Task<float> GetFloat(string methodName, params object[] parameters)
        {
            ValidateInstance();

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var returnValue = await Client.ExecuteCall(Reference ?? PrimitiveName, methodName, parameters);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.

            if (returnValue.Type != "float")
            {
                throw new Exception($"The method call didn't return a float ({returnValue.Type}");
            }

            return (float)(double)returnValue.Value;
        }

        protected async Task<int> GetInt(string methodName, params object[] parameters)
        {
            ValidateInstance();

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var returnValue = await Client.ExecuteCall(Reference ?? PrimitiveName, methodName, parameters);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.

            if (returnValue.Type != "int")
            {
                throw new Exception($"The method call didn't return a int ({returnValue.Type}");
            }

            return (int)(long)returnValue.Value;
        }

        protected async Task<string> GetStr(string methodName, params object[] parameters)
        {
            ValidateInstance();

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var returnValue = await Client.ExecuteCall(Reference ?? PrimitiveName, methodName, parameters);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.

            if (returnValue.Type != "str")
            {
                throw new Exception($"The method call didn't return a str ({returnValue.Type}");
            }

            return (string)returnValue.Value;
        }

        protected async Task<IEnumerable<string>> GetStringList(string methodName, params object[] parameters)
        {
            ValidateInstance();

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var returnValue = await Client.ExecuteCall(Reference ?? PrimitiveName, methodName, parameters);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.

            if (returnValue.Type != "list")
            {
                throw new Exception($"The method call didn't return a list ({returnValue.Type}");
            }

            return (IEnumerable<string>)returnValue.Value;
        }

        protected async Task<bool> GetBool(string methodName, params object[] parameters)
        {
            ValidateInstance();

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var returnValue = await Client.ExecuteCall(Reference ?? PrimitiveName, methodName, parameters);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.

            if (returnValue.Type != "bool")
            {
                throw new Exception($"The method call didn't return a int ({returnValue.Type}");
            }

            return (bool)returnValue.Value;
        }

        protected async Task<T> Get<T>(string methodName, params object[] parameters) where T : LogiClientKritaBaseClass, new()
        {
            ValidateInstance();

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var returnValue = await Client.ExecuteCall(Reference ?? PrimitiveName, methodName, parameters);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.

            if (returnValue.Type != typeof(T).Name)
            {
                throw new Exception($"The method call didn't return a {typeof(T).Name} ({returnValue.Type})");
            }

            return new T()
            {
                Reference = (string)returnValue.Value,
                Client = Client
            };
        }

        private void ValidateInstance()
        {
            if (Client == null)
            {
                throw new InvalidOperationException("Please add a client");
            }
            if ((Reference ?? PrimitiveName) == null)
            {
                throw new InvalidOperationException("Please configure an ObjectName");
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (Client != null && Reference != null)
            {
                await Client.Delete(Reference);
            }
        }
    }
}
