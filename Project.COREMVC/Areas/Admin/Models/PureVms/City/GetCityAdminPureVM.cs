using Project.ENTITIES.Enums;

namespace Project.COREMVC.Areas.Admin.Models.PureVms.City
{
    public class GetCityAdminPureVM
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public DataStatus Status { get; set; }
    }
}
