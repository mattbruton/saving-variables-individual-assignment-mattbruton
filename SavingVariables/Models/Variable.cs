using System.ComponentModel.DataAnnotations;

namespace SavingVariables.Models
{
    public class Variable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Value { get; set; }
    }
}