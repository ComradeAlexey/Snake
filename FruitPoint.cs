using System;
namespace Snake
{
    class FruitPoint:Point
    {
        public FruitPoint(int x, int y)
        {
            X = x;
            Y = y;
            FruitPointManager.AddInList(this);
        }

        public override void ShowPoint()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('*');
        }
    }
}
