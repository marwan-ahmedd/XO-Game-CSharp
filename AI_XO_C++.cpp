// All comments and code were written by ChatGPT

#include <iostream>
using namespace std;

// Constants for game board size
const int ROWS = 3;
const int COLS = 3;

// Enum to represent game state
enum class GameState { InProgress, Draw, Player1Wins, Player2Wins };

// Class to represent game board
class GameBoard {
public:
    GameBoard() {
        for (int i = 0; i < ROWS; i++) {
            for (int j = 0; j < COLS; j++) {
                board[i][j] = '-';
            }
        }
    }

    void PrintBoard() {
        for (int i = 0; i < ROWS; i++) {
            for (int j = 0; j < COLS; j++) {
                cout << board[i][j] << " ";
            }
            cout << endl;
        }
    }

    bool PlacePiece(int row, int col, char piece) {
        if (board[row][col] != '-') {
            return false;
        }
        board[row][col] = piece;
        return true;
    }

    GameState GetGameState() {
        // Check rows for a win
        for (int i = 0; i < ROWS; i++) {
            if (board[i][0] != '-' && board[i][0] == board[i][1] && board[i][1] == board[i][2]) {
                return board[i][0] == 'X' ? GameState::Player1Wins : GameState::Player2Wins;
            }
        }

        // Check columns for a win
        for (int j = 0; j < COLS; j++) {
            if (board[0][j] != '-' && board[0][j] == board[1][j] && board[1][j] == board[2][j]) {
                return board[0][j] == 'X' ? GameState::Player1Wins : GameState::Player2Wins;
            }
        }

        // Check diagonals for a win
        if (board[0][0] != '-' && board[0][0] == board[1][1] && board[1][1] == board[2][2]) {
            return board[0][0] == 'X' ? GameState::Player1Wins : GameState::Player2Wins;
        }
        if (board[0][2] != '-' && board[0][2] == board[1][1] && board[1][1] == board[2][0]) {
            return board[0][2] == 'X' ? GameState::Player1Wins : GameState::Player2Wins;
        }

        // Check for a draw
        for (int i = 0; i < ROWS; i++) {
            for (int j = 0; j < COLS; j++) {
                if (board[i][j] == '-') {
                    return GameState::InProgress;
                }
            }
        }

        return GameState::Draw;
    }

private:
    char board[ROWS][COLS];
};

int main() {
    GameBoard board;
    bool player1Turn = true;

    while (board.GetGameState() == GameState::InProgress) {
        // Print board
        board.PrintBoard();

        // Get player input
        int row, col;
        char piece = player1Turn ? 'X' : 'O';
        cout << "Player " << (player1Turn ? "1" : "2") << ", enter row and column (0-2): ";
        cin >> row;
        cin >> col;

        // Place player piece on board
        if (board.PlacePiece(row, col, piece)) {
            player1Turn = !player1Turn;
        }
        else {
            cout << "That spot is already taken. Try again." << endl;
        }
    }

    // Print final board and game result
    board.PrintBoard();
    switch (board.GetGameState()) {
    case GameState::Player1Wins:
        cout << "Player 1 wins!" << endl;
        break;
    case GameState::Player2Wins:
        cout << "Player 2 wins!" << endl;
        break;
    case GameState::Draw:
        cout << "Draw!" << endl;
        break;
    }

    return 0;
}