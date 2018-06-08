using System;
using System.Threading;
namespace Snake
{
    class Game
    {
        private static int updateTime = 200;
        private static bool pause = true;
        public static int numFruitsEat = 0;
        public static int UpdateTime
        {
            get
            {
                return updateTime;
            }
            set
            {
                if (updateTime >= 55)
                {
                    updateTime = value;
                }
            }
        }
        public static void ShowLabel(string text, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
        static public void CheckKeyPressed(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Escape)
            {
                if (!pause)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    ShowLabel("Please press key \" ESC\" for continue game", 20, 20);
                    pause = true;
                }
                else
                {
                    ShowLabel("                                           ", 20, 20);
                    pause = false;
                }
            }
        }

        static public void StartGame()
        {


            WallPointsManager.BuildSceneWalls(0, 0, 79, 79);
            SnakePointsManager.StartGame(10, 40);
            WallPointsManager.ShowSceneWalls();
            Console.ForegroundColor = ConsoleColor.Red;
            ShowLabel("Нажмите \"Escape\" чтобы начать игру", 20, 20);
            ShowLabel("Чтобы поставить игру на паузу нажмите \"Escape\"", 20, 21);
            ShowLabel("Чтобы убрать паузу нажмите \"Escape\"", 20, 22);
            ShowLabel("Чтобы принудительно закончить игру нажмите \"Space\"",20,23);
            Console.SetWindowSize(79, 79);
            Console.SetWindowPosition(0, 0);
            Console.SetBufferSize(79, 79);
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {

            }
            pause = !pause;
            ShowLabel("                                                        ", 20, 20);
            ShowLabel("                                                        ", 20, 21);
            ShowLabel("                                                        ", 20, 22);
            ShowLabel("                                                        ", 20, 23);
            FruitPointManager.GenerateFruits();
            FruitPointManager.ShowSceneFruit();

        }
        static public void Update()
        {
            ConsoleKeyInfo key;
            key = new ConsoleKeyInfo();
            while (key.Key != ConsoleKey.Spacebar &&!SnakePointsManager.OnCollisionWalls() & !SnakePointsManager.OnCollisionSelf())
            {
                if (Console.KeyAvailable)
                {

                    key = Console.ReadKey(true);
                    CheckKeyPressed(key);
                    if (!pause)
                    {
                        SnakePointsManager.MoveController(key);
                    }
                }
                if (!pause)
                {
                    Thread.Sleep(UpdateTime);
                    Console.ForegroundColor = ConsoleColor.Red;
                    SnakePointsManager.EatingFruit();
                    SnakePointsManager.MoveSnake();
                    Console.ForegroundColor = ConsoleColor.White;
                    SnakePointsManager.ShowSceneSnake();
                }
            }
        }

        static public void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            ShowLabel("Спасибо за то что потратили время и поиграли в эту игру", 15, 20);
            ShowLabel("Вы съели столько фруктов = " + numFruitsEat, 15, 21);
            ShowLabel("-------------------------------------------------------", 15, 22);
            ShowLabel("Хотелось бы выразить благодарность следующим людям :", 15, 23);
            ShowLabel("    1)Михаилу Корбуту", 15, 24);
            ShowLabel("    2)Марии Йоффе", 15, 25);
            ShowLabel("    3)Всей команде CDRG", 15, 26);
            ShowLabel("    За то что Вы есть и вдохновляете меня на новые свершения", 15, 27);
            ShowLabel("Нажмите любую кнопку для продолжения",15,30);
            Console.ReadKey();
        }
    }
}