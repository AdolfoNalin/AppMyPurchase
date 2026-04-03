using AppMyPurchase.Models;
using System.Collections.ObjectModel;

namespace AppMyPurchase.Views;

public partial class ListProduct : ContentPage
{
    ObservableCollection<Product> products = new ObservableCollection<Product>();
    public ListProduct()
    {
        InitializeComponent();
        lstProduct.ItemsSource = products;
    }

    #region OnAppearing
    protected async override void OnAppearing()
    {
        try
        {
            List<Product> tmp = await App.Database.GetAll();
            tmp.ForEach(product => products.Add(product));
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", $"{ex.Message}, {ex.StackTrace}, {ex.HelpLink}", "Fechar");
        }
    }
    #endregion

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
            products.Clear();
            Navigation.PushAsync(new NewProduct());
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", $"{ex.Message}, {ex.StackTrace}, {ex.HelpLink}", "Fechar");
        }
    }
    #endregion

    #region txtSeach_TextChanged
    private async void txtSeach_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            string value = e.NewTextValue;

            List<Product> tmp = new List<Product>();
            products.Clear();

            if (String.IsNullOrEmpty(value))
            {
                tmp = await App.Database.GetAll();

                tmp.ForEach((product) => products.Add(product));
            }
            else
            {
                tmp = await App.Database.Search(value);

                tmp.ForEach((product) => products.Add(product));
            }

        }
        catch (Exception ex)
        {

            throw;
        }

    }
    #endregion

    #region ToolbarItem_Clicked_1
    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            double result = products.Sum(i => i.Total);
            string msg = $"Total:{result:c}";
            DisplayAlert("Total", msg, "ok");
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", $"{ex.Message}, {ex.StackTrace}, {ex.HelpLink}", "Fechar");
        }
    }
    #endregion

    #region MenuItem_Clicked_Delete
    private async void MenuItem_Clicked_Delete(object sender, EventArgs e)
    {
        try
        {
            MenuItem item = (MenuItem)sender;
            Product product = item.CommandParameter as Product ??
                throw new ArgumentNullException("Nenhum parametro selecionado");
            bool result = await DisplayAlert("Certeza", $"Desja remover o {product.Description}?", "Sim", "Não");

            if (result)
            {
                int amountInsert = await App.Database.Delete(product.Id);

                if (amountInsert == 0)
                {
                    DisplayAlert("Banco de dados", "Nenhum produto existe no banco de dados", "Fechar");
                }
                else
                {
                    products.Clear();
                    List<Product> tmp = await App.Database.GetAll();
                    tmp.ForEach(i => products.Add(i));
                }
            }
        }
        catch (ArgumentNullException ane)
        {
            DisplayAlert("Erro", ane.ParamName, "Fechar");
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", $"{ex.Message}, {ex.StackTrace}, {ex.HelpLink}", "Fechar");
        }
    }

    #endregion

    #region lstProduct_ItemSelected
    /// <summary>
    /// Envia o item selecionado para a tela de Update
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lstProduct_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Product product = e.SelectedItem as Product;
            products.Clear();
            Navigation.PushAsync(new UpdateProduct
            {
                BindingContext = product,
            });
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", $"{ex.Message}, {ex.StackTrace}, {ex.HelpLink}", "Fechar");
        }
    }
    #endregion
}