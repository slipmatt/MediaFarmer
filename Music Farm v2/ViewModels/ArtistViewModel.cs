using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.ViewModels
{
    public class ArtistViewModel
    {
        public int ArtistId { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage ="Please enter an Artist Name",AllowEmptyStrings = true)]
        public string ArtistName { get; set; }
    }
}