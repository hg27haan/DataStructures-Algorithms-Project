using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Bai_2_Stack
{
    class LinkedStack
    {
        public NODE Top;
        public void InitStack(LinkedStack stack) //khoi tao Stack
        {
            this.Top = null;
        }


        public int isEmptyStack(LinkedStack stack) //kiem tra ngan xep rong
        {
            if (stack.Top == null)
            {
                return 1; // Stack rong
            }
            return 0;
        }

        public NODE CreateNode(int data) //Tao Node moi
        {
            NODE pNODE = new NODE();
            if (pNODE == null)
            {
                Console.WriteLine("\n Khong du bo nho");
                return null;
            }
            pNODE.data = data;
            pNODE.pNext = null;
            return pNODE;
        }
        public void Push(LinkedStack stack, NODE pNODE)
        {
            pNODE.pNext = stack.Top;
            stack.Top = pNODE;
        }
        public int top(LinkedStack stack)
        {
            return stack.Top.data;
        }

        public int Pop(LinkedStack stack)
        {
            NODE pTemp = stack.Top;
            int t = stack.Top.data;
            stack.Top = stack.Top.pNext;
            pTemp.pNext = null;
            pTemp = null;
            return t;
        }
        public void printStack(LinkedStack stack)
        {
            NODE pTemp = stack.Top;
            // Console.WriteLine("\nStack hien tai co {0} San Pham", stack.SizeStack(stack).ToString());
            int i = 1;
            if (pTemp == null)
            {
                Console.WriteLine("\nStack rong");
            }
            while (pTemp != null)
            {
                //Console.WriteLine("(No: so cua SP trong Stack; Vi tri: thu tu cua SP trong Stack)\n");

                Console.WriteLine("\nNo {0} - Vi tri {1}", i.ToString(), (i - 1).ToString());
                Console.WriteLine(pTemp.data);
                pTemp = pTemp.pNext;
                i++;
            }
        }
        public int SizeStack(LinkedStack stack)
        {
            NODE pTemp = stack.Top;
            if (pTemp == null)
            {
                return 0;
            }
            int size = 0;
            while (pTemp != null)
            {
                pTemp = pTemp.pNext;
                size += 1;
            }
            return size;
        }

    }
}
