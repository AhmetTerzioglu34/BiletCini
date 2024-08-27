using System.ComponentModel.DataAnnotations;

namespace Project.COREMVC.Areas.Admin.Models.PureVms.Movie
{
    public class CreateMoviePureVm
    {
        [Required(ErrorMessage = "Girilmesi zorunludur")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Girilmesi zorunludur")]
        public string Time { get; set; }
        [Required(ErrorMessage = "Girilmesi zorunludur")]

        public DateTime VisionDate { get; set; }
        [Required(ErrorMessage = "Girilmesi zorunludur")]
        public DateTime StartingDate { get; set; }
        [Required(ErrorMessage = "Girilmesi zorunludur")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Girilmesi zorunludur")]
        public string ImagePath1 { get; set; }

        [Required(ErrorMessage = "Girilmesi zorunludur")]
        public string ImagePath2 { get; set; }
        [Required(ErrorMessage = "Girilmesi zorunludur")]
        public string Description { get; set; }
    }
}
