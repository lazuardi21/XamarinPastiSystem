using Xamarin.Forms;
using App1.Views;

namespace App1.Views
{
    public partial class GenresPage : ContentPage
    {
        public GenresPage()
        {
            InitializeComponent();

            // Instantiate MoviesPage without arguments
            var moviesPage = new MoviesPage();
            Navigation.PushAsync(moviesPage);
        }
    }
}
