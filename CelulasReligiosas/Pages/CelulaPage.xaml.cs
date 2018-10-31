using System;
using System.Collections.Generic;
using CelulasReligiosas.model;
using Xamarin.Forms;

namespace CelulasReligiosas.Pages
{
    public partial class CelulaPage : ContentPage
    {
        public CelulaPage(Celula celula)
        {
            InitializeComponent();
            lbCel.Text = celula.Nome;
        }
    }
}
