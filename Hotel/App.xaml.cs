﻿using Hotel.Models;

namespace Hotel
{
    public partial class App : Application
    {
        public List<Quarto> lista_quartos = new List<Quarto>
        {

            new Quarto()
            {
                Descricao = "Suíte Super Luxo",
                ValorDiariaAdulto = 110,
                ValorDiariaCrianca = 55

            },
            new Quarto()
            {
                 Descricao = "Suíte Luxo",
                ValorDiariaAdulto = 80,
                ValorDiariaCrianca = 40
             },
            new Quarto()
            {

                Descricao = "Suíte Single",
                ValorDiariaAdulto = 50,
                ValorDiariaCrianca = 25
            },
            new Quarto()
            {

                Descricao = "Suíte Crise",
                ValorDiariaAdulto = 25,
                ValorDiariaCrianca = 12.5
            }

        };
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Viws.ContratacaoHospedagem());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 600;

            return window;

        }
    }
}
