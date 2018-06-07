using System;
using System.Threading;

namespace Snake
{
    class Game
    {
        static public int updateTime = 200;
        static public void StartGame()
        {
            WallPointsManager.BuildSceneWalls(0, 0, 79, 79);
            SnakePointsManager.StartGame(10, 40);
            WallPointsManager.ShowSceneWalls();
            Console.ForegroundColor = ConsoleColor.Red;
            FruitPointManager.GenerateFruits();
            FruitPointManager.ShowSceneFruit();
        }
        static public void Update()
        {

            while (!SnakePointsManager.OnCollisionWalls() & !SnakePointsManager.OnCollisionSelf())
            {
                if (Console.KeyAvailable)
                {
                    
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    SnakePointsManager.MoveController(key);
                }
                Thread.Sleep(updateTime);
                Console.ForegroundColor = ConsoleColor.Red;
                SnakePointsManager.EatingFruit();
                SnakePointsManager.MoveSnake();
                
                Console.ForegroundColor = ConsoleColor.White;
                SnakePointsManager.ShowSceneSnake();
            }
        }
    }
}
