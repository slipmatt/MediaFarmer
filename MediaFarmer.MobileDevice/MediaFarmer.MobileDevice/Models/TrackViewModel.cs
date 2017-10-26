
using System;
using System.Runtime.Serialization;

namespace MediaFarmer.MobileDevice.Models
{
    [DataContract]
    public class TrackViewModel
    {
        [DataMember]
        public int TrackId { get; set; }
        [DataMember]
        public String TrackName { get; set; }
        [DataMember]
        public int? ArtistId { get; set; }
        [DataMember]
        public int? AlbumId { get; set; }
        [DataMember]
        public String TrackURL { get; set; }
        [DataMember]
        public string PreviewURL { get; set; }
        [DataMember]
        public string AlbumName { get; set; }
        [DataMember]
        public string ArtistName { get; set; }
    }
}