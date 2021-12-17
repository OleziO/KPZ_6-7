using System.Runtime.Serialization;

namespace ComputerCompany.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "surname")]
        public string Surname { get; set; }
    }
}