using first.Database;
using first.Models;
using Microsoft.Data.Schema.UnitTesting;

namespace first.Views;
public partial class ProfileView : ContentPage
{
    public ProfileView()
    {
        InitializeComponent();
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.CharProf prof)
        {
            CharProfDatabase database = await CharProfDatabase.Instance;
            await database.DeleteItemAsync((CharProf)BindingContext);
        }

        await Navigation.PopAsync();
    }

    private async void EditButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.CharProf prof)
        {
            await Navigation.PushAsync(new ProfileEdit
            {
                BindingContext = prof
            });
        }

    }
}