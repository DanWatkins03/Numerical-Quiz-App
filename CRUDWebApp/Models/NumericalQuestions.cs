using System.ComponentModel.DataAnnotations;

namespace CRUDWebApp.Models
{
    public class NumericalQuestions
    {
        public int Id { get; set; }

        [Required]
        public string NumericalQuestion { get; set; }
        
        [Required]
        public string NumericalAnswer { get; set; }
        public string Category { get; set; } 
        public string Difficulty { get; set; }

        public NumericalQuestions() 
        { 

        }
    }
}
