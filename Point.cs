using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    abstract class Point
    {
        public enum DirectionMove
        {
            up,
            down,
            left,
            right
        }

        protected int x, y;
        public virtual void ShowPoint()
        {

        }
    }
}
