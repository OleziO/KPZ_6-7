using System.Runtime.Serialization;

namespace ComputerCompany.ViewModels
{
    [DataContract]
    public class GoodsViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "price")]
        public double Price { get; set; }
    }
}