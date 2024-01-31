using QTKhachSan.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QTKhachSan.Application.Request
{
    public interface DichVuRequest
    {
        Task<string> AddDichVu(DichVuVM dichVu);
        List<DichVuVM> GetDichVuList();
        Task<string> RemoveDichVu(int idDichVu);
        Task<string> UpdateDichVu(int idDichVu,DichVuVM dichVuVM);
    }
}
