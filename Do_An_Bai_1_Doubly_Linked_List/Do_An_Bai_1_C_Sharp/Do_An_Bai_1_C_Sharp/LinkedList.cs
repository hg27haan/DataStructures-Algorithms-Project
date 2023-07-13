using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Do_An_Bai_1_C_Sharp
{
    public class LinkedList
    {
        //int Dem;
        private NODE PHead;
        private NODE PTail;

        //public int dem { get => Dem; set => Dem = value; }
        public NODE pHead { get => PHead; set => PHead = value; }
        public NODE pTail { get => PTail; set => PTail = value; }

        public LinkedList()
        {
            PHead = null;
            PTail = null;
        }
        public NODE GetNewNode(SP x)
        {
            NODE a = new NODE();
            a.data = x;
            a.pNext = null;
            a.pPrev = null;
            return a;
        }
        public int SizeOfList(NODE node)
        {
            if (node == null)
                return 0;
            int count = 0;
            while (node != null)
            {
                count++;
                node = node.pNext;
            }
            return count;
        }
        public void NhapDS(LinkedList l)
        {
            Console.WriteLine("So luong san pham: ");
            int n;
            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\nBan phai nhap 1 so nguyen (int), moi ban nhap lai:  ");
                n = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                SP e = new SP();
                e.Nhap();
                l.pHead = l.ThemGiaTri(e, l.pHead);
            }
        }
        public bool IsEmptyList(LinkedList l)
        {
            NODE pNode = l.pHead;
            if (pNode == null)
            {
                return true;
            }
            return false;
        }
        public NODE ThemVaoDau(NODE head, SP data)
        {
            if (head == null)
                return GetNewNode(data);
            NODE t = GetNewNode(data);
            head.pPrev = t;
            t.pNext = head;
            return t;
        }
        public NODE ThemVaoCuoi(NODE head, SP data)
        {
            int pos = SizeOfList(head) + 1;
            if (head == null)
            {
                if (pos == 1)
                    return GetNewNode(data);
                else return null;
            }
            if (pos == 1)
            {
                NODE tmp = GetNewNode(data);
                head.pPrev = tmp;
                tmp.pNext = head;
                return tmp;
            }
            NODE node = head;
            while (node != null && pos > 2)
            {
                node = node.pNext;
                pos--;
            }
            if (node == null)
            {
                Console.WriteLine("Position is not valid");
                return head;
            }
            NODE t = GetNewNode(data);
            t.pNext = node.pNext;
            t.pPrev = node;
            if (node.pNext != null)
                node.pNext.pPrev = t;
            node.pNext = t;
            return head;
            //return ThemSauQ(head, data, SizeOfList(head)-1);
        }
        public NODE ThemSauQ(NODE head, SP data, int pos)
        {
            if (head == null)
            {
                if (pos == 1)
                    return GetNewNode(data);
                else return null;
            }
            if (pos == -1)
            {
                NODE tmp = GetNewNode(data);
                head.pPrev = tmp;
                tmp.pNext = head;
                return tmp;
            }
            NODE node = head;
            while (node != null && pos > 0)
            {
                node = node.pNext;
                pos--;
            }
            if (node == null)
            {
                Console.WriteLine("Position is not valid");
                return head;
            }
            NODE t = GetNewNode(data);
            t.pNext = node.pNext;
            t.pPrev = node;
            if (node.pNext != null)
                node.pNext.pPrev = t;
            node.pNext = t;
            return head;
        }
        public NODE ThemGiaTri(SP x, NODE node)
        {
            if (node == null)
            {
                return GetNewNode(x);
            }
            NODE head = node;
            while (node.pNext != null)
            {
                node = node.pNext;
            }
            NODE a = GetNewNode(x);
            a.pPrev = node;
            node.pNext = a;
            return head;
        }
        public NODE XoaDau(NODE head)
        {
            if (head == null)
            {
                return null;
            }
            if (head.pNext != null)
            {
                head.pNext.pPrev = null;
            }
            return head.pNext;
        }
        public NODE XoaCuoi(NODE head)
        {
            return XoaSauQ(head, SizeOfList(head) - 2);
        }
        public NODE XoaSauQ(NODE head, int pos)
        {
            if (head == null)
                return head;
            if (pos == -1)
            {
                if (head.pNext != null)
                    head.pNext.pPrev = null;
                return head.pNext;
            }
            NODE node = head;
            while (node != null && pos > -1)
            {
                node = node.pNext;
                pos--;
            }
            if (node == null)
            {
                Console.WriteLine("Element doesn't exists at given position");
                return head;
            }
            if (node.pNext != null)
                node.pNext.pPrev = node.pPrev;
            node.pPrev.pNext = node.pNext;
            return head;
        }
        public NODE XoaGiaTri(NODE head, SP data)
        {
            if (head == null)
                return head;
            if (head.data == data)
            {
                if (head.pNext != null)
                    head.pNext.pPrev = null;
                return head.pNext;
            }
            NODE node = head;
            while (node != null)
            {
                if (node.data == data)
                    break;
                node = node.pNext;
            }
            if (node == null)
            {
                Console.WriteLine("Element doesn't exists int list");
                return head;
            }
            if (node.pNext != null)
                node.pNext.pPrev = node.pPrev;
            node.pPrev.pNext = node.pNext;
            return head;
        }
        public NODE XoaGiaTri(NODE head, int data)
        {
            if (head == null)
                return head;
            if (head.data.MaSP == data)
            {
                if (head.pNext != null)
                    head.pNext.pPrev = null;
                return head.pNext;
            }
            NODE node = head;
            while (node != null)
            {
                if (node.data.MaSP == data)
                    break;
                node = node.pNext;
            }
            if (node == null)
            {
                Console.WriteLine("Element doesn't exists int list");
                return head;
            }
            if (node.pNext != null)
                node.pNext.pPrev = node.pPrev;
            node.pPrev.pNext = node.pNext;
            return head;
        }
        public int _search(NODE head_ref, string x)
        {

            // Stores head Node
            NODE temp = head_ref;

            // Stores position of the integer
            // in the doubly linked list
            int pos = 0;


            // Traverse the doubly linked list
            while (temp.data.Ten.CompareTo(x) != 0 &&
                   temp.pNext != null)
            {
                // Update pos
                pos++;
                // Update temp
                temp = temp.pNext;
            }
            // If the integer not present
            // in the doubly linked list
            if (temp.data.Ten.CompareTo(x) != 0)
                return -1;

            // If the integer present in
            // the doubly linked list
            return (pos + 1);
        }
        public int _search(NODE head_ref, int x)
        {

            // Stores head Node
            NODE temp = head_ref;

            // Stores position of the integer
            // in the doubly linked list
            int pos = 0;


            // Traverse the doubly linked list
            while (temp.data.MaSP != x &&
                   temp.pNext != null)
            {
                // Update pos
                pos++;
                // Update temp
                temp = temp.pNext;
            }
            // If the integer not present
            // in the doubly linked list
            if (temp.data.MaSP != x)
                return -1;

            // If the integer present in
            // the doubly linked list
            return (pos + 1);
        }
        public void searchNode(NODE head, int x)
        {
            int _seachNode = _search(head, x);
            if (_seachNode == -1)
                Console.WriteLine("Khong ton tai");
            else Console.WriteLine("Gia tri o vi tri: " + _seachNode);
        }
        public LinkedList searchNodesTheoTen(NODE head, string x, LinkedList result)
        {
            NODE temp = head;

            while (temp != null)
            {
                if (_search(temp, x) != -1)
                    result.pHead = result.ThemGiaTri(temp.data, result.pHead);
                temp = temp.pNext;
            }
            return result;
        }
        public void XuatDS(NODE node)
        {
            //if (node == null)
            //    return;
            while (node != null)
            {
                //Console.WriteLine(node.data + " ");
                node.data.Xuat();
                node = node.pNext;
            }
            Console.WriteLine('\n');
        }
        public void selectionSort(NODE head)
        {
            NODE temp = head;
            while (temp != null)
            {
                NODE min = temp;
                NODE r = temp.pNext;

                while (r != null)
                {
                    //min.data.MaSP > r.data.MaSP
                    if (min.data.Ten.CompareTo(r.data.Ten) > 0)
                        min = r;

                    r = r.pNext;
                }
                // Swap Data
                SP x = temp.data;
                temp.data = min.data;
                min.data = x;
                temp = temp.pNext;
            }
        }
        public void ThemCuoi(LinkedList list, NODE data)
        {
            if (list.pHead == null)
            {
                list.pHead = list.pTail = data;
            }
            else
            {
                list.pTail.pNext = data;
                data.pPrev = list.pTail;
                list.pTail = data;
            }
        }

        public void QuickSort(LinkedList l)
        {
            if (SizeOfList(l.pHead) >= 2)
            {
                LinkedList l1 = new LinkedList();
                LinkedList l2 = new LinkedList();
                NODE pivot;
                NODE p;
                pivot = l.pHead;
                p = l.pHead.pNext;
                while (p != null)
                {
                    NODE q = p;
                    p = p.pNext;
                    q.pNext = null;
                    if (q.data.MaSP < pivot.data.MaSP)
                    {
                        ThemCuoi(l1, q);
                    }
                    else
                    {
                        ThemCuoi(l2, q);
                    }
                };
                QuickSort(l1);
                QuickSort(l2);
                if (!IsEmptyList(l1))
                {
                    l.pHead = l1.pHead;
                    l1.pTail.pNext = pivot;
                }
                else
                {
                    l.pHead = pivot;
                }
                pivot.pNext = l2.pHead;
                if (!IsEmptyList(l2))
                {
                    l.pTail = l2.pTail;
                }
                else
                {
                    l.pTail = pivot;
                }
            }
            else
            {
                //return;
            }
        }
        public LinkedList combine(LinkedList L1, LinkedList L2, LinkedList result)
        {
            LinkedList L3 = new LinkedList();
            LinkedList L4 = new LinkedList();
            while (L1.pHead != null)
            {
                L3.pHead = L3.ThemVaoDau(L3.pHead, L1.pHead.data);
                L1.pHead = L1.pHead.pNext;

            }
            while (L2.pHead != null)
            {
                L3.pHead = L3.ThemVaoDau(L3.pHead, L2.pHead.data);
                L2.pHead = L2.pHead.pNext;
            }
            while (L3.pHead != null)
            {
                L4.pHead = L4.ThemVaoDau(L4.pHead, L3.pHead.data);
                L3.pHead = L3.pHead.pNext;
            }
            //while (L3.pHead != null)
            //{
            //    result.pHead = result.ThemVaoDau(L4.pHead, L3.pHead.data);
            //    L3.pHead = L3.pHead.pNext;
            //}
            while (L4.pHead != null)
            {
                result.pHead = result.ThemVaoDau(result.pHead, L4.pHead.data);
                L4.pHead = L4.pHead.pNext;
            }
            return result;
        }
        public NODE removeMaSPSatisfy(LinkedList l, int MaSP)
        {
            NODE temp = l.pHead;
            while (temp != null)
            {
                l.pHead = l.XoaGiaTri(l.pHead, MaSP);
                temp = temp.pNext;
            }
            return l.pHead;
        }
        public bool KiemTraNgay(DATE d1, DATE d2)
        {
            if (d2.year > d1.year)
                return true;
            else if (d2.year == d1.year)
            {
                if (d2.month > d1.month)
                    return true;
                else if (d2.month == d1.month)
                {
                    if (d2.day > d1.day)
                        return true;
                }
            }
            return false;
        }
        public LinkedList DSSPSauNgayXuatKho(NODE head, DATE date, LinkedList result)
        {
            NODE temp = head;

            while (temp != null)
            {
                if (KiemTraNgay(date, temp.data.NgayXuatKho) == true)
                {
                    result.pHead = ThemVaoDau(result.pHead, temp.data);
                }
                temp = temp.pNext; ;
            }
            return result;

        }
        public int Menu()
        {
            Console.Write("\n================================= QUAN LY SAN PHAM CUA CUA HANG ==========================================\n");
            Console.Write("|                                                                                                          |\n");
            Console.Write("|                        1. Nhap Danh Sach                                                                 |\n");
            Console.Write("|                        2. Xuat Danh Sach                                                                 |\n");
            Console.Write("|                        3. Chen Them San Pham Vao Dau Danh Sach                                           |\n");
            Console.Write("|                        4. Chen Them San Pham Vao Cuoi Danh Sach                                          |\n");
            Console.Write("|                        5. Chen Them San Pham Vao Sau 1 Vi Tri Bat Ky                                     |\n");
            Console.Write("|                        6. Xoa San Pham O Vi Tri Dau Danh Sach                                            |\n");
            Console.Write("|                        7. Xoa San Pham O Vi Tri Cuoi Danh Sach                                           |\n");
            Console.Write("|                        8. Xoa San Pham O Sau 1 Vi Tri Bat Ky                                             |\n");
            Console.Write("|                        9. Tim 1 San Pham Theo Ma SP                                                      |\n");
            Console.Write("|                        10. Xuat Danh Sach San Pham Cung Ten                                              |\n");
            Console.Write("|                        11. Sap Xep Danh Sach San Pham Theo Alphabet (Selection Sort)                     |\n");
            Console.Write("|                        12. Sap Xep Danh Sach San Pham Theo Ma SP (Quick Sort)                            |\n");
            Console.Write("|                        13. Gop 2 Danh Sach                                                               |\n");
            Console.Write("|                        14. Xuat Danh Sach San Pham Da Xuat Kho Theo Ngay Da Nhap                         |\n");
            Console.Write("|                        15. Xoa Tat Ca San Pham Tu Ma SP Da Nhap                                          |\n");
            Console.Write("|                                                                                                          |\n");
            Console.Write("============================================================================================================\n");
            Console.Write("\nBan chon:  ");
            int choose;
            try
            {
                choose = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\nMoi ban nhap dung dinh dang so nguyen (int)!");
                Console.Write("\nBan chon:  ");
                choose = int.Parse(Console.ReadLine());
            }
            return choose;
        }
        public void ThucHien()
        {
            LinkedList a = new LinkedList();
            LinkedList DSXK = new LinkedList();
            while (true)
            {
                int choose = a.Menu();
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("\n1. Nhap Danh Sach\n");
                        a.NhapDS(a);
                        break;
                    case 2:
                        Console.WriteLine("\n2. Xuat Danh Sach\n");
                        a.XuatDS(a.pHead);
                        break;
                    case 3:
                        Console.WriteLine("\n3. Chen Them San Pham Vao Dau Danh Sach\n");
                        SP inserSPAtStart = new SP();
                        inserSPAtStart.Nhap();
                        a.pHead = a.ThemVaoDau(a.pHead, inserSPAtStart);
                        break;
                    case 4:
                        Console.WriteLine("\n4. Chen Them San Pham Vao Cuoi Danh Sach\n");
                        SP inserSPAtLast = new SP();
                        inserSPAtLast.Nhap();
                        a.pHead = a.ThemVaoCuoi(a.pHead, inserSPAtLast);
                        break;
                    case 5:
                        Console.WriteLine("\n5. Chen Them San Pham Vao Sau 1 Vi Tri Bat Ky\n");
                        SP insertAtPosition = new SP();
                        int pos5;
                        try
                        {
                            pos5 = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nNhap lai vi tri: , moi ban nhap lai");
                            pos5 = int.Parse(Console.ReadLine());
                        }
                        insertAtPosition.Nhap();
                        a.pHead = a.ThemSauQ(a.pHead, insertAtPosition, pos5);
                        break;
                    case 6:
                        Console.WriteLine("\n6. Xoa San Pham O Vi Tri Dau Danh Sach\n");
                        a.pHead = a.XoaDau(a.pHead);
                        if(a.pHead == null)
                            Console.WriteLine("Danh sach rong");
                        break;
                    case 7:
                        Console.WriteLine("\n6. Xoa San Pham O Vi Tri Cuoi Danh Sach\n");
                        a.pHead = a.XoaCuoi(a.pHead);
                        if (a.pHead == null)
                            Console.WriteLine("Danh sach rong");
                        break;
                    case 8:
                        Console.WriteLine("\n8. Xoa San Pham O Sau 1 Vi Tri Bat Ky\n");
                        int pos8;
                        try
                        {
                            pos8 = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nNhap lai vi tri: , moi ban nhap lai");
                            pos8 = int.Parse(Console.ReadLine());
                        }
                        a.pHead = a.XoaSauQ(a.pHead, pos8);
                        if (a.pHead == null)
                            Console.WriteLine("Danh sach rong");
                        break;
                    case 9:
                        Console.WriteLine("\n9. Tim 1 San Pham Theo Ma Hang\n");
                        int maHang9;
                        try
                        {
                            maHang9 = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nNhap lai vi tri: , moi ban nhap lai");
                            maHang9 = int.Parse(Console.ReadLine());
                        }
                        a.searchNode(a.pHead, maHang9);
                        break;
                    case 10:
                        Console.WriteLine("\n10. Xuat Danh Sach San Pham Cung Ten\n");
                        string ten10 = Console.ReadLine();
                        LinkedList searchNodes10 = new LinkedList();
                        searchNodes10 = a.searchNodesTheoTen(a.pHead, ten10, searchNodes10);
                        int sizeSearchNodes = SizeOfList(searchNodes10.pHead);
                        if (sizeSearchNodes == 0)
                            Console.WriteLine("Khong co san pham cung ten");
                        else
                        { searchNodes10.XuatDS(searchNodes10.pHead); }
                        break;
                    case 11:
                        Console.WriteLine("\n11. Sap Xep Danh Sach San Pham Theo Alphabet (Selection Sort)\n");
                        a.selectionSort(a.pHead);
                        break;
                    case 12:
                        Console.WriteLine("\n12. Sap Xep Danh Sach San Pham Theo Ma Hang (Quick Sort)\n");
                        a.QuickSort(a);
                        break;
                    case 13:
                        Console.WriteLine("\n13. Gop 2 Danh Sach\n");
                        LinkedList l = new LinkedList();
                        l.NhapDS(l);
                        a.combine(a, l, a);
                        break;
                    case 14:
                        Console.WriteLine("\n14. Lay Danh Sach San Pham Da Xuat Kho Theo Ngay Da Nhap\n");
                        Console.Write("Nhap ngay: ");
                        int day14 = int.Parse(Console.ReadLine());
                        Console.Write("Nhap thang: ");
                        int month14 = int.Parse(Console.ReadLine());
                        Console.Write("Nhap nam: ");
                        int year14 = int.Parse(Console.ReadLine());
                        DATE date14 = new DATE(month14, day14, year14);
                        a.DSSPSauNgayXuatKho(a.pHead, date14, DSXK);
                        DSXK.XuatDS(DSXK.pHead);
                        break;
                    case 15:
                        Console.WriteLine("\n15. Xoa Tat Ca San Pham Tu Ma Hang Da Nhap\n");
                        Console.Write("Nhap ma san pham muon xoa: ");
                        int maHang15;
                        try
                        {
                            maHang15 = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nMoi ban nhap lai ma san pham: ");
                            maHang15 = int.Parse(Console.ReadLine());
                        }
                        a.pHead = a.removeMaSPSatisfy(a, maHang15);
                        a.XuatDS(a.pHead);
                        break;
                }
            }
        }
    }
}
