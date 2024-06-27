using System.Collections.Generic;

namespace App1.Models
{
    public class VideoResponse
    {
        public int Id { get; set; }
        public List<Video> Results { get; set; }
    }

    public class Video
    {
        public string Key { get; set; }
        public string Site { get; set; }
        public string Type { get; set; }
    }
}
