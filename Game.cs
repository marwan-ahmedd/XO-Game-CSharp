using System;
using System.IO;

namespace TicTacToe
{
    class XO : Board
    {
        public XO() : base(3) {}
        public override bool updateBoard(int x, int y, char symbol)
        {
            // Code Goes Here
        }
        public override bool isWinner(char symbol)
        {
            // Code Goes Here
        }
        public override bool isDraw()
        {
            // Code Goes Here
        }
    }

    public class Launcher
    {
        static void Main(string[] args)
        {
            Player p1, p2;
            char choice;

            Console.WriteLine("Welcome to XO");
            Console.WriteLine("To start, Player 1 please write your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Now, please choose your symbol: ");
            Console.WriteLine("X           O");
            while (true)
            {
                choice = Convert.ToChar(Console.ReadLine());
                if (choice != 'X' && choice != 'O')
                {
                    Console.WriteLine("Please choose either (X) or (O)");
                    continue;
                }
                else
                {
                    break;
                }
            }
            p1 = new Player(name, choice);
            
            Console.WriteLine("Player 2 please write your name: ");
            name = Console.ReadLine();
            
            if (choice == 'X'){choice = 'O';}
            else{choice = 'X';}

            p2 = new Player(name, choice);

        }
    }

}