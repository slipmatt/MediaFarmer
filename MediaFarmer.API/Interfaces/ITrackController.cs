using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MediaFarmer.API.Interfaces
{
    public interface ITrackController
    {
        string GetTracks(string q = "");
    }
}
