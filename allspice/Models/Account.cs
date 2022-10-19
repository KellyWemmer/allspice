using System.Collections.Generic;
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

        public ICollection<Favorite> Favorites { get; set; } //ICollection tells Account that there will be many favorites
    }
}