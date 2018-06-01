using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class SnakePointsManager:Point
    {
        static DirectionMove directionMove;
        static List<SnakePoint> dictionary = new List<SnakePoint>();
        static public void StartGame(int x, int y)
        {
            SnakePoint head = new SnakePoint(x, y, true);
            SnakePoint snakePoint = new SnakePoint(x, y + 1);
            SnakePoint snakePoint1 = new SnakePoint(x, y + 2);
        }

        static public void AddInList(SnakePoint thisObject)
        {
            dictionary.Add(thisObject);
        }

        static public void AddSnakeElement()
        {
            SnakePoint snakePoint = new SnakePoint(dictionary.Last().X, dictionary.Last().Y);
        }

        static public void ShowSceneSnake()
        {
            foreach (SnakePoint value in dictionary)
            {
                value.ShowPoint();
            }
        }

        static public void MoveController(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    directionMove = DirectionMove.up;
                    break;
                case ConsoleKey.S:
                    directionMove = DirectionMove.down;
                    break;
                case ConsoleKey.A:
                    directionMove = DirectionMove.left;
                    break;
                case ConsoleKey.D:
                    directionMove = DirectionMove.right;
                    break;
            }
        }

        static public void MoveSnake()
        {
            foreach(SnakePoint point in dictionary)
            {
                if (point.isHead)
                {
                    point.directionMove = directionMove;
                    point.MoveHead(directionMove);
                }
                else 
                    point.MovePointToPoint();
            }
        }

        static public SnakePoint EndElement(SnakePoint snakePoint)
        {
            if(snakePoint.isHead)
            {
                return snakePoint;
            }
            return dictionary.Last();
        }

        static public bool OnCollision()
        {
            foreach(SnakePoint value in dictionary)
            {
                if(WallPointsManager.CheckedList(value.X,value.Y))
                    return true;
            }
            return false;
        }
    }
}