using MasterCrud.Models;
using MasterCrud.Services;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace MasterCrud.Pages;

public partial class CategoryCreate : ContentPage
{
    private ObservableCollection<Product> Products;

    public CategoryCreate()
    {
        InitializeComponent();
        Products = new ObservableCollection<Product>();
        ProductCollectionView.ItemsSource = Products;
    }

    // Add a new product row
    private void OnAddProductClicked(object sender, EventArgs e)
    {
        var newProduct = new Product
        {
            Name = string.Empty,
            ProductNumber = string.Empty,
            StandardCost = 0,
            ListPrice = 0
        };

        Products.Add(newProduct);
        // No need to refresh CollectionView manually due to ObservableCollection
    }

    // Delete a product row
    private void OnDeleteProductClicked(object sender, EventArgs e)
    {
        var productToDelete = (Product)((Button)sender).CommandParameter;
        Products.Remove(productToDelete);
    }

    // Save the category and its products
    private async void OnSaveCategoryClicked(object sender, EventArgs e)
    {
        string categoryName = CategoryNameEntry.Text;

        if (string.IsNullOrWhiteSpace(categoryName))
        {
            await DisplayAlert("Validation", "Please enter a category name.", "OK");
            return;
        }

        if (Products.Any(p => string.IsNullOrWhiteSpace(p.Name)))
        {
            await DisplayAlert("Validation", "All products must have a name.", "OK");
            return;
        }

        var newCategory = new ProductCategory
        {
            Name = categoryName,
            Products = Products
        };

        var categoryService = new CategoryService();

        try
        {
            await categoryService.CreateProductCategoryAsync(newCategory);
            await DisplayAlert("Success", "Category saved successfully!", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to save category: {ex.Message}", "OK");
        }
    }
}