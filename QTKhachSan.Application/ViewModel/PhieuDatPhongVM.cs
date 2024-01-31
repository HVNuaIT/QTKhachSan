using QTKhachSan.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTKhachSan.Application.ViewModel
{
    public class PhieuDatPhongVM
    {

        public int IdPhong { get; set; }
        public DateTime NgayDat { get; set; }
        public string TenNguoiDung { get; set; }
        public string SoDienThoai {  get; set; }
        public string DiaChi { get; set; }
    }
}
