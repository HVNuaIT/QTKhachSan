using QTKhachSan.Application.ViewModel;
using QTKhachSan.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTKhachSan.Application.Request
{
    public interface LoaiPhongRequest
    {
        public Task<string> AddLoaiPhong(LoaiPhongVM loai);
        public List<LoaiPhongVM> GetList();
        Task<string> RemoveLoaiPhong(string idLoai);
        Task<string> UpdateLoaiPhong(string idLoai, LoaiPhongVM loaiPhongVM );
    }
}
