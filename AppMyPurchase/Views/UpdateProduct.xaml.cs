using AppMyPurchase.Models;

namespace AppMyPurchase.Views;

public partial class UpdateProduct : ContentPage
{
    public UpdateProduct()
    {
        InitializeComponent();
    }
    #region ToolbarItem_Clicked_Update
    private async void ToolbarItem_Clicked_Update(object sender, EventArgs e)
    {
        try
        {
            Product p = BindingContext as Product;
            Product product = new Product()
            {
                Id = p.Id,
                Description = txtDescription.Text,
                Amount = Double.Parse(txtAmount.Text),
                Price = Double.Parse(txtPrice.Text),
            };

            List<Product> products = await App.Database.Update(product: product);

            Navigation.PopAsync();

        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", $"{ex.Message}, {ex.StackTrace}, {ex.HelpLink}", "Fechar");
        }
    }
    #endregion
}