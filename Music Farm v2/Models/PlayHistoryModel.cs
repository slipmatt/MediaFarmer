using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Farm_v2.Models
{
    public class PlayHistoryModel
    {
        public int PlayHistoryId { get; set; }
        public int TrackId { get; set; }
        public int UserId { get; set; }
        public byte[] TimePlayed { get; set; }
        public bool PlayCompleted { get; set; }
        public bool IsPlaying { get; set; }
        public virtual ICollection<CommentModel> Comments { get; set; }
        public virtual TrackModel Track { get; set; }
        public virtual UserModel User { get; set; }
    }
}