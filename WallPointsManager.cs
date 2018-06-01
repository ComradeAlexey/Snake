using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class WallPointsManager
    {
        static List<WallPoint> dictionary = new List<WallPoint>();
        static public void AddInList(WallPoint thisObject)
        {
            dictionary.Add(thisObject);
        }
        static public void BuildSceneWalls(int x0,int y0, int width,int height)
        {
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
        static public void ShowSceneWalls()
        {
            foreach (WallPoint value in dictionary)
            {
                value.ShowPoint();
            }
        }
        static public bool CheckedList(int x, int y)
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