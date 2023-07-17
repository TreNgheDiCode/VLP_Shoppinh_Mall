using VLPMall.Models;

namespace VLPMall.ViewModels
{
	public class AdminViewModel
	{
        public CreateChiNhanhViewModel? chiNhanhViewModel { get; set; }
        public CreateCuaHangViewModel? cuaHangViewModel { get; set; }
        public string? UserId { get; set; }
    }
}
