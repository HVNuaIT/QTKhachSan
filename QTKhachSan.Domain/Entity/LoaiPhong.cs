using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTKhachSan.Domain.Entity
{
    public class LoaiPhong
    {
        public string MaLoai { get; set; }  

        public string tenLoaiPhong { get; set; }
      
        public List< Phong> Phongs { get; set; }
        public float Gia { get; set; }

    }
}
