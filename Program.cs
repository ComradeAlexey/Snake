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
//Спасибо Михе и Маше за моральную поддержку 