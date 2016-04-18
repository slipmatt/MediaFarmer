using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaFarmer.ViewModels
{
    public class AlbumViewModel
    {
        public int AlbumId { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage ="Please enter the name of an album",AllowEmptyStrings =true)]
        public string AlbumName { get; set; }
    }
}