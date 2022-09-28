using System.ComponentModel.DataAnnotations;

namespace WebhelpAPI
{
    public class Employee
    {
        public int Id { get; set; }

        public int IdentificationTypeId { get; set; }

        public IdentificationType? IdentificationType { get; set; }

        public int IdNumber { get; set; }

        [StringLength(20)]
        public string Name { get; set; } = string.Empty;

        [StringLength(20)]
        public string Lastname { get; set; } = string.Empty;

        public int AreatypeId { get; set; }

        public AreaType? AreaType { get; set; }

        [StringLength(50)]
        public String SubArea { get; set; } = string.Empty;
    }
}
