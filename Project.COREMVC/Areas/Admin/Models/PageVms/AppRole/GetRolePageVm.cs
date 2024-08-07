using Project.COREMVC.Areas.Admin.Models.PureVms.AppRole;

namespace Project.COREMVC.Areas.Admin.Models.PageVms.AppRole
{
    public class GetRolePageVm
    {
        public List<GetRolePureVm> GetRolePureVms { get; set; }
        public CreateRolePureVm CreateRolePureVm { get; set; }
    }
}
