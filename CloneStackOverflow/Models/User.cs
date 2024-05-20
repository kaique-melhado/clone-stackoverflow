using CloneStackOverflow.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloneStackOverflow.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public ProfileEnum Profile { get; set; }
        
        [Required]
        public DateTime CreationDate { get; set;} = DateTime.Now;
    }
}