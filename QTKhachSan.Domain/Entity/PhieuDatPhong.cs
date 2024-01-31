using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTKhachSan.Domain.Entity
{
    public class PhieuDatPhong
    {
        public int IdPhieuDat {  get; set; }    
        public int IdPhong {  get; set; }
        public Phong Phong { get; set; }
        public string TenNguoiDung { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayDat {  get; set; }
     

        

    }
}
