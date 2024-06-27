using System.Collections.ObjectModel;
using System.ComponentModel;
using App1.Models;
using App1.Services;
using Refit;

namespace App1.ViewModels
{
    public class GenreViewModel : INotifyPropertyChanged
    {
        private readonly IMovieApi _movieApi;
        public ObservableCollection<Genre> Genres { get; set; }

        public GenreViewModel()
        {
            _movieApi = RestService.For<IMovieApi>("https://api.themoviedb.org/3");
            Genres = new ObservableCollection<Genre>();
            LoadGenres();
        }

        private async void LoadGenres()
        {
            var response = await _movieApi.GetGenresAsync("your_api_key");
            if (response.IsSuccessStatusCode)
            {
                foreach (var genre in response.Content.Genres)
                {
                    Genres.Add(genre);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
