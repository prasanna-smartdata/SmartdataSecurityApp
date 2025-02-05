using System.ComponentModel.DataAnnotations;

namespace SmartdataSecurity.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
    }

}
