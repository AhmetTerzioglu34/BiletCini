using Project.COREMVC.Models.PureVms.AppUserPureVms;
using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Models.PageVms.AppUserPageVms
{
    public class UserSignInPageVm
    {
        public UserSignInReguestModel UserSignInRequestModel { get; set; }
        [EmailAddress(ErrorMessage = "Email Formatında Giriş Yapınız")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
