namespace MasterCrud.Pages;

public partial class CategoryEdit : ContentPage
{
	public CategoryEdit(int id)
	{
		InitializeComponent();
		DisplayAlert("Edit", id.ToString(), "Ok");
	}
}