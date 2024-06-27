using Xamarin.Forms;
using App1.ViewModels;

namespace App1.Views
{
    public partial class MoviesPage : ContentPage
    {
        private MovieViewModel _viewModel;

        public MoviesPage()
        {
            InitializeComponent();

            _viewModel = new MovieViewModel();
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.LoadMovies();
        }
    }
}
