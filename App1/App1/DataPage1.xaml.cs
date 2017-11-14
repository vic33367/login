using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage1 : ContentPage
    {
        public ObservableCollection<Datos> Items { get; set; }
        public static MobileServiceClient cliente;
        public static IMobileServiceTable<Datos> Tabla;
        public static MobileServiceUser usuario;
        public DataPage1()
        {

            InitializeComponent();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = cliente.GetTable<Datos>();
            this.Title = "Inicio";
            LeerTabla();
        }
        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushModalAsync(new SelectPage(e.SelectedItem as Datos));
        }
        private async void LeerTabla()
        {
            IEnumerable<Datos> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<Datos>(elementos);
            BindingContext = this;
        }

        private void Button_Insertar_Clicked(object sender, EventArgs e)
        {

            Navigation.PushModalAsync(new InsertPage());
        }


        private async void LeerEliminados()
        {
            IEnumerable<Datos> elementos = await Tabla.IncludeDeleted().ToEnumerableAsync();
            Items = new ObservableCollection<Datos>(elementos);
            BindingContext = this;
            InitializeComponent();
        }

        private void btnEliminados_Clicked(object sender, EventArgs e)
        {
            LeerEliminados();
        }
    }
}
