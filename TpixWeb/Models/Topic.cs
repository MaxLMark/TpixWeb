using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpixWeb.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MainBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public int Fk_CategoryId { get; set; }
        public int Fk_MemberId { get; set; }
    }
}
