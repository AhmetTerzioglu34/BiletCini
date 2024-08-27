using Project.COREMVC.Models.PureVms.CateGoryPureVms;
using Project.COREMVC.Models.PureVms.CityPureVms;
using Project.COREMVC.Models.PureVms.PlacePureVms;

namespace Project.COREMVC.Models.PageVms.CategoryCityPlacePageVms
{
    public class CategoryCityPlacePageVm
    {
        public List<GetCategoriesPureVm> GetCategoriesPureVms { get; set; }
        public List<GetCityPureVm> GetCityPureVms { get; set; }
        public List<GetPlacePureVm> GetPlacePureVms { get; set; }
    }
}
