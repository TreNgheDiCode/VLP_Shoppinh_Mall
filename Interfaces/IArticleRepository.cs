﻿using VLPMall.Data.Enum;
using VLPMall.Models;

namespace VLPMall.Interfaces
{
	public interface IArticleRepository
	{
		Task<ICollection<TinTuc>> GetAllAsync();
		Task<TinTuc> GetTinTucById(int id);
		Task<ICollection<TinTuc>> GetTinTucByLoaiTinTUc(LoaiTinTuc loaiTinTuc);
    }
}
