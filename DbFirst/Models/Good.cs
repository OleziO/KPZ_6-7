using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.Models
{
    public partial class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
