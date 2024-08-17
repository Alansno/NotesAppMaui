namespace Notes.Views;

public partial class AllNotesPage : ContentPage
{
    public AllNotesPage()
    {
        InitializeComponent();
        BindingContext = new Notes.ViewModels.AllNotesViewModel();
    }

}