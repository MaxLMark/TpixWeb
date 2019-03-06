using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpixWeb.Models.ViewModels
{
    public class CategoryViewModel
    {
        public List<Topic> Topics { get; set; }
        public Topic NewTopic { get; set; }
        public Category CurrentCategory { get; set; }
    }
}
