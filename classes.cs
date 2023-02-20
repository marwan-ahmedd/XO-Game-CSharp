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
                    Console.Write("| " + grid[i, j] + " |");
                }
                Console.WriteLine();
            }
        }
    }

    class XO : Board
    {
        public XO() : base(3) {}
        public override bool updateBoard(int x, int y, char symbol)
        {
            if (x - 1 < 3 && y - 1 < 3 && this.grid[x,y] != 'X' && this.grid[x,y] != 'O')
            {
                this.grid[x,y] = symbol;
                return true;
            }
            else {return false;}
        }
        public override bool isWinner(char symbol)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if((this.grid[i,0] == symbol && this.grid[i,1] == symbol && this.grid[i,2] == symbol) ||
                    (this.grid[0,j] == symbol && this.grid[1,j] == symbol && this.grid[2,j] == symbol) ||
                    (this.grid[0,0] == symbol && this.grid[1,1] == symbol && this.grid[2,2] == symbol) ||
                    (this.grid[0,2] == symbol && this.grid[1,1] == symbol && this.grid[2,0] == symbol))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override bool isDraw()
        {
            if(this.isWinner('X') == false && this.isWinner('O') == false){
                
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (this.grid[i,j] != 'X' && this.grid[i,j] != 'O')
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else {return false;}
        }
    }

    class Player
    {
        private string name;
        public string getName {get {return name;}}
        private char symbol;
        public char getSymbol {get {return symbol;}}
        public Player(string NAME, char SYMBOL)
        {
            name = NAME;
            symbol = SYMBOL;
        }
    }

    class Game
    {
        private int turn;
        private XO board;
        private Player[] players;
        public Game(XO BOARD, Player[] P)
        {
            board = BOARD;
            players = P;
        }
        public void playGame()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Player 1: " + players[0].getSymbol);
                Console.WriteLine("Player 2: " + players[1].getSymbol);
                board.displayBoard();
                
                int x, y;

                Console.WriteLine("Player "+ (turn + 1) +", please choose where you want to play:");

                string input = Console.ReadLine();
                var data = input.Split(' ');
                x = Convert.ToInt32(data[0]);
                y = Convert.ToInt32(data[1]);

                if(board.updateBoard(x, y, players[turn].getSymbol) == true)
                {
                    if(board.isWinner(players[turn].getSymbol) == false)
                    {
                        if(board.isDraw() == false)
                        {
                            switch(turn)
                            {
                                case 0:
                                    turn = 1;
                                    break;
                                case 1:
                                    turn = 0;
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("The game ends with a tie");
                            board.displayBoard();
                            break;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Congrats, Player " + (turn + 1) + " won");
                        board.displayBoard();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry the index you choose is invalid, please try again");
                }
            }
        }
    }
}