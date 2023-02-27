# All comments and code were written by ChatGPT

# Define a function to print the Tic Tac Toe board
def print_board(board):
    print("-------------")
    for i in range(3):
        print("|", end = " ")
        for j in range(3):
            print(board[i][j], "|", end = " ")
        print()
        print("-------------")

# Define a function to handle a player's move
def player_move(board, player):
    # Ask the player to choose a row and column
    row = int(input("Player " + player + ", choose a row (1-3): "))
    col = int(input("Player " + player + ", choose a column (1-3): "))
    # If the chosen spot is empty, mark it with the player's symbol
    if board[row-1][col-1] == " ":
        board[row-1][col-1] = player
    # If the chosen spot is already taken, prompt the player to choose another spot
    else:
        print("That spot is already taken. Try again.")
        player_move(board, player)

# Define a function to check if a player has won
def is_winner(board, player):
    # Check if the player has filled any row with their symbol
    for i in range(3):
        if (board[i][0] == player and board[i][1] == player and board[i][2] == player):
            return True
        # Check if the player has filled any column with their symbol
        if (board[0][i] == player and board[1][i] == player and board[2][i] == player):
            return True
    # Check if the player has filled either diagonal with their symbol
    if (board[0][0] == player and board[1][1] == player and board[2][2] == player):
        return True
    if (board[0][2] == player and board[1][1] == player and board[2][0] == player):
        return True
    # If the player has not won, return False
    return False

# Define a function to check if the board is full
def is_board_full(board):
    # Check every spot on the board to see if it's empty
    for i in range(3):
        for j in range(3):
            if board[i][j] == " ":
                # If any spot is empty, return False
                return False
    # If all spots are filled, return True
    return True

# Define the main game function
def play_game():
    # Create an empty board
    board = [[" ", " ", " "], [" ", " ", " "], [" ", " ", " "]]
    # Start with player X
    player = "X"
    # Print the initial board
    print_board(board)
    # Keep playing until the board is full
    while not is_board_full(board):
        # Ask the current player to make a move
        player_move(board, player)
        # Print the updated board
        print_board(board)
        # Check if the player has won
        if is_winner(board, player):
            # If the player has won, print a message and return from the function
            print("Congratulations! Player " + player + " wins!")
            return
        # If the game is still going, switch to the other player
        if player == "X":
            player = "O"
        else:
            player = "X"
    # If the board is full and no one has won, print a tie message
    print("It's a tie!")

play_game()
