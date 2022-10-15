using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace allspice.Models
{
    public class Step
    {
        [Key]
        public int Id { get; set; }
        public int? Position {get; set;}
        public string Body {get; set;}
        public int RecipeId { get; set;}    

        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }    
    }
}

