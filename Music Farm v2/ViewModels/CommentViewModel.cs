using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaFarmer.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        [Required(ErrorMessage ="No Track is linked to this comment",AllowEmptyStrings =false)]
        public int PlayHistoryId { get; set; }
        [Required(ErrorMessage = "No User is linked to this comment", AllowEmptyStrings = false)]
        public int UserId { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "The Comment cannot be left blank", AllowEmptyStrings = false)]
        [DisplayName("Comment")]
        public string CommentText { get; set; }
        public string UserName { get; set; }
    }
}