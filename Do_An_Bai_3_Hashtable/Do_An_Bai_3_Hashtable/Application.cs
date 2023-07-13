using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Do_An_Bai_3_Hashtable
{
    class Application
    {
       
        private const int M = 149;

        public int HashFunc(string a)
        {
            int h = 0;
            for (int i = 0; i < a.Length; i++)
            {
                h = h + (int)char.ToLower(a[i]) * (i + 1);
            }
            return h % M;
        }
        public int Hash(Tu w)
        {
            return HashFunc(w.tu);
        }

        public void ThemCuoiNode(Linked_List list, NODE node)
        {
            NODE pCheck = list.pHead;
            if (pCheck == null)
            {
                list.pHead = list.pTail = node;
            }
            else
            {
                while (pCheck.pNext != null)
                {
                    if (pCheck.word.tu.CompareTo(node.word.tu)==0 && pCheck.word.loai.CompareTo(node.word.loai) == 0)
                    {
                        Console.WriteLine("\nTu nay da ton tai!");
                        break;
                    }
                    else
                    {
                        pCheck = pCheck.pNext;
                    }
                }
                if (pCheck.word.tu.CompareTo(node.word.tu) != 0 || pCheck.word.tu.CompareTo(node.word.loai) == 0 && pCheck.word.tu.CompareTo(node.word.loai) != 0)
                {
                    pCheck.pNext = node;
                    list.pTail = node;
                }
            }
        }

        public void Add(HashTable bangBam, Tu w)
        {
            int h = Hash(w);
            NODE pTemp = new NODE();
            pTemp = pTemp.CreateNode(w);
            ThemCuoiNode(bangBam.hashtable[h], pTemp);
        }

        public void TimNode(Linked_List list, NODE node)
        {
            NODE pCheck = list.pHead;
            int d = 0;
            while (pCheck != null)
            {
                if(pCheck.word.tu.CompareTo(node.word.tu)==0)
                {
                    Console.WriteLine("\n- ({0}): {1}", pCheck.word.loai, pCheck.word.nghia);
                    d++;
                    break;
                }
                pCheck = pCheck.pNext;
            }
            if (d == 0)
            {
                Console.WriteLine("\nTu nay khong co trong tu dien");
            }
        }

        public void Search(HashTable bangBam, Tu w)
        {
            int h = Hash(w);
            if (bangBam.hashtable[h].pHead == null)
            {
                Console.WriteLine("\nTu nay khong the tim vi khong co trong tu dien!");
            }
            else
            {
                NODE pTemp = new NODE();
                pTemp = pTemp.CreateNode(w);
                TimNode(bangBam.hashtable[h], pTemp);
            }
        }

        public void XoaNode(Linked_List list, NODE node)
        {
            NODE pCheck = list.pHead;
            NODE pTruoc = null;
            int d = 0;
            while (pCheck != null)
            {
                if (pCheck.word.tu.CompareTo(node.word.tu)==0 && pCheck.word.loai.CompareTo(node.word.loai)==0)
                {
                    if (pTruoc == null)//remove pHead
                    {
                        list.pHead = list.pHead.pNext;
                        pCheck.pNext = null;
                    }
                    else
                    {
                        pTruoc.pNext = pCheck.pNext;
                        pCheck.pNext = null;

                    }
                    pCheck = null;
                    d++;
                    break;
                }
                pTruoc = pCheck;
                pCheck = pCheck.pNext;
            }
            if (d == 0)
            {
                Console.WriteLine("\nTu vung nay chua duoc them vao trong tu dien nen khong the xoa");
            }
        }

        public void Delete(HashTable bangBam, Tu w)
        {
            int h = Hash(w);
            if (bangBam.hashtable[h].pHead == null)
            {
                Console.WriteLine("\nKhong the xoa vi khong ton tai tu nay!");
            }
            else
            {
                NODE pTemp = new NODE();
                pTemp = pTemp.CreateNode(w);
                XoaNode(bangBam.hashtable[h],pTemp);
            }
        }

        public void SuaNode(Linked_List list, NODE node)
        {
            NODE pCheck = list.pHead;
            int d = 0;
            while (pCheck != null)
            {
                if (pCheck.word.tu.CompareTo(node.word.tu)==0 && pCheck.word.loai.CompareTo(node.word.loai)==0)
                {
                    pCheck.word.nghia = node.word.nghia;
                    d++;
                    break;
                }
                else
                {
                    pCheck = pCheck.pNext;
                }
            }
            if (d == 0)
            {
                Console.WriteLine("\nTu khong the cap nhat do khong ton tai trong tu dien!");
            }
        }

        public void Update(HashTable bangBam, Tu w)
        {
            int h = Hash(w);
            if (bangBam.hashtable[h].pHead == null)
            {
                Console.WriteLine("\nKhong the cap nhat vi tu khong ton tai trong tu dien!");
            }
            else
            {
                NODE pTemp = new NODE();
                pTemp = pTemp.CreateNode(w);
                SuaNode(bangBam.hashtable[h], pTemp);
            }
        }

        public void XuatNode(Linked_List list)
        {
            NODE pCheck = list.pHead;
            while (pCheck != null)
            {
                Console.WriteLine("- {0} ({1}): {2}", pCheck.word.tu, pCheck.word.loai, pCheck.word.nghia);
                pCheck = pCheck.pNext;
            }
        }

        public void XuatTuDien(HashTable bangBam)
        {
            for (int i = 0; i < M; i++)
            {
                if (bangBam.hashtable[i].pHead != null)
                {
                    Console.WriteLine("\nkey {0}", i.ToString());
                    XuatNode(bangBam.hashtable[i]);
                }
            }
        }

        public void ReadFile(HashTable bangBam)
        {
            
            FileStream f = new FileStream("C:\\Users\\ADMIN\\Downloads\\DoAn\\Do_An_CTDL\\Do_An_Bai_3_Hashtable\\Text.txt", FileMode.Open);
            StreamReader a = new StreamReader(f, Encoding.UTF8);
            int dem = 0;
            while (dem <= M - 1)
            {
                Tu q = new Tu();
                q.tu = a.ReadLine();
                q.loai = a.ReadLine();
                q.nghia = a.ReadLine();
                Add(bangBam, q);
                dem++;
            }
            a.Close();
        }
    }
}
