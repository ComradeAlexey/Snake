using System;
using System.Collections.Generic;
namespace Snake
{
    class FruitPointManager
    {
        public static int maxLenghtDictionary = 1;
        static List<FruitPoint> dictionary = new List<FruitPoint>();

        public static void AddInList(FruitPoint thisObject)
        {
            dictionary.Add(thisObject);
        }

        public static void AddFruitElement(int x,int y)
        {
            FruitPoint fruitPoint = new FruitPoint(x,y);
        }

        public static void GeneratePoint()
        {
            int x, y;
            Random random = new Random();
            x = random.Next(1, WallPointsManager.Width - 1);
            y = random.Next(1, WallPointsManager.Height - 1);
            if(!SnakePointsManager.CheckedList(x,y) && !WallPointsManager.CheckedList(x,y) && !CheckedList(x, y))
            {
                FruitPoint fruitPoint = new FruitPoint(x,y);
            }
            else
            {
                GeneratePoint();
            }
        }
        public static void GenerateFruits()
        {
            for(int i = dictionary.Count; i < maxLenghtDictionary;i++)
            {
                GeneratePoint();
            }
        }
        public static void DeleteElement(int thisElement)
        {
            dictionary.RemoveAt(thisElement);
        }
        public static void ShowSceneFruit()
        {
            foreach (FruitPoint value in dictionary)
            {
                value.ShowPoint();
            }
        }

        public static bool CheckedList(int x, int y)
        {
            foreach (FruitPoint value in dictionary)
            {
                if (value.X == x && value.Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        public static void CheckedList(int x, int y, out FruitPoint fruitPoint, out int thisElement)
        {
            for(int i = 0;i < dictionary.Count;i++)
            {
                if (dictionary[i].X == x && dictionary[i].Y == y)
                {
                    fruitPoint = dictionary[i];
                    thisElement = i;
                    return;
                }
            }
            fruitPoint = null;
            thisElement = 0;
        }


    }
}
