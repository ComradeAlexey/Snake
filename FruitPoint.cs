using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FruitPoint:Point
    {
        public FruitPoint(int x, int y)
        {
            X = x;
            Y = y;
            FruitPointManager.AddInList(this);
        }

        public override void ShowPoint()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('*');
        }
    }
}
