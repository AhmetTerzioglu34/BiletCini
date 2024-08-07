using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Areas.Admin.Models.PureVms.Category
{
    public class CreateCategoryPureVm
    {
        [Required(ErrorMessage = "Girilmesi zorunludur")]
        public string CategoryName { get; set; }
    }
}
