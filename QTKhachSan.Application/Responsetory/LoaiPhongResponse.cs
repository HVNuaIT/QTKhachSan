using QTKhachSan.Application.Request;
using QTKhachSan.Application.ViewModel;
using QTKhachSan.Domain.EF;
using QTKhachSan.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTKhachSan.Application.Responsetory
{
    public class LoaiPhongResponse : LoaiPhongRequest
    {
        private readonly QTKhachSanDb _db;
        public LoaiPhongResponse(QTKhachSanDb db)
        {
            _db = db;
        }

        public async Task<string> AddLoaiPhong(LoaiPhongVM loai)
        {
            var loaiPhong = new LoaiPhong();
            loaiPhong.tenLoaiPhong = loai.TenLoai;
            loaiPhong.Gia = loai.Gia;
            _db.LoaiPhongs.Add(loaiPhong);
            await _db.SaveChangesAsync();
            return "Thêm Thành Công Loại";
        }

        public List<LoaiPhongVM> GetList()
        {
            var list = _db.LoaiPhongs.ToList();
            var resul = list.Select(x => new LoaiPhongVM
            {
                TenLoai = x.tenLoaiPhong,
                Gia = x.Gia,

            });
            return resul.ToList();
        }

        public async Task<string> RemoveLoaiPhong(string idLoai)
        {
            var kiemTra = _db.LoaiPhongs.Where(x=>x.MaLoai.Equals(idLoai)).FirstOrDefault();
            if(kiemTra != null)
            {
                _db.LoaiPhongs.Remove(kiemTra);
                await _db.SaveChangesAsync();
                return "Xóa Thành Công Loai Phong: " + kiemTra.tenLoaiPhong;
            }return "Xóa Không Thành Công";
        }

        public async Task<string> UpdateLoaiPhong(string idLoai, LoaiPhongVM loaiPhongVM)
        {
            var kiemTra = _db.LoaiPhongs.Where(x => x.MaLoai.Equals(idLoai)).FirstOrDefault();
            if(kiemTra != null)
            {
                kiemTra.tenLoaiPhong = loaiPhongVM.TenLoai;
                kiemTra.Gia = loaiPhongVM.Gia;
                _db.Entry(kiemTra).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _db.SaveChangesAsync();
                return "Cập Nhật Thành Công Loại Phòng:" + kiemTra.tenLoaiPhong;
            }
            return "Cập Nhật Không Thành Công";
        }
    }
}
