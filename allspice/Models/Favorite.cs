using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allspice.Models
{
    public class Favorite
    {   
        [Key]
        public int Id {get; set;}
        public string AccountId {get; set;}
        public int RecipeId {get; set;}  

        [ForeignKey("RecipeId")] 

        public Recipe Recipe {get; set;} 
        
        [ForeignKey("AccountId")]  
        public Account Account {get; set;}
    }
}