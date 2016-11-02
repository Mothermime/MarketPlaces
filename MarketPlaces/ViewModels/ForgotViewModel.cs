using System.ComponentModel.DataAnnotations;

namespace MarketPlaces.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}