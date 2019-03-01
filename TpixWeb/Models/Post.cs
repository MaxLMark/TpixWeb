using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpixWeb.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string MainBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
        public int FkParentTopicId { get; set; }
        public int FkCreatedBy { get; set; }
    }
}
