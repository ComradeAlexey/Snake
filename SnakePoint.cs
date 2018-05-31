using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class SnakePoint:Point
    {
        public DirectionMove directionMove;
        public bool isHead;
        public SnakePoint prevPoint;
        public SnakePoint(int x, int y, bool isHEAD = false)
        {
            this.x = x;
            this.y = y;
            isHead = isHEAD;
            prevPoint = SnakePointsManager.EndElement(this);
            SnakePointsManager.AddInList(this);
        }
        public override void ShowPoint()
        {
            Console.SetCursorPosition(x, y);
            Console.Write('*');
        }

        public void MoveHead(DirectionMove _directionMove)
        {
            switch(directionMove)
            {
                case DirectionMove.up:
                    y += 1;
                    break;
                case DirectionMove.down:
                    y += -1;
                    break;
                case DirectionMove.left:
                    x += -1;
                    break;
                case DirectionMove.right:
                    x += 1;
                    break;
            }
        }

        public void MovePointToPoint()
        {
            switch (directionMove)
            {
                case DirectionMove.up:
                    x = prevPoint.x;
                    y = prevPoint.y+1;
                    break;
                case DirectionMove.down:
                    y += -1;
                    x = prevPoint.x;
                    y = prevPoint.y - 1;
                    break;
                case DirectionMove.left:
                    x += -1;
                    x = prevPoint.x - 1;
                    y = prevPoint.y;
                    break;
                case DirectionMove.right:
                    x = prevPoint.x+1;
                    y = prevPoint.y;
                    break;
            }
        }
    }
}
