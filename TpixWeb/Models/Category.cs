using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpixWeb.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int FkCreatedBy { get; set; }
        public int MyProperty { get; set; }
    }
}
