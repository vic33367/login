using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertPage : ContentPage
    {
        public InsertPage()
        {
            InitializeComponent();
        }

        private async void btnObtener_Clicked(object sender, EventArgs e)
        {
            var datos = new Datos
            {

                Nombre = txtNombre.Text,
                Apellido = txtApellidos.Text,
                Direccion = txtDireecion.Text,
                Telefono = txtTelefono.Text,
                Carrera = txtCarrera.Text,
                Semestre = txtSemestre.Text,
                Correo = txtCorreo.Text,
                Github = txtGitHub.Text
            };
            await DataPage1.Tabla.InsertAsync(datos);
            await Navigation.PushModalAsync(new DataPage1());

        }
    }
}