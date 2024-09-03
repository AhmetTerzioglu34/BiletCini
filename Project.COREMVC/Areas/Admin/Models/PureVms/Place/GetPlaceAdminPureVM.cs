using Project.ENTITIES.Enums;

namespace Project.COREMVC.Areas.Admin.Models.PureVms.Place
{
    public class GetPlaceAdminPureVM
    {
        public int ID { get; set; }
        public string  PlaceName { get; set; }
        public string CityName { get; set; }
        public DataStatus  Status { get; set; }
    }
}
