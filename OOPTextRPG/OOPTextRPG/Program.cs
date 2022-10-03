using System;

namespace ConsoleApp3
{

    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();
            while(true)
            {
                game.Process();
            }
        }
    }
}
