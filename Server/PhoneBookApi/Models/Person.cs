using System.ComponentModel.DataAnnotations.Schema; 

namespace PhoneBookApi.Models
{
    
    [Table("Contacts")]
    public class Person
    {
        [Column("id")] 
        public int Id { get; set; }

        [Column("name")] 
        public string Name { get; set; } = string.Empty;

        [Column("surname")]
        public string Surname { get; set; } = string.Empty;

        [Column("age")]
        public int Age { get; set; }

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("phone_number")] 
        public string PhoneNumber { get; set; } = string.Empty;
    }
}