using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelulasReligiosas.model;
using CelulasReligiosas.Pages;
using CelulasReligiosas.ViewModels;
using Xamarin.Forms;

namespace CelulasReligiosas
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainPageViewModel();
            BindingContext = _viewModel;
        }

        //private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    _viewModel.CelulaSelecionada = e.SelectedItem as Celula;
        //}

        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Navigation.PushAsync(new CelulaPage(mi.CommandParameter as Celula));
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Celula cel = mi.CommandParameter as Celula;
            DisplayAlert("Notificação",  "Deseja excluir Celula: "+ cel.Nome, "Excluir","Cancelar");
        }
    }
}
