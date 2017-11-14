using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPage : ContentPage
    {
        public SelectPage(object selectedItem)
        {
            var dato = selectedItem as Datos;
            BindingContext = dato;
            InitializeComponent();


        }
        private async void Button_Actualizar_Clicked_1(object sender, EventArgs e)
        {
            var datos = new Datos
            {
                Id = txtId.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellidos.Text,
                Direccion = txtDireecion.Text,
                Telefono = txtTelefono.Text,
                Carrera = txtCarrera.Text,
                Semestre = txtSemestre.Text,
                Correo = txtCorreo.Text,
                Github = txtGitHub.Text
            };
            await DataPage1.Tabla.UpdateAsync(datos);
            await Navigation.PushModalAsync(new DataPage1());
        }



        private async void Button_Eliminar_Clicked_1(object sender, EventArgs e)
        {
            var datos = new Datos
            {
                Id = txtId.Text
            };
            await DataPage1.Tabla.DeleteAsync(datos);
            await Navigation.PushModalAsync(new DataPage1());
        }

        private async void btnRestaurar_Clicked(object sender, EventArgs e)
        {
            var datos = new Datos
            {
                Id = txtId.Text,
            };
            await DataPage1.Tabla.UndeleteAsync(datos);
            await Navigation.PushModalAsync(new DataPage1());
        }
    }
}
