using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient.FiltersDialogs
{
    public abstract class FilterDialogBase : KritaDialogBase
    {
        internal bool IsModal { get; set; }  = false;
        public FilterDialogBase(Client client):base(client)
        {
        }

        internal abstract string ActionName { get; }

        public override async Task AttachDialog()
        {
            if (IsModal)
            {
                _dialogConfigWidgetReference = (string)(await _client.GetModalDialogConfigWidget("1", "3")).Value;
            }
            else
            {
                _dialogConfigWidgetReference = (string)(await _client.GetDialogConfigWidget("1", "-1", "0", "0", "1", "1")).Value;
            }
        }

        public async Task CreateMask()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            if (!IsModal)
            {
                await _client.ClickMainDialogButton(_dialogConfigWidgetReference, "pushButtonCreateMaskEffect");
            }
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public override async Task Confirm()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            if (IsModal)
            {
                await _client.ClickMainDialogButton(_dialogConfigWidgetReference, "0", "1");
            }
            else
            {
                await _client.ClickMainDialogButton(_dialogConfigWidgetReference, "buttonBox", "1");
            }
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public override async Task Cancel()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            if (IsModal)
            {
                await _client.ClickMainDialogButton(_dialogConfigWidgetReference, "0", "2");
            }
            else
            {
                await _client.ClickMainDialogButton(_dialogConfigWidgetReference, "buttonBox", "2");
            }
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
