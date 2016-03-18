using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.ViewModels
{
    public class TrackViewModel
    {
        public int TrackId { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "A track name has to be specified", AllowEmptyStrings = false)]
        public String TrackName { get; set; }
        [Required(ErrorMessage = "An artist has to be selected", AllowEmptyStrings = false)]
        public int? ArtistId { get; set; }
        [Required(ErrorMessage = "An album has to be selected", AllowEmptyStrings = false)]
        public int? AlbumId { get; set; }
    }
}