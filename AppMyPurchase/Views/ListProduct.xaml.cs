namespace AppMyPurchase.Views;

public partial class ListProduct : ContentPage
{
	public ListProduct()
	{
		InitializeComponent();
	}

    #region ToolbarItem_Clicked
	/// <summary>
	/// /
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new NewProduct());
		}
		catch (Exception ex)
		{
			DisplayAlert("Erro", $"{ex.Message}, {ex.StackTrace}, {ex.HelpLink}", "Fechar");
		}
    }
    #endregion
}