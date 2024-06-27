using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using App1.Models;
using App1.Services;
using Refit;

namespace App1.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        private readonly IMovieApi _movieApi;
        private bool _isLoading;

        public ObservableCollection<Movie> Movies { get; set; }

        public MovieViewModel()
        {
            _movieApi = RestService.For<IMovieApi>("https://api.themoviedb.org/3");
            Movies = new ObservableCollection<Movie>();
            _isLoading = false;

            // Optionally, load movies when the view model is instantiated
            LoadMovies();
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public async Task LoadMovies()
        {
            if (IsLoading) return;

            IsLoading = true;
            var response = await _movieApi.GetMoviesByGenreAsync(genreId: 28, api_key: "your_api_key", page: 1); // Replace genreId with actual genre ID
            if (response.IsSuccessStatusCode)
            {
                foreach (var movie in response.Content.Results)
                {
                    Movies.Add(movie);
                }
            }
            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
