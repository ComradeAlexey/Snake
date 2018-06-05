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
            WallPointsManager.ShowSceneWalls();
            FruitPointManager.GenerateFruits();
        }
        static public void Update()
        {

            while (!SnakePointsManager.OnCollision())
            {
                if (Console.KeyAvailable)
                {
                    
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    SnakePointsManager.MoveController(key);
                }
                Thread.Sleep(100);
                SnakePointsManager.MoveSnake();
                Console.ForegroundColor = ConsoleColor.Red;
                FruitPointManager.ShowSceneFruit();

                Console.ForegroundColor = ConsoleColor.White;
                SnakePointsManager.ShowSceneSnake();
            }
        }
    }
}
