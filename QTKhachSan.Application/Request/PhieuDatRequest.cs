using QTKhachSan.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTKhachSan.Application.Request
{
    public interface PhieuDatRequest
    {
        Task<string>AddPhieuDat(PhieuDatPhongVM phieuDatPhongVM);
        Task<List<ViewPhieuDatPhong>>GetAllPhieuDat();
        Task<string> RemovePhieuDatPhong(int idPhieuDat);
        Task<string> UpdatePhieuDatPhong(int idPhieuDat, PhieuDatPhongVM phieuDatPhongVM);
    }
}
