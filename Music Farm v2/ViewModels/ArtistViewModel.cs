using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.ViewModels
{
    public class ArtistViewModel
    {
        public int artist_id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage ="You must enter an Artist Name",AllowEmptyStrings = true)]
        public string artist_name { get; set; }
    }
}