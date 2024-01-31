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
    public class DichVuConfiguration : IEntityTypeConfiguration<DichVu>
    {
        public void Configure(EntityTypeBuilder<DichVu> builder)
        {
           builder.ToTable(nameof(DichVu));
            builder.HasKey(x => x.MaLoaiDichVu);
            builder.Property(x => x.TenDichVu).IsRequired().HasDefaultValue(50);
            builder.Property(x => x.SoLuong).IsRequired();
            builder.Property(x => x.DonGia).IsRequired();
            //Configuration Khoa Ngoai
        }
    }
}
