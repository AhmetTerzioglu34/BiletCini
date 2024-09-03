using Project.COREMVC.Areas.Admin.Models.PureVms.Screen;

namespace Project.COREMVC.Areas.Admin.Models.PageVms.Screen
{
    public class CreateScreenAdminPageVM
    {
        public List<ScreenPlaceAdminPureVM>  ScreenPlaceAdminPureVMs { get; set; }
        public CreateScreenAdminPureVM CreateScreenAdminPureVM { get; set; }
    }
}
