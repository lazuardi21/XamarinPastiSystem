using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string TrailerUrl { get; set; }
    }
}

