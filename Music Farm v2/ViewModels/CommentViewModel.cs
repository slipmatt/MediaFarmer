using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.ViewModels
{
    public class CommentViewModel
    {
        public int comment_id { get; set; }
        [Required(ErrorMessage ="No Track is linked to this comment",AllowEmptyStrings =false)]
        public int play_id { get; set; }
        [Required(ErrorMessage = "No User is linked to this comment", AllowEmptyStrings = false)]
        public int user_id { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "The Comment cannot be left blank", AllowEmptyStrings = false)]
        public string comment_text { get; set; }
    }
}