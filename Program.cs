using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum DirectionMove
    {
        up,
        down,
        left,
        right
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game.StartGame();
            Game.Update();
        }
    }
}
