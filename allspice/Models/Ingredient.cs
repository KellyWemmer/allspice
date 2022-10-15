using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public Recipe Recipe {get; set; }     
    }
}
