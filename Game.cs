using System;
using System.Threading;

namespace Snake
{
    class Game
    {
        static public void StartGame()
        {
            WallPointsManager.BuildSceneWalls(0, 0, 79, 79);
            SnakePointsManager.StartGame(10, 10);
        }
        static public void Update()
        {
            while (true)
            {
                Thread.Sleep(100);
                SnakePointsManager.MoveController();
                Console.Clear();
                SnakePointsManager.MoveSnake();
                WallPointsManager.ShowSceneWalls();
                SnakePointsManager.ShowSceneSnake();
            }
        }
    }
}
