using Do_An_Bai_1_C_Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Bai_1_C_Sharp
{
    public class SP
    {
        private string ten;
        private int maSP;
        private DATE ngayXuatKho;
        public SP()
        { }
        public SP(string ten, int maSP, DATE ngayXuatKho)
        {
            this.ten = ten;
            this.maSP = maSP;
            this.ngayXuatKho = ngayXuatKho;
        }

        public string Ten { get => ten; set => ten = value; }
        public int MaSP { get => maSP; set => maSP = value; }
        public DATE NgayXuatKho { get => ngayXuatKho; set => ngayXuatKho = value; }

        public override string ToString()
        {
            return "Ten: " + ten + "\nMa san pham: " + maSP + "\nNgay xuat kho: " + ngayXuatKho.ToDateString();
        }

        public void Nhap()
        {
            Console.Write("Nhap ten: ");
            this.ten = Console.ReadLine();
            Console.WriteLine("Nhap ma: ");
            this.maSP = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            Console.WriteLine("Nhap ngay, thang, nam: ");
            int Day = int.Parse(Console.ReadLine());
            int Month = int.Parse(Console.ReadLine());
            int Year = int.Parse(Console.ReadLine());
            this.NgayXuatKho = new DATE(Month, Day, Year);
            Console.WriteLine("\n");
        }
        public void Xuat()
        {
            Console.Write("Ten: {0}", this.Ten);
            Console.WriteLine("");
            Console.Write("Ma san pham: {0}", this.MaSP);
            Console.WriteLine("");
            Console.Write("Ngay xuat kho: {0}", this.NgayXuatKho.ToDateString());
            Console.WriteLine("");

        }
    }
}
