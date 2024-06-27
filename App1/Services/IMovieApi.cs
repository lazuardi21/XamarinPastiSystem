using System.Runtime.InteropServices;
using System.Threading.Tasks;
using App1.Models;
using Refit;

namespace App1.Services
{
    public interface IMovieApi
    {
        [Get("/genre/movie/list")]
        Task<ApiResponse<GenreResponse>> GetGenresAsync([Query] string api_key);

        [Get("/discover/movie")]
        Task<ApiResponse<MovieResponse>> GetMoviesByGenreAsync([Query] int genreId, [Query] string api_key, [Query] int page);

        [Get("/movie/{movieId}/reviews")]
        Task<ApiResponse<ReviewResponse>> GetReviewsAsync([AliasAs("movieId")] int movieId, [Query] string api_key, [Query] int page);

        [Get("/movie/{movieId}/videos")]
        Task<ApiResponse<VideoResponse>> GetVideosAsync([AliasAs("movieId")] int movieId, [Query] string api_key);

        [Get("/movie/{movieId}")]
        Task<ApiResponse<Movie>> GetMovieDetailsAsync(int movieId, [Query] string api_key);
    }
}
