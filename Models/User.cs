using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLPMall.Models
{
    public class User : IdentityUser
    {
        public string? ProfileImageUrl { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Store>? Stores { get; set; }
    }
}
