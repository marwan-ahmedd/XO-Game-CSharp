using System;
using System.IO;

namespace TicTacToe
{
    public class Launcher
    {
        static void Main(string[] args)
        {
            XO Board = new XO();
            Player[] Players = new Player[2];
            char sym;

            Console.WriteLine("Welcome to XO");
            Console.WriteLine("To start, Player 1 please write your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Now, please choose your symbol: (X) or (O)");
            while (true)
            {
                sym = char.ToUpper(Convert.ToChar(Console.ReadLine())); 
                if (sym != 'X' && sym != 'O')
                {
                    Console.WriteLine("Please choose either (X) or (O)");
                    continue;
                }
                else {break;}
            }
            Players[0] = new Player(name, sym);
            
            Console.WriteLine("Player 2 please write your name: ");
            name = Console.ReadLine();
            
            if (sym == 'X') {sym = 'O';}
            else {sym = 'X';}
            Players[1] = new Player(name, sym);

            Game Launcher = new Game(Board, Players);
            Launcher.playGame();
        }
    }

}