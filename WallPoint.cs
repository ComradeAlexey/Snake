using System;
namespace Snake
{
    class WallPoint:Point
    {
        public WallPoint(int x,int y)
        {
            this.X = x;
            this.Y = y;
            WallPointsManager.AddInList(this);
        }

        public override void ShowPoint()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('*');
        }
    }
}
