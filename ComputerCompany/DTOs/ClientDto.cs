using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ComputerCompany.DTOs
{
    [DataContract]
    public class ClientDto
    {
        [DataMember(Name = "id", IsRequired = true)]
        public int Id { get; set; }

        [DataMember(Name = "name", IsRequired = true)]
        public string Name { get; set; }

        [DataMember(Name = "surname", IsRequired = true)]
        public string Surname { get; set; }

    }
}