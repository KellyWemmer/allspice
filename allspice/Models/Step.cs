using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [InverseProperty("Steps")]
        [JsonIgnore]
        public Recipe Recipe { get; set; }    
    }
}

