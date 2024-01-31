using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTKhachSan.Application.Request;
using QTKhachSan.Application.ViewModel;

namespace QTKhachSan.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongController : ControllerBase
    {
        private readonly PhongRequest _request;
        public PhongController(PhongRequest request)
        {
            _request = request;
        }
        [HttpPost]
        public async Task<ActionResult> AddPhong([FromForm]PhongVM Phong)
        {
         var reques =   await _request.AddPhong(Phong);
           
            return CreatedAtAction("AddPhong", reques);
        }
        [HttpGet]
       
        public async Task<ActionResult> GetListPhong()
        {
            var reques = await _request.GetPhongList();

            return Ok(reques);
        }
        [HttpDelete]
        public async Task<ActionResult> DeletePhong(int id)
        {
            var reques =  await _request.RemovePhong(id);
            return Ok(reques);
        }
        [HttpPut]
        public async Task<ActionResult> UpdatePhong(int id,PhongVM phongVM)
        {
            var reques = await _request.UpdatePhong(id,phongVM);
            return Ok(reques);
        }
    }
}
