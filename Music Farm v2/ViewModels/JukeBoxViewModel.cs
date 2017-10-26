using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaFarmer.ViewModels
{
    public class JukeBoxViewModel
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public int? Votes { get; set; }
        public int? Favourites { get; set; }
        public int? Played { get; set; }
    }
}