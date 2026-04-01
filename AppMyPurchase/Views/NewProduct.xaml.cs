using AppMyPurchase.Models;

namespace AppMyPurchase.Views;

public partial class NewProduct : ContentPage
{
	public NewProduct()
	{
		InitializeComponent();
	}

    #region ToolbarItem_Clicked_Save
    private async void ToolbarItem_Clicked_Save(object sender, EventArgs e)
    {
		try
		{
			Product product = new Product()
			{
				Description = txtDescription.Text ??
				throw new ArgumentNullException("É necessário que o produto tenha uma descrição"),
				Amount = Double.Parse(txtAmount.Text),
				Price = Double.Parse(txtPrice.Text)
			};

			if (product is null)
				throw new ArgumentNullException("Produto pre fcisa conter Descrição, Quantidade e Priço!");

			await App.Database.Insert(product);
			DisplayAlert("Sucesso!", "Produto cadastrado com sucesso", "Fechar");
		}
		catch(ArgumentNullException ane)
		{
			await DisplayAlert("Erro", ane.Message, "Fechar");
		}
		catch (Exception ex)
		{
			await DisplayAlert("Erro", $"{ex.Message}, {ex.StackTrace}, {ex.HelpLink}", "Fecahr");
		}
    }
    #endregion
}