using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MediaFarmer.MobileDevice.Models
{
    [DataContract]
    public class QueModel
    {
        [DataMember]
        public int PlayHistoryId { get; set; }
        [DataMember]
        public string TrackName { get; set; }
        [DataMember]
        public string UserName { get; set; }
    }
}
