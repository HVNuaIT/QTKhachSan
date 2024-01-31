using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTKhachSan.Domain.Enum;

namespace QTKhachSan.Domain.Entity
{
    public class Phong
    {
        public int MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string IdLoai { get; set; }
        public LoaiPhong Loai { get; set; }
        public TrangThai TrangThai { get; set; }
      
        public List<PhieuDatPhong> PDatPhong { get; set; }
        
        

    }
}
