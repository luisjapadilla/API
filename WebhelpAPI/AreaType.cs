using System.ComponentModel.DataAnnotations;

namespace WebhelpAPI
{
    public class AreaType
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string AreaName { get; set; } = string.Empty;
    }
}
