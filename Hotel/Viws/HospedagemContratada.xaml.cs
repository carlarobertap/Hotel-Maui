namespace Hotel.Viws;

public partial class HospedagemContratada : ContentPage
{
	public HospedagemContratada()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PopAsync(); //botão voltar

		}catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "Ok");
		}
    }
}