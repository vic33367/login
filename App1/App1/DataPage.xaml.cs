using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {
        public ObservableCollection<Datos> Items { get; set; }
        public static MobileServiceClient cliente;
        public static IMobileServiceTable<Datos> Tabla;
        public static MobileServiceUser usuario;
        public DataPage()
        {
           
            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);          
            this.Title = "Inicio";
           
        }
        
        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            usuario = await App.Authenticator.Authenticate();
            if (App.Authenticator != null)
            {
                if (usuario != null)
                {
                    await DisplayAlert("Usuario Autenticado", usuario.UserId, "ok");
                    await Navigation.PushModalAsync(new DataPage1());
                }
                if (usuario == null)
                {
                }

            }
        }
    }
}

