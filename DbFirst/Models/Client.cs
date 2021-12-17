using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
