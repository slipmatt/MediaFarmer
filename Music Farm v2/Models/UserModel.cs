using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<CommentModel> Comments { get; set; }
        public virtual ICollection<PlayHistoryModel> PlayHistories { get; set; }
        public virtual ICollection<VoteModel> Votes { get; set; }
    }
}