using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allspice.Models
{
    public class Recipe
    {
        [Key] //marks property (ie Id, Picture etc) as primary key
        public int Id { get; set; }  
        public string Picture { get; set;}
        public string Title { get; set; }
        public string Subtitle { get; set; } 
        public string Category { get; set; }
        public string CreatorId { get; set; }  
        [ForeignKey("CreatorId")]
        public Account Creator { get; set; }//Added to access the creator object
        [InverseProperty("Recipe")]
        public ICollection<Step> Steps { get; set; } //sets the many in the one-many relationship
        [InverseProperty("Recipe")]
        public ICollection<Ingredient> Ingredients { get; set; } //sets the many in the one-many relationship

        public ICollection<Favorite> Favorites { get; set; }//ICollection sets a many in the many-many relationship

    }

   
}
