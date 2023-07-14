using System.ComponentModel.DataAnnotations;
using VLPMall.Models;

namespace VLPMall.ViewModels
{
    public class RegisterViewModel
    {
        // Họ tên
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Vui lòng họ và tên của bạn")]
        [DataType(DataType.Text)]
        public string HoTen { get; set; }
        
        // Mật khẩu
        [Display(Name = "Mật khẩu")]
        [Required]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        // Nhập lại mật khẩu
        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu nhập lại không trùng khớp")]
        public string NhapLaiMatKhau { get; set; }

        // Ảnh đại diện
        [Display(Name = "Hình đại diện")]
        public IFormFile? AnhDaiDien { get; set; }

        // Địa chỉ nơi ở
        [Display(Name = "Địa chỉ nơi ở hiện tại")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ nơi ở")]
        [DataType(DataType.Text)]
        public DiaChi DiaChi { get; set; }

        // Giới tính
        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính của bạn")]
        public bool GioiTinh { get; set; }

        // Ngày sinh
        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Vui lòng chọn ngày sinh của bạn")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        // Địa chỉ Email
        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Số điện thoại
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại của bạn")]
        [DataType(DataType.PhoneNumber)]
        public string SoDienThoai { get; set; }
    }
}
