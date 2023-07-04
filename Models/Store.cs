using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VLPMall.Data.Enum;

namespace VLPMall.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public StoreCategory StoreCategory { get; set; }
        [ForeignKey("Agency")]
        public int? AgencyId { get; set; }
        public Agency? Agency { get; set; }
    }
}
