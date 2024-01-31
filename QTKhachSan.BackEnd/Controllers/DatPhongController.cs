using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTKhachSan.Application.Request;
using QTKhachSan.Application.ViewModel;

namespace QTKhachSan.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatPhongController : ControllerBase
    {
        private readonly PhieuDatRequest _phieuDatRequest;
        public DatPhongController(PhieuDatRequest phieuDatRequest)
        {
            _phieuDatRequest = phieuDatRequest;
        }
        [HttpPost]
        public async Task<IActionResult> AddDatPhong(PhieuDatPhongVM phieuDatPhongVM)
        {
            var datPhong=await _phieuDatRequest.AddPhieuDat(phieuDatPhongVM);
            return CreatedAtAction("AddDatPhong",datPhong);
        }
        [HttpGet]
        public async Task<IActionResult> GetListDatPhong()
        {
            var listDatPhong =   await _phieuDatRequest.GetAllPhieuDat();
            return Ok(listDatPhong);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePhieuDatPhong(int idPhieu)
        {
            var listDatPhong = await _phieuDatRequest.RemovePhieuDatPhong(idPhieu);
            return Ok(listDatPhong);
        }
    }
}
