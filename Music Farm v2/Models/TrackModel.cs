using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MediaFarmer.Models
{
    [TrackChanges]
    [Table("Track")]
    public class TrackModel
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public Nullable<int> ArtistId { get; set; }
        public Nullable<int> AlbumId { get; set; }
        public string TrackURL { get; set; }
        public virtual AlbumModel Album { get; set; }
        public virtual ArtistModel Artist { get; set; }
        public virtual ICollection<PlayHistoryModel> PlayHistories { get; set; }
    }
}