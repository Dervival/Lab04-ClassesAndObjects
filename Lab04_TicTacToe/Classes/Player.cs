using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
    class Player
    {
        /// <summary>
        /// Name of the player. For this game, will use user input in main() to determine this.
        /// </summary>
		public string Name { get; set; }

		/// <summary>
		/// String representing the moves of the player. P1 is X and P2 will be O; assigned in main().
		/// </summary>
		public string Marker { get; set; }

		/// <summary>
		/// Flag to determine if it is the user's turn
		/// </summary>
		public bool IsTurn { get; set; }

        /// <summary>
        /// Polls the user for input for a board location, and returns it as a Position object.
        /// </summary>
        /// <param name="board">The game board being interacted with, in its current (not default) state.</param>
        /// <returns>Returns the position of the location selected by the player.</returns>
		public Position GetPosition(Board board)
		{
			Position desiredCoordinate = null;
			while (desiredCoordinate is null)
			{
				Console.WriteLine("Please select a location");
				Int32.TryParse(Console.ReadLine(), out int position);
				desiredCoordinate = PositionForNumber(position);
			}
			return desiredCoordinate;

		}

        /// <summary>
        /// Converts an int representing the position on the gameboard into a Position object to be manipulated later.
        /// </summary>
        /// <param name="position">An int representing the position on the board that was selected.</param>
        /// <returns>Returns the position of the location selected by the player.</returns>
		public static Position PositionForNumber(int position)
		{
			switch (position)
			{
				case 1: return new Position(0, 0); // Top Left
				case 2: return new Position(0, 1); // Top Middle
				case 3: return new Position(0, 2); // Top Right
				case 4: return new Position(1, 0); // Middle Left
				case 5: return new Position(1, 1); // Middle Middle
				case 6: return new Position(1, 2); // Middle Right
				case 7: return new Position(2, 0); // Bottom Left
				case 8: return new Position(2, 1); // Bottom Middle 
				case 9: return new Position(2, 2); // Bottom Right

				default: return null;
			}
		}

        /// <summary>
        /// Main method for having a user take their turn for tic-tac-toe. Polls the user for a position input, rejecting previously selected positions.
        /// </summary>
        /// <param name="board">The game board being interacted with. The values on the gameboard dictate if a selected position is valid to be selected or not.</param>
        public void TakeTurn(Board board)
		{
			IsTurn = true;

			Console.WriteLine($"{Name} it is your turn");

			Position position = GetPosition(board);

			if (Int32.TryParse(board.GameBoard[position.Row, position.Column], out int _))
			{
				board.GameBoard[position.Row, position.Column] = Marker;
			}
			else
			{
				Console.WriteLine("This space is already occupied");
			}
		}
	}
}
