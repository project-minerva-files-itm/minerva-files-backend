using SharedLibrary.Resources;
using System.ComponentModel.DataAnnotations;


namespace SharedLibrary.DTOs
{
    public class UserEmailDTO
    {
        [Display(Name = "Email", ResourceType = typeof(Literals))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
        [StringLength(255, MinimumLength = 6, ErrorMessageResourceName = "LengthField", ErrorMessageResourceType = typeof(Literals))]
        public string Email { get; set; } = null!;

        public string? Language { get; set; } = null!;
        
    }
}
