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
    public class DichVuResponse : DichVuRequest
    {
        private readonly QTKhachSanDb _db;
        public DichVuResponse(QTKhachSanDb db)
        {
            _db = db;
        }

        public async Task<string> AddDichVu(DichVuVM dichVu)
        {
            var check = new DichVu();
            check.TenDichVu = dichVu.TenDichVu;
            check.DonGia = dichVu.DonGia;
            check.SoLuong = dichVu.SoLuong;
            _db.DichVus.Add(check);
            await _db.SaveChangesAsync();
            return "Thêm thành công";
        }

        public List<DichVuVM> GetDichVuList()
        {
            var list = _db.DichVus.ToList();
            var resuls = list.Select(x => new DichVuVM
            {
                TenDichVu = x.TenDichVu,
                SoLuong = x.SoLuong,
                DonGia = x.DonGia,
            });
            return resuls.ToList();
        }

        public async Task<string> RemoveDichVu(int idDichVu)
        {
            var kiemTra = _db.DichVus.Where(x=>x.MaLoaiDichVu == idDichVu).FirstOrDefault();
            if(kiemTra != null)
            {
                _db.DichVus.Remove(kiemTra);
                await _db.SaveChangesAsync();
                return "Xóa Thành Công Dich Vu : " + kiemTra.TenDichVu;
            }
            return "Không Tìm Thấy Dịch Vụ";
        }

        public async Task<string> UpdateDichVu(int idDichVu, DichVuVM dichVuVM)
        {
           var kiemTra = _db.DichVus.Where(x=>x.MaLoaiDichVu == idDichVu).FirstOrDefault();
            if(kiemTra != null)
            {
                kiemTra.TenDichVu = dichVuVM.TenDichVu;
                kiemTra.SoLuong = dichVuVM.SoLuong;
                kiemTra.DonGia = dichVuVM.DonGia;
               _db.Entry(kiemTra).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _db.SaveChangesAsync();
                return "Đã Chỉnh Sửa Thành Công Dịch Vụ:" + kiemTra.TenDichVu;
            }
            else
            {
                return "Update Không Thành Công";
            }

        }
    }
}
