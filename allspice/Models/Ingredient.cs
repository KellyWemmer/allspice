using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allspice.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Quantity { get; set; }  
        public int RecipeId { get; set; }
        
        [ForeignKey("RecipeId")]
        [InverseProperty("Ingredients")]        
        public Recipe Recipe {get; set; } 
    
    }
}
