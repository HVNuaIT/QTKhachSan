using QTKhachSan.Application.ViewModel;
using QTKhachSan.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTKhachSan.Application.Request
{
    public interface PhongRequest
    {
        public Task <PhongVM> AddPhong(PhongVM phong);
        public Task <List<PhongVMv2>> GetPhongList();
        Task<string> RemovePhong(int idPhong);
        Task<string> UpdatePhong(int idPhong, PhongVM phongVM);
    }
}
