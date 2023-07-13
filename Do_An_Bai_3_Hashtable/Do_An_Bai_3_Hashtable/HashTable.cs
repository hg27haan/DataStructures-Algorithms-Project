using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;


namespace Do_An_Bai_3_Hashtable
{
    class HashTable
    {
        public const int M = 149;
        public Linked_List[] hashtable;

        public HashTable()
        {
            hashtable = new Linked_List[M];
            for (int i = 0; i < M; i++)
            {
                hashtable[i] = new Linked_List();
            }
        }

    }
}
