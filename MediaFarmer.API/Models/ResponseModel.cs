
using System;
using System.Runtime.Serialization;

namespace MediaFarmer.API.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}