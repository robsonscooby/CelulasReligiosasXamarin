using System;
using System.Collections.Generic;
using CelulasReligiosas.model;
using CelulasReligiosas.ViewModels;
using Xamarin.Forms;

namespace CelulasReligiosas.Pages
{
    public partial class CelulaPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;

        public CelulaPage()
        {
            InitializeComponent();
            _viewModel = new MainPageViewModel();
        }

        private void AdicionarCelula(object sender, ClickedEventArgs args)
        {
            Celula cel = new Celula();
            cel.Nome = txtNome.Text;
            cel.Endereco = txtEndereco.Text;
            cel.Descricao = txtDescricao.Text;
            _viewModel.AdicionarCelula2(cel);
        }
    }
}
