using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MediaFarmer.MobileDevice.Models
{
    [DataContract]
    public class SettingsViewModel
    {
        [DataMember]
        public int SettingId { get; set; }
        [DataMember]
        public string SettingName { get; set; }
        [DataMember]
        public int SettingValue { get; set; }
        [DataMember]
        public int DataType { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}
