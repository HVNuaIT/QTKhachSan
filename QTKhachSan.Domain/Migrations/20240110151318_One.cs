using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QTKhachSan.Domain.Migrations
{
    public partial class One : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DichVu",
                columns: table => new
                {
                    MaLoaiDichVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDichVu = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "50"),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVu", x => x.MaLoaiDichVu);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhong",
                columns: table => new
                {
                    MaLoai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tenLoaiPhong = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "50"),
                    Gia = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhong", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    MaPhong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhong = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "50"),
                    IdLoai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.MaPhong);
                    table.ForeignKey(
                        name: "FK_Phong_LoaiPhong_IdLoai",
                        column: x => x.IdLoai,
                        principalTable: "LoaiPhong",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuDatPhong",
                columns: table => new
                {
                    IdPhieuDat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhong = table.Column<int>(type: "int", nullable: false),
                    TenNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "50"),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "10"),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "150"),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuDatPhong", x => x.IdPhieuDat);
                    table.ForeignKey(
                        name: "FK_PhieuDatPhong_Phong_IdPhong",
                        column: x => x.IdPhong,
                        principalTable: "Phong",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoaiPhong_tenLoaiPhong",
                table: "LoaiPhong",
                column: "tenLoaiPhong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDatPhong_IdPhong",
                table: "PhieuDatPhong",
                column: "IdPhong");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_IdLoai",
                table: "Phong",
                column: "IdLoai");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_MaPhong",
                table: "Phong",
                column: "MaPhong");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "PhieuDatPhong");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "LoaiPhong");
        }
    }
}
