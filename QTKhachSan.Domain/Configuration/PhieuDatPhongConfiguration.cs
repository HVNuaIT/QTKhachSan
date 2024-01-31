using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QTKhachSan.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTKhachSan.Domain.Configuration
{
    public class PhieuDatPhongConfiguration : IEntityTypeConfiguration<PhieuDatPhong>
    {
        public void Configure(EntityTypeBuilder<PhieuDatPhong> builder)
        {
            builder.ToTable(nameof(PhieuDatPhong));
            builder.HasKey(x => x.IdPhieuDat);
            builder.Property(x => x.NgayDat).IsRequired();
            builder.Property(x=>x.TenNguoiDung).IsRequired().HasDefaultValue(50);
            builder.Property(x => x.SoDienThoai).IsRequired().HasDefaultValue(10);
            builder.Property(x => x.DiaChi).IsRequired().HasDefaultValue(150);
            builder.HasOne(x=>x.Phong).WithMany(s=>s.PDatPhong).HasForeignKey(x => x.IdPhong).OnDelete(DeleteBehavior.Cascade);
        

        }
    }
}
