using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Post> Posts { get; set; }
    }
}
