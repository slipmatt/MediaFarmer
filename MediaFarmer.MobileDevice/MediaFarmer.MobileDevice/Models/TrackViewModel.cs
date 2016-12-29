
using System;

namespace MediaFarmer.MobileDevices.ViewModels
{
    public class TrackViewModel
    {
        public int TrackId { get; set; }
        public String TrackName { get; set; }
        public int? ArtistId { get; set; }
        public int? AlbumId { get; set; }
        public String TrackURL { get; set; }
        public string PreviewURL { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public object Album { get; set; }
        public object Artist { get; set; }
    }
}