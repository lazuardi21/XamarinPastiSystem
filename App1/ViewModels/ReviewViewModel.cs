using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using App1.Models;
using App1.Services;
using Refit;

namespace App1.ViewModels
{
    public class ReviewViewModel : INotifyPropertyChanged
    {
        private readonly IMovieApi _movieApi;
        private int _movieId;
        private bool _isLoading;

        public ObservableCollection<Review> Reviews { get; set; }

        public ReviewViewModel(int movieId)
        {
            _movieApi = RestService.For<IMovieApi>("https://api.themoviedb.org/3");
            _movieId = movieId;
            Reviews = new ObservableCollection<Review>();
            _isLoading = false;

            LoadReviews(); // Optionally, load reviews when the view model is instantiated
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
