using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaFarmer.Models
{
    public class ArtistModel
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public virtual ICollection<TrackModel> Tracks { get; set; }
    }
}