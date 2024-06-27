using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using App1.Models;
using App1.Services;
using Refit;

namespace App1.ViewModels
{
    public class MovieDetailsViewModel : INotifyPropertyChanged
    {
        private readonly IMovieApi _movieApi;
        private int _movieId;
        private bool _isLoading;

        public Movie Movie { get; set; }
        public ObservableCollection<Review> Reviews { get; set; }

        // Parameterless constructor
        public MovieDetailsViewModel()
        {
            _movieApi = RestService.For<IMovieApi>("https://api.themoviedb.org/3");
            Movie = new Movie();
            Reviews = new ObservableCollection<Review>();
            _isLoading = false;

            // Optionally, load movie details and reviews when the view model is instantiated
            // Note: Avoid passing arguments here
            LoadMovieDetails();
            LoadReviews();
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

        public async Task LoadMovieDetails()
        {
            if (IsLoading) return;

            IsLoading = true;
            var response = await _movieApi.GetMovieDetailsAsync(_movieId, "your_api_key");
            if (response.IsSuccessStatusCode)
            {
                Movie = response.Content; // Assuming the response directly maps to Movie object
            }
            IsLoading = false;
        }

        public async Task LoadReviews()
        {
            if (IsLoading) return;

            IsLoading = true;
            var response = await _movieApi.GetReviewsAsync(_movieId, "your_api_key", page: 1);
            if (response.IsSuccessStatusCode)
            {
                foreach (var review in response.Content.Results)
                {
                    Reviews.Add(review);
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
