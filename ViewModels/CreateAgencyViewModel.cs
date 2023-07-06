using VLPMall.Data.Enum;
using VLPMall.Models;

namespace VLPMall.ViewModels
{
    public class CreateAgencyViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Address? Address { get; set; }
        public IFormFile? Image { get; set; }
        public AgencyCategory AgencyCategory { get; set; }
    }
}
