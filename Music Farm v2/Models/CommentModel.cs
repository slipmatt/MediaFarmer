using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public int PlayId { get; set; }
        public string CommentText { get; set; }
        public int UserId { get; set; }

        public virtual PlayHistoryModel PlayHistory { get; set; }
        public virtual UserModel User { get; set; }
    }
}