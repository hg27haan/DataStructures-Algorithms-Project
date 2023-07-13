using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Bai_2_Stack
{
    class GiaiThua
    {
        LinkedStack a = new LinkedStack();
        public int GT(int n)
        {
            if (n < 0)
            {
                Console.WriteLine("Nhap gia tri nho hon 0, khong tinh duoc, tra ve 1");
                 return 1;
            }
            
            a.InitStack(a);
            while(n!= 0)
            {
                NODE p = a.CreateNode(n);
                a.Push(a, p);
                n = n - 1;
            }
            int kq = 1;
            while(a.isEmptyStack(a) == 0)
            {
                int temp = a.Pop(a);
                kq = kq * temp;
            }
            return kq;  
        }

        public void Run()
        {
            int n, kq;
            Console.WriteLine("Nhap n: ");
            n = int.Parse(Console.ReadLine());
            kq = GT(n);
            Console.WriteLine("{0}" + "! = " + "{1}",n, kq);
        }
    }
}
