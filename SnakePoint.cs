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
        public int oX, oY;
        public SnakePoint(int x, int y, bool isHead = false, int oX)
        {
            this.x = x;
            this.y = y;
            oX = x;
            oY = y;
            this.isHead = isHead;
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
                    y += -1;
                    break;
                case DirectionMove.down:
                    y += 1;
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
            oX = x;
            oY = y;
            x = prevPoint.oX;
            y = prevPoint.oY;
            //switch (directionMove)
            //{
            //    case DirectionMove.up:
            //        x = prevPoint.oX;
            //        y = prevPoint.oY;
            //        break;
            //    case DirectionMove.down:
            //        x = prevPoint.x;
            //        y = prevPoint.y;
            //        break;
            //    case DirectionMove.left:
            //        x = prevPoint.x;
            //        y = prevPoint.y;
            //        break;
            //    case DirectionMove.right:
            //        x = prevPoint.x;
            //        y = prevPoint.y;
            //        break;
            //}
        }
    }
}