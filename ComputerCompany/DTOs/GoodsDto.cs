using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ComputerCompany.DTOs
{   
    [DataContract]
    public class GoodsDto
    {
        [DataMember(Name = "id", IsRequired = true)]
        public int Id { get; set; }

        [DataMember(Name = "name", IsRequired = true)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]

        [DataMember(Name = "price", IsRequired = true)]
        public double Price { get; set; }

    }
}