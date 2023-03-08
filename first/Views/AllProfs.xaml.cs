using first.Database;
using first.Models;
using System.Collections.Generic;

namespace first.Views;

public partial class AllProfs : ContentPage
{
	public AllProfs()
	{
		InitializeComponent();

        BindingContext = new Models.AllProfs();
        
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        CharProfDatabase database = await CharProfDatabase.Instance;
        profsCollection.ItemsSource = (System.Collections.IEnumerable)await database.GetItemsAsync();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ProfileEdit), true, new Dictionary<string, object>
        {
            ["Item"] = new CharProf()
        });
    }

    private async void profsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            //get the note model
            var prof = (Models.CharProf)e.CurrentSelection[0];

            await Navigation.PushAsync(new ProfileView
            {
                BindingContext = prof
            });
            //unselect the ui
            profsCollection.SelectedItem = null;
        }
    }

}