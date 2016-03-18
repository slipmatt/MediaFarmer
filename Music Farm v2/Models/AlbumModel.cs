using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.Models
{
    public class AlbumModel
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public virtual ICollection<TrackModel> Tracks { get; set; }
    }
}