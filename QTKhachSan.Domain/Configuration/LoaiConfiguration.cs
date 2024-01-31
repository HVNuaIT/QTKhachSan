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
    public class LoaiConfiguration : IEntityTypeConfiguration<LoaiPhong>
    {
        public void Configure(EntityTypeBuilder<LoaiPhong> builder)
        {
           builder.ToTable(nameof(LoaiPhong));
            builder.HasKey(x => x.MaLoai);
            builder.Property(x => x.tenLoaiPhong).IsRequired().HasDefaultValue(50);
            builder.HasIndex(x => x.tenLoaiPhong).IsUnique();
            builder.Property(x => x.Gia).IsRequired();
        }
    }
}
