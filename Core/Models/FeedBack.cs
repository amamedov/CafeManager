using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Seen { get; set; }
        public string UsersFeedBack { get; set; }
    }
}
