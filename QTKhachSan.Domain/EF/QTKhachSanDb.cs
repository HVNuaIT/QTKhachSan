using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QTKhachSan.Domain.Configuration;
using QTKhachSan.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace QTKhachSan.Domain.EF
{
    public class QTKhachSanDb :DbContext
    {
        public QTKhachSanDb(DbContextOptions<QTKhachSanDb> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DichVuConfiguration());
            modelBuilder.ApplyConfiguration(new PhongConfiguration());
            modelBuilder.ApplyConfiguration(new LoaiConfiguration());
            modelBuilder.ApplyConfiguration(new PhieuDatPhongConfiguration());
            
        }

    
        public DbSet<Phong>Phongs { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<LoaiPhong> LoaiPhongs { get; set; }

        public DbSet<PhieuDatPhong> PhieuDatPhongs { get; set; }
    }
}
