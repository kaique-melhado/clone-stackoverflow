using System.ComponentModel.DataAnnotations.Schema;

namespace CloneStackOverflow.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; } 

        public string Nome { get; set; }    

        public string Email { get; set;}

        public string Senha { get; set;}

        public DateTime DataCadastro { get; set;} 
    }
}
