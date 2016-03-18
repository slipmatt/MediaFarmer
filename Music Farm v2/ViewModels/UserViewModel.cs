using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage ="Please enter a username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please select an option")]
        [DisplayName("Is Active")]
        public bool Active { get; set; }
    }
}