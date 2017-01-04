
using System;
using System.Threading.Tasks;
using PortableRest;
using System.Net.Http;
using System.Collections.Generic;
using MediaFarmer.MobileDevice.Models;
using MediaFarmer.MobileDevice.Helpers;

namespace MediaFarmer.MobileDevice
{
    public class MediaFarmerException : Exception
    {
        public MediaFarmerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    public class MediaFarmerApi
    {

        private string BaseUrl = string.Concat("http://", Settings.HostKeySettings,":", Settings.PortKeySettings,"/api");

        public T Execute<T>(RestRequest request) where T : class
        {
            var client = new RestClient();
            client.BaseUrl = BaseUrl;
            var response = client.ExecuteAsync<T>(request);

            if (response.Exception != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var MediaFarmerException = new MediaFarmerException(message, response.Exception);
                throw MediaFarmerException;
            }
            return response.Result;
        }

        public async Task<List<TrackViewModel>> GetTracks(string Url)
        {
            var request = new RestRequest(String.Concat("/Track/","?q=",Url), HttpMethod.Get) { ContentType = ContentTypes.Json };
            return Execute<List<TrackViewModel>>(request);
        }

        public async Task<ResponseModel> QueTrack(int TrackId)
        {
            var request = new RestRequest(String.Concat("/PlayHistory/Que/", TrackId), HttpMethod.Get) { ContentType = ContentTypes.Json };
            return Execute<ResponseModel>(request);
        }

        public async Task<ResponseModel> Ping()
        {
            var request = new RestRequest(String.Concat("/Auth/Ping"), HttpMethod.Get) { ContentType = ContentTypes.Json };
            return Execute<ResponseModel>(request);
        }
    }
}
