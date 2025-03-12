using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public abstract class KritaDialogBase : IAsyncDisposable
    {
        protected Client _client;
        protected string? _dialogConfigWidgetReference = null;

        public KritaDialogBase(Client client)
        {
            _client = client;
        }

        public abstract Task AttachDialog();
        
        public async Task Confirm()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _client.ConfirmFilter(_dialogConfigWidgetReference);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public async Task Cancel()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _client.CancelFilter(_dialogConfigWidgetReference);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        protected async Task ClickRadio(params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _client.ClickFilterWidget(_dialogConfigWidgetReference, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        protected async Task ClickPushButton(params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _client.ClickFilterWidget(_dialogConfigWidgetReference, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        protected async Task ClickCheckBox(params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _client.ClickFilterWidget(_dialogConfigWidgetReference, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        protected async Task<int> AdjustIntSpinBoxValue(int value, params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var returnValue = await _client.AdjustFilterIntSpinBoxValue(_dialogConfigWidgetReference, value, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.

            if (returnValue.Type != "int")
            {
                throw new Exception($"The method call didn't return a int ({returnValue.Type}");
            }

            return (int)(long)returnValue.Value;
        }

        protected async Task<float> AdjustFloatSpinBoxValue(float value, params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var returnValue = await _client.AdjustFilterFloatSpinBoxValue(_dialogConfigWidgetReference, value, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.

            if (returnValue.Type != "float")
            {
                throw new Exception($"The method call didn't return a float ({returnValue.Type}");
            }

            return (float)(double)returnValue.Value;
        }

        protected async Task<float> AdjustAngleSelectorValue(float value, params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var returnValue = await _client.SetFilterAngleSelectorValue(_dialogConfigWidgetReference, value, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.

            if (returnValue.Type != "float")
            {
                throw new Exception($"The method call didn't return a float ({returnValue.Type}");
            }

            return (float)(double)returnValue.Value;
        }

        protected async Task SetComboBoxSelectedIndex(int value, params string[] widgetPathNames)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _client.SetFilterComboBoxSelectedItem(_dialogConfigWidgetReference, value, widgetPathNames);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public async ValueTask DisposeAsync()
        {
            if (_dialogConfigWidgetReference != null && _client != null)
            {
                await _client.Delete(_dialogConfigWidgetReference);
            }
        }
    }
}
