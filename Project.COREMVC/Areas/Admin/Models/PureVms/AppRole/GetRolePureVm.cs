using Project.ENTITIES.Enums;

namespace Project.COREMVC.Areas.Admin.Models.PureVms.AppRole
{
    public class GetRolePureVm
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public DataStatus Status { get; set; }
    }
}
