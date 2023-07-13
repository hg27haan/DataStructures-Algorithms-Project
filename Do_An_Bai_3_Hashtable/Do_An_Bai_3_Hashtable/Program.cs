using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Do_An_Bai_3_Hashtable
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu();
        }
        public static void Exit()
        {
            Console.WriteLine("\nTro Ve Menu hay Thoat?\n" +
                              "Tro ve Menu (an 1) - Thoat (an 2)");
            Console.WriteLine("\nHay nhap lua chon cua ban: ");
            int luaChon;
            try
            {
                luaChon = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ban hay nhap dung yeu cau o tren (Nhap 1 hoac 2)");
                Console.WriteLine("\nHay nhap lua chon cua ban");
                luaChon = int.Parse(Console.ReadLine());
            }
            Kiemtra(luaChon);
        }

        public static void Kiemtra(int a)
        {
            if (a == 2)
            {
                Console.Clear();
                Console.WriteLine("Cam on ban da su dung chuong trinh nay");
                Console.WriteLine("Tac gia: Do Ngoc Han - 21133030 va Huynh Gia Han - 21133031");
                Environment.Exit(0);
            }
            if (a != 1)
            {
                Console.WriteLine("\nBan da nhap sai. Moi ban nhap lai!!!");
                Exit();
            }
        }

        public static void ExitFunc()
        {
            Console.WriteLine("\nChuc nang da duoc thuc hien\n");
            Exit();
        }

        public static void Menu()
        {
            HashTable hstbl = new HashTable();
            Application app = new Application();
            NODE Temp = new NODE();

           
            app.ReadFile(hstbl);
            int c;
            do
            {
                Console.Clear();
                Console.Write("\n-----------------------CHUONG TRINH TU DIEN (HASHTABLE) ----------------------------\n");
                Console.Write("||                                                                                  ||\n");
                Console.Write("||                        1. Tra cuu tu (Anh - Viet)                                ||\n");
                Console.Write("||                        2. Them tu                                                ||\n");
                Console.Write("||                        3. Xoa tu                                                 ||\n");
                Console.Write("||                        4. Cap nhat tu                                            ||\n");
                Console.Write("||                        5. Danh sach cac tu (doc tu File tu vung)                 ||\n");
                Console.Write("||                        6. Thoat khoi chuong trinh                                ||\n");
                Console.Write("||                                                                                  ||\n");
                Console.Write("--------------------------------------------------------------------------------------\n");
                Console.Write("\nBan chon:  ");
                c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("\n1.TRA CUU TU (ANH - VIET)");
                            Console.Write("\nNhap tu ban muon tra cuu:");
                            Tu w = new Tu();
                            w.tu = Console.ReadLine();
                            app.Search(hstbl, w);
                            ExitFunc();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("\n2.THEM TU");
                            Console.WriteLine("\nNhap tu ban muon them: ");
                            Console.Write("Nhap tu: ");
                            Tu w2 = new Tu();
                            w2.tu = Console.ReadLine();
                            Console.Write("Nhap loai: ");
                            w2.loai = Console.ReadLine();
                            Console.Write("Nhap nghia: ");
                            w2.nghia = Console.ReadLine();
                            app.Add(hstbl, w2);
                            ExitFunc();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("\n3.XOA TU");
                            Console.WriteLine("\nNhap tu va tu loai ban muon xoa: ");
                            Console.Write("Nhap tu: ");
                            Tu w3 = new Tu();
                            w3.tu = Console.ReadLine();
                            Console.Write("Nhap loai: ");
                            w3.loai = Console.ReadLine();
                            app.Delete(hstbl, w3);
                            ExitFunc();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("\n4.CAP NHAT TU");
                            Console.WriteLine("\nNhap tu ban muon cap nhat: ");
                            Console.Write("Nhap tu: ");
                            Tu w4 = new Tu();
                            w4.tu = Console.ReadLine();
                            Console.Write("Nhap loai: ");
                            w4.loai = Console.ReadLine();
                            Console.Write("Nhap nghia: ");
                            w4.nghia = Console.ReadLine();
                            app.Update(hstbl, w4);
                            ExitFunc();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("\n5.DANH SACH CAC TU (DOC TU FILE TU VUNG)");
                            app.XuatTuDien(hstbl);
                            ExitFunc();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("\n6.THOAT KHOI CHUONG TRINH");
                            Exit();
                            break;
                        }
                    default:
                        Console.WriteLine("Ban phai nhap ung yeu cau tren Menu (1-3)!!"
                            + " Hay doi 2 giay de chon lai");
                        Thread.Sleep(2500);
                        break;
                }
            } while (true);
        }
    }
}