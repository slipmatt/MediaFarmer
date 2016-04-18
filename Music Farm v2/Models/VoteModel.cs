using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaFarmer.Models
{
    public class VoteModel
    {
        public int VoteId { get; set; }
        public bool VoteValue { get; set; }
        public int UserId { get; set; }

        public virtual UserModel User { get; set; }
    }
}