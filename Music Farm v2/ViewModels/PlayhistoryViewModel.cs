using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.ViewModels
{
    public class PlayHistoryViewModel
    {
        public int PlayHistoryId { get; set; }
        [Required(ErrorMessage = "No Track is linked to this history item", AllowEmptyStrings = false)]
        public int TrackId { get; set; }
        [Required(ErrorMessage = "No User is linked to this history item", AllowEmptyStrings = false)]
        public int UserId { get; set; }
        public byte[] TimePlayed { get; set; }
        public bool PlayCompleted { get; set; }
        public string UserName { get; set; }
        public string TrackName { get; set; }
    }
}