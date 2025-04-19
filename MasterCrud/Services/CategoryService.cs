using MasterCrud.Models;
using System.Net.Http.Json;


namespace MasterCrud.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7115/")
            };
        }

        public async Task<List<ProductCategory>> GetProductCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("ProductCategories");
            response.EnsureSuccessStatusCode();
            var categories = await response.Content.ReadFromJsonAsync<List<ProductCategory>>();
            return categories ?? new List<ProductCategory>();
        }

        public async Task<ProductCategory> GetProductCategoryAsync(int id)
        {
            var response = await _httpClient.GetAsync($"ProductCategories/{id}");
            response.EnsureSuccessStatusCode();
            var category = await response.Content.ReadFromJsonAsync<ProductCategory>();
            return category ?? new ProductCategory();
        }

        public async Task CreateProductCategoryAsync(ProductCategory category)
        {
            var response = await _httpClient.PostAsJsonAsync("ProductCategories", category);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductCategoryAsync(ProductCategory category)
        {
            var response = await _httpClient.PutAsJsonAsync($"ProductCategories/{category.ProductCategoryID}", category);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"ProductCategories/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}