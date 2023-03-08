using System.Text.Json.Serialization;
using first.Database;
using first.Models;

namespace first.Views;

public partial class ProfileEdit : ContentPage
{
    public ProfileEdit()
	{
        InitializeComponent();
    }
  
	private async void SaveButton_Clicked(object sender, EventArgs e)
	{
        // Save file
        var prof = (CharProf)BindingContext;
        CharProfDatabase database = await CharProfDatabase.Instance;
        await database.SaveItemAsync(prof);
        //allowed to use await as function has async in declaration
        //navigate back to previous page
        await Navigation.PopAsync();
    }

    private async void ResetButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}