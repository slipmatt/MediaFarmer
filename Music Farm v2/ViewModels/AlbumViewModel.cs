using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.ViewModels
{
    public class AlbumViewModel
    {
        public int album_id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage ="You must put in a name of an album",AllowEmptyStrings =true)]
        public string album_name { get; set; }
    }
}