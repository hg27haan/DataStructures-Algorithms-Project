using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Bai_3_Hashtable
{
    class NODE
    {
        public Tu word;
        public NODE pNext;

        public NODE() { }

        public NODE CreateNode(Tu word)
        {
            NODE p = new NODE();
            p.word = word;
            p.pNext = null;
            return p;
        }
    }
}
