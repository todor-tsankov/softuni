using System.Xml.Serialization;
using System.Collections.Generic;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class UserDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public SoldProductsDTO ProductsSold { get; set; }
    }
}
