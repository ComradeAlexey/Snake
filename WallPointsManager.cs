using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class WallPointsManager
    {
        static int width, height;
        static List<WallPoint> dictionary = new List<WallPoint>();

        public static int Width { get => width; set => width = value; }
        public static int Height { get => height; set => height = value; }

        public static void AddInList(WallPoint thisObject)
        {
            dictionary.Add(thisObject);
        }
        public static void BuildSceneWalls(int x0,int y0, int width,int height)
        {
            Width = width;
            Height = height;
            for(int x = x0;x < x0 + width ; x++ )
            {
                WallPoint wallPoint = new WallPoint(x, y0);
            }
            for (int y = y0; y < y0 + height; y++)
            {
                WallPoint wallPoint = new WallPoint(x0, y);
            }
            for (int x = x0; x < x0 + width; x++)
            {
                WallPoint wallPoint = new WallPoint(x, y0 + height - 1);
            }
            for (int y = y0; y < y0 + height; y++)
            {
                WallPoint wallPoint = new WallPoint(x0 + width - 1, y);
            }
        }
        public static void ShowSceneWalls()
        {
            foreach (WallPoint value in dictionary)
            {
                value.ShowPoint();
            }
        }
        public static bool CheckedList(int x, int y)
        {
            foreach (WallPoint value in dictionary)
            {
                if(value.X == x && value.Y == y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}