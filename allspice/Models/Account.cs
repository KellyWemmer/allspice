using System.ComponentModel.DataAnnotations;

namespace allspice.Models
{
    public class Account
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}