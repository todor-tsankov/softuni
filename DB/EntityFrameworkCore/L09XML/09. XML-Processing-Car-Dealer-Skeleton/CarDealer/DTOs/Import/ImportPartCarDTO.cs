using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("partId")]
    public class ImportPartCarDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        public int CompareTo([AllowNull] ImportPartCarDTO other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(ImportPartCarDTO))
            {
                return this.GetHashCode() == obj.GetHashCode();
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
