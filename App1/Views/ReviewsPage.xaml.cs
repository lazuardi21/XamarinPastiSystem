using Xamarin.Forms;
using App1.Models;
using App1.ViewModels;

namespace App1.Views
{
    public partial class ReviewsPage : ContentPage
    {
        public ReviewsPage(int movieId)
        {
            InitializeComponent();
            BindingContext = new ReviewViewModel(movieId);
        }
    }
}
