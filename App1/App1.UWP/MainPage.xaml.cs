using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace App1.UWP
{
    public sealed partial class MainPage: ISQLAzure
    {
        private MobileServiceUser usuario;
        public async Task<MobileServiceUser> Authenticate()
        {
            try
            {
                usuario = await App1.DataPage.cliente.LoginAsync(MobileServiceAuthenticationProvider.Google, "tesh2.azurewebsites.net");
                if (usuario != null)
                {
                    await new MessageDialog(usuario.UserId, "Bienvenido").ShowAsync();
                }
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message, "Error message").ShowAsync();
            }
            return usuario;
        }
        public MainPage()
        {
            this.InitializeComponent();
            App1.App.Init((ISQLAzure)this);
            LoadApplication(new App1.App());
        }
    }
}
