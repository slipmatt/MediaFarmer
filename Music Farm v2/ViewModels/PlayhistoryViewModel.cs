using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.ViewModels
{
    public class PlayhistoryViewModel
    {
        public int play_id { get; set; }
        [Required(ErrorMessage = "No Track is linked to this history item", AllowEmptyStrings = false)]
        public int track_id { get; set; }
        [Required(ErrorMessage = "No User is linked to this history item", AllowEmptyStrings = false)]
        public int user_id { get; set; }
        public byte[] time_played { get; set; }
        public bool play_completed { get; set; }
        public string user_name { get; set; }
        public string track_name { get; set; }
    }
}