using MasterCrud.Models;

namespace MasterCrud.Pages;

public partial class ProductListPopup : ContentPage
{
    public List<Product> Products { get; set; }

    public ProductListPopup(List<Product> products)
    {
        InitializeComponent();
        Products = products;
        BindingContext = this;
    }
    private async void OnNavigateToCategoryListClicked(object sender, EventArgs e)
    {
        // Navigate to the CategoryList page
        await Shell.Current.GoToAsync("///CategoryList");
    }
}