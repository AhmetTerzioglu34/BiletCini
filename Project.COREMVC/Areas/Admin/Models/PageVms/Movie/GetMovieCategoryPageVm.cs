using Project.COREMVC.Areas.Admin.Models.PureVms.Movie;

namespace Project.COREMVC.Areas.Admin.Models.PageVms.Movie
{
    public class GetMovieCategoryPageVm
    {
        public List<GetMovieCategoryPureVm> GetMovieCategoryPureVms { get; set; }
        public int MovieID { get; set; }
    }
}
