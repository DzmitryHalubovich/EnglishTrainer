using System.ComponentModel.DataAnnotations;

namespace EnglishTrainer.ApplicationCore.Entities
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Email { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
