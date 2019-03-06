using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpixWeb.Models.ViewModels
{
    public class TopicViewModel
    {
        public List<Post> Posts { get; set; }
        public Topic CurrentTopic { get; set; }
        public Post NewPost { get; set; }

    }
}
