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
    public class PhieuDatResponse : PhieuDatRequest
    {
        private readonly QTKhachSanDb _db;
        public PhieuDatResponse(QTKhachSanDb db)
        {
            _db = db;
        }

        public async Task<string> AddPhieuDat(PhieuDatPhongVM phieuDatPhongVM)
        {
            var phieuDat = new PhieuDatPhong();
            phieuDat.TenNguoiDung = phieuDatPhongVM.TenNguoiDung;
            phieuDat.DiaChi = phieuDatPhongVM.DiaChi;
            phieuDat.SoDienThoai = phieuDatPhongVM.SoDienThoai;
            phieuDat.NgayDat = phieuDat.NgayDat;
            var check = _db.Phongs.Where(x => x.MaPhong == phieuDatPhongVM.IdPhong).FirstOrDefault();

            if (check != null && check.TrangThai == 0)
            {
                phieuDat.IdPhong = phieuDatPhongVM.IdPhong;
                _db.PhieuDatPhongs.Add(phieuDat);
                check.TrangThai = TrangThai.Hết;
                _db.Entry(check).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _db.SaveChangesAsync();
                return "Đặt phòng thành công";
            }
            else
            {
                return "Phòng đã có người đặt";
            }
        }

        public async Task<string> RemovePhieuDatPhong(int idPhieuDat)
        {
            var kiemTra = _db.PhieuDatPhongs.Where(x=>x.IdPhieuDat == idPhieuDat).FirstOrDefault();
            if(kiemTra != null)
            {
                _db.PhieuDatPhongs.Remove(kiemTra);
                await _db.SaveChangesAsync() ;
                return "Xóa Thành Công Phiếu Đặt Phòng Cửa Khách Hàng:" + kiemTra.TenNguoiDung;

            }
            return "Xóa Không Thành Công";
        }

        public Task<string> UpdatePhieuDatPhong(int idPhieuDat, PhieuDatPhongVM phieuDatPhongVM)
        {
            throw new NotImplementedException();
        }
        async Task<List<ViewPhieuDatPhong>> PhieuDatRequest.GetAllPhieuDat()
        {
            var query =
            (from PhieuDatPhong in _db.PhieuDatPhongs
             join Phong in _db.Phongs on PhieuDatPhong.IdPhong equals Phong.MaPhong
             join LoaiPhong in _db.LoaiPhongs on Phong.IdLoai equals LoaiPhong.MaLoai
             where PhieuDatPhong.IdPhong == Phong.MaPhong && Phong.IdLoai == LoaiPhong.MaLoai
             select new ViewPhieuDatPhong
             {
                 TenNguoiDat = PhieuDatPhong.TenNguoiDung,
                 DiaChi = PhieuDatPhong.DiaChi,
                 SoDienThoai = PhieuDatPhong.SoDienThoai.ToString(),
                 TenPhong = Phong.TenPhong.ToString(),
                 TrangThai = Phong.TrangThai.ToString(),
                 LoaiPhongDat = LoaiPhong.tenLoaiPhong.ToString(),
             }).ToList();
            return query.ToList();
        }


    }
}
