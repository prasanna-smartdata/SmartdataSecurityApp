using System.ComponentModel.DataAnnotations;

namespace SmartdataSecurity.Model
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Address1 { get; set; } = string.Empty;

        public string Address2 { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;    

        public string Street { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;



    }
}
