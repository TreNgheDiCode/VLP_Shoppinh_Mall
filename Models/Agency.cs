using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using VLPMall.Data.Enum;

namespace VLPMall.Models
{
    public class Agency
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public AgencyCategory AgencyCategory { get; set; }
    }
}
