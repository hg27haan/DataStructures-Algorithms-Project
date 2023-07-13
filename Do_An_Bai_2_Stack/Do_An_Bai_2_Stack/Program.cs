

namespace Do_An_Bai_2_Stack
{
    internal class Program
    {
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
            GiaiThua p = new GiaiThua();
            ChuyenDoi d = new ChuyenDoi();
            int c;
            do
            {
                Console.Clear();
                Console.Write("\n------------------------------------------- CHUONG TRINH UNG DUNG CUA STACK --------------------------------------\n");
                Console.Write("||                                                                                                               ||\n");
                Console.Write("||                               1. Tinh giai thua cua n                                                         ||\n");
                Console.Write("||                               2. Chuyen doi co so (Chuyen he so 10 sang he 2 hoac he 8 hoac he 16)            ||\n");
                Console.Write("||                               3. Thoat khoi chuong trinh                                                      ||\n");
                Console.Write("||                                                                                                               ||\n");
                Console.Write("-------------------------------------------------------------------------------------------------------------------\n");
                Console.Write("\nBan chon:  ");
                c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n1.TINH GIAI THUA CUA n");
                        p.Run();
                        ExitFunc();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n2.CHUYEN DOI CO SO (CHUYEN HE SO 10 SANG HE 2 HOAC SANG HE 8)");
                        d.Run16();
                        ExitFunc();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\n3.THOAT KHOI CHUONG TRINH");
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Ban phai nhap ung yeu cau tren Menu (1-3)!!"
                            +" Hay doi 2 giay de chon lai");
                        Thread.Sleep(2000);
                        break;
                }
            } while (c != 3);
        }
        static void Main(string[] args)
        {
           Menu();
        }
    }
}