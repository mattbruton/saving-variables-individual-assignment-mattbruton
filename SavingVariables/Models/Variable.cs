using System.ComponentModel.DataAnnotations;

namespace SavingVariables.Models
{
    public class Variable
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        [MaxLength(1, ErrorMessage = "Only a single letter may be entered for Name")]
        public virtual string Name { get; set; }
        [Required]
        public virtual int Value { get; set; }
    }
}