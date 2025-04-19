using MasterCrud.Models;
using MasterCrud.Services;
using System.Collections.ObjectModel;

namespace MasterCrud.Pages;

public partial class CategoryList : ContentPage
{
    private readonly CategoryService _categoryService;
    public ObservableCollection<ProductCategory> Categories { get; set; }

    public CategoryList()
    {
        InitializeComponent();
        _categoryService = new CategoryService();
        Categories = new ObservableCollection<ProductCategory>();
        BindingContext = this;
        LoadCategories();
    }

    // Load categories from the API
    private async void LoadCategories()
    {
        try
        {
            var categories = await _categoryService.GetProductCategoriesAsync();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to load categories. " + ex.Message, "OK");
        }
    }

    // Edit Category
    private async void OnEditCategoryClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var categoryId = (int)button.CommandParameter;

        // Navigate to the Category Edit page with the selected categoryId
        // Uncomment and implement CategoryEditPage
        await Navigation.PushAsync(new CategoryEdit(categoryId));
    }

    // Delete Category
    private async void OnDeleteCategoryClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var categoryId = (int)button.CommandParameter;

        bool confirmDelete = await DisplayAlert("Delete Category", "Are you sure you want to delete this category?", "Yes", "No");

        if (confirmDelete)
        {
            try
            {
                await _categoryService.DeleteProductCategoryAsync(categoryId);
                // Reload categories after deletion
                Categories.Clear();
                LoadCategories();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Failed to delete category. " + ex.Message, "OK");
            }
        }
    }

    // Handle tap on "Number of Products" to show product list in a modal popup
    private async void OnNumberOfProductsTapped(object sender, EventArgs e)
    {
        var label = (Label)sender;
        var category = label.BindingContext as ProductCategory;

        if (category != null)
        {
            // Convert ObservableCollection to List, as ProductListPopup expects a List
            var productList = category.Products.ToList();

            // Pass the list of products to the pop-up page
            var popupPage = new ProductListPopup(productList);
            await Navigation.PushModalAsync(popupPage);
        }
    }
}
