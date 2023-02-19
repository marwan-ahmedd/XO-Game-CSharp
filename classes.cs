using System;

namespace TicTacToe 
{
    abstract class Board {
        protected int n;
        protected char[,] grid;

        public Board(int N)
        {
            n = N;
            grid = new char[n, n];
        }

        public abstract bool updateBoard(int x, int y, char symbol);
        public abstract bool isWinner(char symbol);
        public abstract bool isDraw();

        public void displayBoard() 
        {
            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j < n; j++) 
                {
                    Console.Write(grid[i, j] + " ");
                }
            }
        }
    }

    class Player
    {
        private string name;
        private char symbol;
        public Player(string NAME, char SYMBOL)
        {
            name = NAME;
            symbol = SYMBOL;
        }
        public void getMove(ref int x, ref int y)
        {
            // Code Goes Here
        }
        public char Symbol {get;}
        public string Name {get;}
    }

    class Game
    {
        private int turn;
        public Game(Board board, Player[] p)
        {
            // Code Goes Here
        }
        public void playGame()
        {
            // Code Goes Here
        }
    }
}