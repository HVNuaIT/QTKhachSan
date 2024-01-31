using QTKhachSan.Application.Request;
using QTKhachSan.Application.ViewModel;
using QTKhachSan.Domain.EF;
using QTKhachSan.Domain.Entity;
using QTKhachSan.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTKhachSan.Application.Responsetory
{
    public class PhongResponse : PhongRequest
    {
        private readonly QTKhachSanDb _db;
        public PhongResponse(QTKhachSanDb db)
        {
            _db = db;
        }

        public async Task<PhongVM> AddPhong(PhongVM phong)
        {
            Phong a = new Phong();
            a.TenPhong = phong.TenPhong;
            a.IdLoai = phong.IdLoai;
            _db.Phongs.Add(a);
            await _db.SaveChangesAsync();

            return phong;
        }

        public async Task< List<PhongVMv2>> GetPhongList()
        {
            var query = (from Phong in _db.Phongs
                         join LoaiPhong in _db.LoaiPhongs on Phong.IdLoai equals LoaiPhong.MaLoai
                         select new PhongVMv2
                         {
                             TenPhong = Phong.TenPhong,
                             LoaiPhong = LoaiPhong.tenLoaiPhong,
                             TrangThai = Phong.TrangThai.ToString(),
                         }).ToList();
            return query.ToList();
        }

        public async Task<string> RemovePhong(int idPhong)
        {
            var kiemTra = _db.Phongs.Where(x => x.MaPhong.Equals(idPhong)).FirstOrDefault();
            if (kiemTra != null)
            {
                _db.Phongs.Remove(kiemTra);
             await _db.SaveChangesAsync();
                return "Xóa Thành Công Phong: " + kiemTra.TenPhong;
            }
            return "Xóa Không Thành Công";
        }

        public async Task<string> UpdatePhong(int idPhong, PhongVM phongVM)
        {
            var kiemTra = _db.Phongs.Where(x => x.MaPhong.Equals(idPhong)).FirstOrDefault();
            if (kiemTra != null)
            {
                kiemTra.TenPhong = phongVM.TenPhong;
                kiemTra.TrangThai = phongVM.TrangThai;
                kiemTra.IdLoai = phongVM.IdLoai;
                _db.Entry(kiemTra).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
               await _db.SaveChangesAsync();
                return "Cập Nhật Thành Công Loại Phòng:" + kiemTra.TenPhong;
            }
            return "Cập Nhật Không Thành Công";
        }
    }
}
