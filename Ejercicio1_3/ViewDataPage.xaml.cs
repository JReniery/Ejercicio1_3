using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewDataPage : ContentPage
    {
        public ViewDataPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            fillCollectionView();
        }

        private async void fillCollectionView()
        {
            clvPersonas.ItemsSource = await App.DBase.GetPersonList();
        }

        private async void swpDelete_Invoked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmar", "Deliminar este elemento?", "Sí", "No"))
            {
                var person = (PersonClass)(sender as SwipeItemView).CommandParameter;
                var result = await App.DBase.DeletePerson(person);

                if (result == 1)
                {
                    fillCollectionView();
                    await DisplayAlert("Aviso", "Dato Eliminado", "OK");                    
                }
                else
                {
                    await DisplayAlert("Aviso", "Ha ocurrido un error", "OK");
                }
            }
        }

        private async void swpUpdate_Invoked(object sender, EventArgs e)
        {
            var person = (PersonClass)(sender as SwipeItemView).CommandParameter;

            MainPage page = new MainPage();
            page.BindingContext = person;            
            await Navigation.PushAsync(page);                 
        }

    }
}