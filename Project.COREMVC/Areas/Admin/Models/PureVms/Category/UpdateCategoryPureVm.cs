using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Areas.Admin.Models.PureVms.Category
{
    public class UpdateCategoryPureVm
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Girilmesi zorunludur")]
        public string CategoryName { get; set; }
    }
}
