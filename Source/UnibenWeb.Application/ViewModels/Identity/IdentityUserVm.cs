using System.ComponentModel.DataAnnotations;

namespace UnibenWeb.Application.ViewModels.Identity
{
    public class IdentityUserVm
    {
        [Key]
        public int Id { get; set; }
        public string UserKey { get; set; }
    }
}