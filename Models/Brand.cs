using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VLPMall.Data.Enum;

namespace VLPMall.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public BrandCategory BrandCategory { get; set; }
    }
}
