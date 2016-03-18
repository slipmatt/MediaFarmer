using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.ViewModels
{
    public class TrackViewModel
    {
        public int track_id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "A track name has to be specified", AllowEmptyStrings = false)]
        public String track_name { get; set; }
        [Required(ErrorMessage = "An artist has to be selected", AllowEmptyStrings = false)]
        public int? artist_id { get; set; }
        [Required(ErrorMessage = "An album has to be selected", AllowEmptyStrings = false)]
        public int? album_id { get; set; }
    }
}