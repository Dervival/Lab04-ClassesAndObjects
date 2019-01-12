using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
    public class Board
    {
		/// <summary>
		/// Tic Tac Toe Gameboard states
		/// </summary>
		public string[,] GameBoard = new string[,]
		{
			{"1", "2", "3"},
			{"4", "5", "6"},
			{"7", "8", "9"},
		};

        /// <summary>
        /// Displays the current board state of the game board.
        /// </summary>
		public void DisplayBoard()
		{
            //TODO: Output the board to the console
            //This might do it?
            Console.WriteLine();
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine("|" + GameBoard[i, 0] + "||" + GameBoard[i, 1] + "||" + GameBoard[i, 2] + "|");
            }
		
		}
	}
}
