using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Areas.Admin.Models.PureVms.AppRole
{
    public class UpdateRolePureVm
    {
        public string ID { get; set; }

        [Required(ErrorMessage = "{0} Girilmesi Zorunludur")]
        public string RoleName { get; set; }
    }
}
