using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    abstract class Point
    {
        private int y;
        private int x;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public virtual void ShowPoint()
        {

        }
    }
}
