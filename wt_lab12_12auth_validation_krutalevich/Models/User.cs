using System.ComponentModel.DataAnnotations;

namespace wt_lab12_12auth_validation_krutalevich.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Логин")]
        public string Login { get; set; } = "";

        [Required]
        [StringLength(100, MinimumLength = 4)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = "";
    }
}
