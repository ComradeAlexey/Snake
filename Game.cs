using System;
using System.Threading;

namespace Snake
{
    class Game
    {
        static public void StartGame()
        {
            WallPointsManager.BuildSceneWalls(0, 0, 79, 79);
            SnakePointsManager.StartGame(10, 40);
        }
        static public void Update()
        {
            while (!SnakePointsManager.OnCollision())
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    
                    SnakePointsManager.MoveController(key);
                }
                Thread.Sleep(100);
                SnakePointsManager.MoveSnake();
                Console.Clear();
                WallPointsManager.ShowSceneWalls();
                SnakePointsManager.ShowSceneSnake();
            }
        }
    }
}
