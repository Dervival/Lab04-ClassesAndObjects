using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
	class Game
	{
		public Player PlayerOne { get; set; }
		public Player PlayerTwo { get; set; }
		public Player Winner { get; set; }
		public Board Board { get; set; }


		/// <summary>
		/// Require 2 players and a board to start a game. 
		/// </summary>
		/// <param name="p1">Player 1</param>
		/// <param name="p2">Player 2</param>
		public Game(Player p1, Player p2)
		{
			PlayerOne = p1;
			PlayerTwo = p2;
			Board = new Board();
		}

		/// <summary>
		/// Activate the Play of the game
		/// </summary>
		/// <returns>Winner of the game</returns>
		public Player Play()
		{
            Console.WriteLine("\nWelcome to Tic-Tac-Toe, " + PlayerOne.Name + " and " + PlayerTwo.Name+ ". Now, let's play!");
            Player tie = new Player
            {
                Name = "Nobody won"
            };
            Player activePlayer = PlayerOne;
            Game TestGame = new Game(PlayerOne, PlayerTwo);
            //PlayerOne gets the first move
            //Only 9 locations - end in a tie if neither win after 9 moves
            int positionsLeft = 9;
            bool gameRunning = true;
            while (gameRunning)
            {
                if(positionsLeft == 0)
                {
                    TestGame.Board.DisplayBoard();
                    return tie;
                }
                TestGame.Board.DisplayBoard();
                activePlayer.TakeTurn(TestGame.Board);
                if (CheckForWinner(TestGame.Board))
                {
                    TestGame.Board.DisplayBoard();
                    return activePlayer;
                }
                positionsLeft--;
                SwitchPlayer();
                activePlayer = NextPlayer(); 
            }
            return tie;			
		}


		/// <summary>
		/// Check if winner exists on the current board state.
		/// </summary>
		/// <param name="board">Current state of the board</param>
		/// <returns>bool represneting if a winner exists</returns>
		public bool CheckForWinner(Board board)
		{
			int[][] winners = new int[][]
			{
                //Win by filling a row
				new[] {1,2,3},
				new[] {4,5,6},
				new[] {7,8,9},

                //Or by filling a column
				new[] {1,4,7},
				new[] {2,5,8},
				new[] {3,6,9},

                //Or by filling a diagonal
				new[] {1,5,9},
				new[] {3,5,7}
			};

			// Given all the winning conditions, Determine the winning logic. 
			for (int i = 0; i < winners.Length; i++)
			{
				Position p1 = Player.PositionForNumber(winners[i][0]);
				Position p2 = Player.PositionForNumber(winners[i][1]);
				Position p3 = Player.PositionForNumber(winners[i][2]);

				string a = Board.GameBoard[p1.Row, p1.Column];
				string b = Board.GameBoard[p2.Row, p2.Column];
				string c = Board.GameBoard[p3.Row, p3.Column];

                //This is really hardcoded - since we know that the board is a [3,3] array and values can only be between 1-9, we can use division to determine the row and modulo to determine the column of the position
                string aMark = board.GameBoard[(Convert.ToInt32(a) - 1) / 3, (Convert.ToInt32(a) - 1) % 3];
                string bMark = board.GameBoard[(Convert.ToInt32(b) - 1) / 3, (Convert.ToInt32(b) - 1) % 3];
                string cMark = board.GameBoard[(Convert.ToInt32(c) - 1) / 3, (Convert.ToInt32(c) - 1) % 3];
                if (aMark == bMark && bMark == cMark)
                {
                    return true;
                }
            }

			return false;
		}


		/// <summary>
		/// Determine next player based on current state of IsTurn
		/// </summary>
		/// <returns>Next player to move</returns>
		public Player NextPlayer()
		{
            //Console.WriteLine("Currently player one's turn? " + PlayerOne.IsTurn);
			return (PlayerOne.IsTurn) ? PlayerOne : PlayerTwo;
		}

		/// <summary>
		/// End one players turn and activate the other
		/// </summary>
		public void SwitchPlayer()
		{
			if (PlayerOne.IsTurn)
			{
              
				PlayerOne.IsTurn = false;

              
				PlayerTwo.IsTurn = true;
			}
			else
			{
				PlayerOne.IsTurn = true;
				PlayerTwo.IsTurn = false;
			}
		}


	}
}
