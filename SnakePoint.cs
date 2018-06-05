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
        public SnakePoint(int x, int y, bool isHead = false)
        {
            X = x;
            Y = y;
            this.isHead = isHead;
            prevPoint = SnakePointsManager.EndElement(this);
            SnakePointsManager.AddInList(this);
        }
        public override void ShowPoint()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('*');
        }

        public void HidePoint()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }

        public void MoveHead(DirectionMove _directionMove)
        {
            HidePoint();
            oX = X;
            oY = Y;
            switch (directionMove)
            {
                case DirectionMove.up:
                    Y += -1;
                    break;
                case DirectionMove.down:
                    Y += 1;
                    break;
                case DirectionMove.left:
                    X += -1;
                    break;
                case DirectionMove.right:
                    X += 1;
                    break;
            }
            ShowPoint();
        }

        public void MovePointToPoint()
        {
            HidePoint();
            oX = X;
            oY = Y;
            X = prevPoint.oX;
            Y = prevPoint.oY;
            ShowPoint();
        }
    }
}