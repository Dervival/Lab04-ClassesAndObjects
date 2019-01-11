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
		/// <returns>Winner</returns>
		public Player Play()
		{
            Console.WriteLine("\nWelcome to Tic-Tac-Toe, " + PlayerOne.Name + " and " + PlayerTwo.Name+ ". Now, let's play!");
            Player tie = new Player();
            tie.Name = "Nobody won";
            Player activePlayer = PlayerOne;
            Game TestGame = new Game(PlayerOne, PlayerTwo);
            //PlayerOne gets the first move
            //Only 9 locations - end in a tie if neither win after 9 moves
            int positionsLeft = 9;
            //Console.WriteLine("In Play() - PlayerOne is " + PlayerOne.Name + " and PlayerTwo is " + PlayerTwo.Name);
            bool gameRunning = true;
            while (gameRunning)
            {
                if(positionsLeft == 0)
                {
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
                
                //TODO: Complete this method and utilize the rest of the class structure to play the game.

                /*
                 * Complete this method by constructing the logic for the actual playing of Tic Tac Toe. 
                 * 
                 * A few things to get you started:
                1. A turn consists of a player picking a position on the board with their designated marker. 
                2. Display the board after every turn to show the most up to date state of the game
                3. Once a Winner is determined, display the board one final time and return a winner

                Few additional hints:
                    Be sure to keep track of the number of turns that have been taken to determine if a draw is required
                    and make sure that the game continues while there are unmarked spots on the board. 

                Use any and all pre-existing methods in this program to help construct the method logic. 
                 */

                
            }
            return tie;			
		}


		/// <summary>
		/// Check if winner exists
		/// </summary>
		/// <param name="board">current state of the board</param>
		/// <returns>if winner exists</returns>
		public bool CheckForWinner(Board board)
		{
            //Console.WriteLine("In CheckForWinner");
			int[][] winners = new int[][]
			{
                //Win by filling a row
				new[] {1,2,3},
				new[] {4,5,6},
				new[] {7,8,9},

                //Win by filling a column
				new[] {1,4,7},
				new[] {2,5,8},
				new[] {3,6,9},

                //Win by filling a diagonal
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

                // TODO:  Determine a winner has been reached. Done
                // return true if a winner has been reached. 

                // TODO: Convert a, b, and c into what's currently at that position rather than just the number? Done
                //Console.WriteLine("Do " + a + ", " + b + ", and " + c + " match?");
                string aMark = board.GameBoard[(Convert.ToInt32(a) - 1) / 3, (Convert.ToInt32(a) - 1) % 3];
                string bMark = board.GameBoard[(Convert.ToInt32(b) - 1) / 3, (Convert.ToInt32(b) - 1) % 3];
                string cMark = board.GameBoard[(Convert.ToInt32(c) - 1) / 3, (Convert.ToInt32(c) - 1) % 3];
                //Console.WriteLine("Do " + aMark + ", " + bMark + ", and " + cMark + " match?");
                if (aMark == bMark && bMark == cMark)
                {
                    return true;
                }

                //Console.WriteLine("a is " + a);
                //Console.WriteLine("b is " + b);
                //Console.WriteLine("c is " + c);
            }

			return false;
		}


		/// <summary>
		/// Determine next player
		/// </summary>
		/// <returns>next player</returns>
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
