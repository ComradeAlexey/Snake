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


        public static void StartGame(int x, int y)
        {
            SnakePoint head = new SnakePoint(x, y, true);
            AddSnakeElement();
        }

        public static void AddInList(SnakePoint thisObject)
        {
            dictionary.Add(thisObject);
        }

        public static void AddSnakeElement()
        {
            switch(directionMove)
            {
                case DirectionMove.up:
                    {
                        SnakePoint snakePoint1 = new SnakePoint(dictionary.Last().X, dictionary.Last().Y - 1);
                    }
                    break;
                case DirectionMove.down:
                    {
                        SnakePoint snakePoint1 = new SnakePoint(dictionary.Last().X, dictionary.Last().Y + 1);
                    }
                    break;
                case DirectionMove.left:
                    {
                        SnakePoint snakePoint1 = new SnakePoint(dictionary.Last().X - 1, dictionary.Last().Y);
                    }
                    break;
                case DirectionMove.right:
                    {
                        SnakePoint snakePoint1 = new SnakePoint(dictionary.Last().X + 1, dictionary.Last().Y);
                    }
                    break;
            }
        }

        public static void ShowSceneSnake()
        {
            foreach (SnakePoint value in dictionary)
            {
                if (value.isHead)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else
                    Console.ForegroundColor = ConsoleColor.Green;
                value.ShowPoint();
            }
        }

        public static void MoveController(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    if (directionMove != DirectionMove.down)
                    {
                        directionMove = DirectionMove.up;
                    }
                    break;
                case ConsoleKey.S:
                    if (directionMove != DirectionMove.up)
                    {
                        directionMove = DirectionMove.down;
                    }
                    break;
                case ConsoleKey.A:
                    if (directionMove != DirectionMove.right)
                    {
                        directionMove = DirectionMove.left;
                    }
                    break;
                case ConsoleKey.D:
                    if (directionMove != DirectionMove.left)
                    {
                        directionMove = DirectionMove.right;
                    }
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

        static public SnakePoint HeadElement()
        {
            return dictionary.First();
        }

        static public bool OnCollisionWalls()
        {
            foreach(SnakePoint value in dictionary)
            {
                if(WallPointsManager.CheckedList(value.X,value.Y))
                    return true;
            }
            return false;
        }

        static public bool OnCollisionSelf()
        {
            for(int i = 0;i < dictionary.Count;i++)
            {
                if (CheckedList(dictionary[i].X, dictionary[i].Y,i))
                    return true;
            }
            return false;
        }

        static public bool OnCollisionFruits()
        {
            if (FruitPointManager.CheckedList(HeadElement().X, HeadElement().Y))
                return true; return false;
        }
        static public void EatingFruit()
        {
            FruitPointManager.CheckedList(HeadElement().X, HeadElement().Y, out FruitPoint fruitPoint,out int i);
            if(fruitPoint != null)
            {
                FruitPointManager.DeleteElement(i);
                FruitPointManager.GenerateFruits();
                FruitPointManager.ShowSceneFruit();
                AddSnakeElement();
            }
        }
        static public bool CheckedList(int x, int y)
        {
            foreach (SnakePoint value in dictionary)
            {
                if (value.X == x && value.Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        static public bool CheckedList(int x, int y, int self)
        {
            for(int i = 0;i < dictionary.Count;i++)
            {
                if(i != self)
                {
                    if (dictionary[i].X == x && dictionary[i].Y == y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}