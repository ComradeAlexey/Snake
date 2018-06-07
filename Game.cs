using System;
using System.Threading;
namespace Snake
{
    class Game
    {
        private static int updateTime = 200;

        public static int UpdateTime
        {
            get
            {
                return updateTime;
            }
            set
            {
                if(updateTime >= 55)
                {
                    updateTime -= value;
                }
            }
        }

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
                Thread.Sleep(UpdateTime);
                Console.ForegroundColor = ConsoleColor.Red;
                SnakePointsManager.EatingFruit();
                SnakePointsManager.MoveSnake();
                
                Console.ForegroundColor = ConsoleColor.White;
                SnakePointsManager.ShowSceneSnake();
            }
        }
    }
}
