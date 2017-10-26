using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using MediaFarmer.ViewModels;
using System.Net.Http;

namespace MediaFarmer.API.Interfaces
{
    public interface ITrackController
    {
        HttpResponseMessage GetTracks(string q = "");
    }
}
