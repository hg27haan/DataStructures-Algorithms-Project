using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Do_An_Bai_2_Stack
{
    class ChuyenDoi
    {
        public void CD(LinkedStack stack, int n, int heso)
        {
            if (n <= 0)
            {
                Console.WriteLine(0);
            }
            
            while (n > 0)
            {
                int s = n % heso;
                NODE pTemp = stack.CreateNode(s);
                stack.Push(stack, pTemp);
                n = n / heso;
            }
            string kq = "";
            while (stack.isEmptyStack(stack) == 0)
            {
                int a = stack.Pop(stack);
                if (a >= 10 && a <= 15)
                {
                    switch (a)
                    {
                        case 10:
                            kq = "A";
                            break;
                        case 11:
                            kq = "B";
                            break;
                        case 12:
                            kq = "C";
                            break;
                        case 13:
                            kq = "D";
                            break;
                        case 14:
                            kq = "E";
                            break;
                        case 15:
                            kq = "F";
                            break;
                        default:
                            break;
                    }
                } 
                else
                {
                    kq = a.ToString();
                }
             
                Console.Write(kq);
            }
        }

        public void KiemTra(int n, LinkedStack a)
        {
            if (n == 2 || n == 8 || n == 16)
            {
                Console.Write("Nhap so muon doi: ");
                int so = int.Parse(Console.ReadLine());
                Console.Write("So {0} doi sang he {1} la: ", so, n);
                CD(a, so, n);
            }
            else
            {
                Console.WriteLine("Ban da nhap sai!!. Ung dung chuyen doi co so ket thuc");
            }
        }

        public void Run16()
        {
            LinkedStack d = new LinkedStack();
            Console.WriteLine("Ban muon doi he co so 10 sang 2 hay 8? (Nhap 2 hoac 8 hoac 16)");
            int n = int.Parse(Console.ReadLine());
            KiemTra(n,d);
            
        }
       
    }
}

