using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio1_3
{
    public partial class MainPage : ContentPage
    {
        private int personId = 0;
        
        public MainPage()
        {
            InitializeComponent();            
        }


        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            string Id = lblId.Text;
            string Nombre = txbName.Text;
            string Apellido = txbLastName.Text;
            string Edad = txbAge.Text;
            string Correo = txbEmail.Text;
            string Direccion = txbAddress.Text;

            if (!string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Apellido) && !string.IsNullOrEmpty(Edad) && !string.IsNullOrEmpty(Correo) && !string.IsNullOrEmpty(Direccion))
            {
                personId = (Id == "") ? 0 : Convert.ToInt16(lblId.Text);
                var person = new PersonClass
                {
                    Id = personId,
                    Name = txbName.Text,
                    LastName = txbLastName.Text,
                    Age = Convert.ToInt16(txbAge.Text),
                    Email = txbEmail.Text,
                    Address = txbAddress.Text
                };               

                var result = await App.DBase.SavePerson(person);

                if (result > 0)
                {
                    if(personId == 0) await DisplayAlert("Aviso", "Persona Guardada", "OK");
                    else await DisplayAlert("Aviso", "Persona Actualizada", "OK");
                    Clear();
                }
                else
                {
                    await DisplayAlert("Aviso", "Ha ocurrido un error", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Debe completar toda la información", "OK");
                return;
            }
        }
        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            var person = new PersonClass
            {
                Id = personId,
                Name = txbName.Text,
                LastName = txbLastName.Text,
                Age = Convert.ToInt16(txbAge.Text),
                Email = txbEmail.Text,
                Address = txbAddress.Text
            };

            var result = await App.DBase.DeletePerson(person);
        }

        private async void btnPersonList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewDataPage());
        }     
        
        private void Clear()
        {
            txbName.Text = "";
            txbLastName.Text = "";
            txbEmail.Text = "";
            txbAge.Text = "";
            txbAddress.Text = "";
            lblId.Text = "";
        }
        
    }
}
