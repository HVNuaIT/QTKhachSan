using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QTKhachSan.Domain.Entity;
using QTKhachSan.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace QTKhachSan.Domain.Configuration
{
    public class PhongConfiguration : IEntityTypeConfiguration<Phong>
    {
        public void Configure(EntityTypeBuilder<Phong> builder)
        {
           builder.ToTable(nameof(Phong));
            builder.HasKey(x => x.MaPhong);
            builder.HasIndex(x => x.MaPhong);
            builder.Property(x=>x.TenPhong).IsRequired().HasDefaultValue(50);
            builder.Property(x => x.TrangThai).IsRequired().HasDefaultValue(TrangThai.Còn);
            //Configuration Khoa Ngoai
            builder.HasOne(x =>x.Loai).WithMany(x => x.Phongs).HasForeignKey(x=>x.IdLoai);

        }
    }
}
