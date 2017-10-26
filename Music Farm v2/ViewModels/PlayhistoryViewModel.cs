using MusicFarmer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaFarmer.ViewModels
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
        public bool IsPlaying { get; set; }
        public string UserName { get; set; }
        public string TrackName { get; set; }
        public User User { get; set; }
        public Track Track { get; set; }
    }
}