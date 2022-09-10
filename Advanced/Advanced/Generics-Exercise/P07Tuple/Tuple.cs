using System;
using System.Collections.Generic;
using System.Text;

namespace P07Tuple
{
    public class Tuple<TItem1, TItem2>
    {
        private TItem1 item1;
        private TItem2 item2;
        public TItem1 Item1 
        {
            get
            {
                return this.item1;
            }
            set
            {
                this.item1 = value;
            }
        }
        public TItem2 Item2
        {
            get
            {
                return this.item2;
            }
            set
            {
                this.item2 = value;
            }
        }
    }
}
