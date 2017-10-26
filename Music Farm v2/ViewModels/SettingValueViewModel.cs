using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaFarmer.ViewModels
{
    public class SettingValueViewModel
    {
        [Key]
        public int SettingId { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage ="Please enter the name of a Setting",AllowEmptyStrings =true)]
        public string SettingName { get; set; }
        [Required]
        public int SettingValue { get; set; }
        [Required]
        public int DataType { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}