using Hotel.Models;

namespace Hotel.Viws;

public partial class ContratacaoHospedagem : ContentPage
{

    App PropriedadesApp;

    public Quarto QuartoSelecionado { get; private set; }
    public int QntAdultos { get; private set; }
    public int QntCriancas { get; private set; }
    public DateTime DataCheckin { get; private set; }
    public DateTime Datacheckout { get; private set; }

    public ContratacaoHospedagem()
	{
		InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Sobre()); // botão sobre
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_crianças.Value),
                DataCheckin = dtpck_checkin.Date,
                Datacheckout = dtpck_checkout.Date,
            };


            await Navigation.PushAsync(new HospedagemContratada() //botão avançar
            {
                BindingContext = h
            });

        } catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }

          
     }

     
private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
{
        // para não dar bug no check-in
        
            DatePicker elemento = sender as DatePicker;

            DateTime data_selecionada_checkin = elemento.Date;

            dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
            dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
        
}

private void Button_Clicked_2(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Fotos()); //botão fotos

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
    }
}


