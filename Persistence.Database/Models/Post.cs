using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
