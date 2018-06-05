using System;
using System.Collections.Generic;


namespace Snake
{
    class FruitPointManager
    {
        static public int maxLenghtDictionary = 20;
        static List<FruitPoint> dictionary = new List<FruitPoint>();

        static public void AddInList(FruitPoint thisObject)
        {
            dictionary.Add(thisObject);
        }

        static public void AddFruitElement(int x,int y)
        {
            FruitPoint fruitPoint = new FruitPoint(x,y);
        }

        static public void GeneratePoint()
        {
            int x, y;
            Random random = new Random();
            x = random.Next(WallPointsManager.Height);
            y = random.Next(WallPointsManager.Width);

            if(!(SnakePointsManager.CheckedList(x,y) && WallPointsManager.CheckedList(x,y) && CheckedList(x, y)))
            {
                FruitPoint fruitPoint = new FruitPoint(x,y);
            }
            else
            {
                GeneratePoint();
            }
        }
        static public void GenerateFruits()
        {
            for(int i = 0; i < maxLenghtDictionary;i++)
            {
                GeneratePoint();
            }
        }
        static public void ShowSceneFruit()
        {
            foreach (FruitPoint value in dictionary)
            {
                value.ShowPoint();
            }
        }

        static public bool CheckedList(int x, int y)
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
    }
}
