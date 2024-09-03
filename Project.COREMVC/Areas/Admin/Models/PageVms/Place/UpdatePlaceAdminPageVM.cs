using Project.COREMVC.Areas.Admin.Models.PureVms.City;
using Project.COREMVC.Areas.Admin.Models.PureVms.Place;

namespace Project.COREMVC.Areas.Admin.Models.PageVms.Place
{
    public class UpdatePlaceAdminPageVM
    {
        public List<PlaceCityAdminPureVM> PlaceAdminPureVMs { get; set; }
        public UpdatePlaceAdminPureVM UpdatePlaceAdminPureVM { get; set; }
    }
}
