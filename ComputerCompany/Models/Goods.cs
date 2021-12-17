using System.ComponentModel.DataAnnotations;

namespace ComputerCompany.Models
{
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

       
    }
}