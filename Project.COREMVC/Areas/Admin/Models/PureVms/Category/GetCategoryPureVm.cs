using Project.ENTITIES.Enums;

namespace Project.COREMVC.Areas.Admin.Models.PureVms.Category
{
    public class GetCategoryPureVm
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public DataStatus Status { get; set; }
    }
}
