using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Models.PureVms.AppUserPureVms
{
   
        public class UserPasswordPureVm
        {
            public int Id { get; set; }

            public Guid? token { get; set; }

            [Required(ErrorMessage = "{0} zorunludur")]
            [Display(Name = "Yeni şifre alanı")]
            [MinLength(3, ErrorMessage = "Minimum {1} karakter girilmesi lazım")]
            [MaxLength(16, ErrorMessage = "Maksimum {1} karakter girilmesi lazım")]
            public string NewPassword { get; set; }


            [Required(ErrorMessage = "{0} zorunludur")]
            [Display(Name = "Yeni şifre tekrarı")]
            [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor")]
            public string ConfirmPassword { get; set; }
        }
    }

