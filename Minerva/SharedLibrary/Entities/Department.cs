using SharedLibrary.Resources;
using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Entities
{
    public class Department
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Literals))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
        public string Name { get; set; } = null!;

        [Display(Name = "Description", ResourceType = typeof(Literals))]
        [MaxLength(255, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
        public string Description { get; set; } = null!;

        [Display(Name = "Location", ResourceType = typeof(Literals))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
        public string Location { get; set; } = null!;

        [Display(Name = "Manager", ResourceType = typeof(Literals))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
        public bool IsActive { get; set; }

        [Display(Name = "CreatedAt", ResourceType = typeof(Literals))]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "UpdatedAt", ResourceType = typeof(Literals))]
        public DateTime UpdatedAt { get; set; }
    }
}