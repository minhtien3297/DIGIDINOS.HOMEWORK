using System;
using System.Collections.Generic;

namespace Blog
{
    public class Blog
    {
        public int ID { get; set; }
        public byte Image { get; set; }
        public DateTime Times { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Blog> ShowAllBlog { get; set; }
    }
}