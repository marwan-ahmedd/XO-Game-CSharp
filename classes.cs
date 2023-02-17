using System;

namespace TicTacToe 
{
    class Board {
        protected int n;
        protected char[,] grid;

        public Board(int n) {
            this.n = n;
            grid = new char[n, n];
        }

        public abstract bool updateBoard(int x, int y, char symbol);
        public abstract bool isWinner(char symbol);
        public abstract bool isDraw();

        public void displayBoard() {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    Console.Write(grid[i, j] + " ");
                }
            }
        }
    }
}