using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaFarmer.ViewModels
{
    public class FavouriteViewModel
    {
        public int FavouriteId { get; set; }
        public int UserId { get; set; }
        public int TrackId { get; set; }
        public string UserName { get; set; }
        public string TrackName { get; set; }
    }
}