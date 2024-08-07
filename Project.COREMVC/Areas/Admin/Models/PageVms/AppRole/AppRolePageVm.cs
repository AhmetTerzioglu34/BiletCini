using Project.COREMVC.Areas.Admin.Models.PureVms.AppRole;

namespace Project.COREMVC.Areas.Admin.Models.PageVms.AppRole
{
    public class AppRolePageVm
    {
        public List<AppRoleResponseModel> Roles { get; set; }
        public int UserID { get; set; }
    }
}
