using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Bai_2_Stack
{
    class NODE
    {
        public int data;
        public NODE pNext;

        public NODE(int data)
        {
            this.data = data;
            this.pNext = null;
        }

        public NODE()
        {
            this.data = new int();
            this.pNext = null;
        }
    }
}

