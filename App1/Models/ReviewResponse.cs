using System.Collections.Generic;

namespace App1.Models
{
    public class ReviewResponse
    {
        public int Page { get; set; }
        public List<Review> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
