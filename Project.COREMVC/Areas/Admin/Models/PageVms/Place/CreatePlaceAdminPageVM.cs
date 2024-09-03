using Project.COREMVC.Areas.Admin.Models.PureVms.City;
using Project.COREMVC.Areas.Admin.Models.PureVms.Place;

namespace Project.COREMVC.Areas.Admin.Models.PageVms.Place
{
    public class CreatePlaceAdminPageVM
    {
        public List<PlaceCityAdminPureVM> PlaceCityPureVMs { get; set; }
        public CreatePlaceAdminPureVM CreatePlaceAdminPureVM { get; set; }
    }
}
