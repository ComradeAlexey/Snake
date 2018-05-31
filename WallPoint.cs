using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class WallPoint:Point
    {
        public WallPoint(int x,int y)
        {
            this.x = x;
            this.y = y;
            WallPointsManager.AddInList(this);
        }

        public override void ShowPoint()
        {
            Console.SetCursorPosition(x, y);
            Console.Write('*');
        }
    }
}
