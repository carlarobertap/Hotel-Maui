namespace Hotel.Viws;

public partial class ContratacaoHospedagem : ContentPage
{

    App PropriedadesApp;

	public ContratacaoHospedagem()
	{
		InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.Lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Sobre()); // botão sobre
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new HospedagemContratada()); //botão avançar

        } catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }

          
     }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e) // para não dar bug no check-in
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date;

        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddDays(1);
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


