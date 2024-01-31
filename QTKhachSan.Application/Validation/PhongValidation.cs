
using FluentValidation;
using QTKhachSan.Application.ViewModel;
using QTKhachSan.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTKhachSan.Application.Validation
{
    public class PhongValidation:AbstractValidator<PhongVM>
    {
       
         public   PhongValidation()
            {
                RuleFor(x => x.TenPhong).NotEmpty().WithMessage("Xin nhập đầy đủ tên phòng");
                RuleFor(x => x.TrangThai).NotEmpty();
                
               



            }
        
    }
}
