using SharedLibrary.Resources;
using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Entities
{
    public class UserRequest
    {
        public int Id { get; set; }


        [Display(Name = "User", ResourceType = typeof(Literals))]
        public string User { get; set; } = null!;

        [Display(Name = "Request", ResourceType = typeof(Literals))]
        public string Request { get; set; } = null!;

        [Display(Name = "Accounts", ResourceType = typeof(Literals))]
        public int Accounts { get; set; } = 0!;

        [Display(Name = "Status", ResourceType = typeof(Literals))]
        public string Status { get; set; } = ""!;
    }
}
