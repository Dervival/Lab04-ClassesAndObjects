using Lab04_TicTacToe.Classes;
using System;

namespace Lab04_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe.");
            Console.WriteLine("Player 1, please enter your name.");
            Player playerOne = new Player
            {
                Name = Console.ReadLine(),
                Marker = "X"
            };
            Console.WriteLine("Hello there, " + playerOne.Name + ".");
            Console.WriteLine("Player 2, please enter your name.");
            Player playerTwo = new Player
            {
                Name = Console.ReadLine(),
                Marker = "O"
            };
            Game testGame = new Game(playerOne, playerTwo);
            Player winner = testGame.Play();
            if(winner.Name == "Nobody won")
            {
                Console.WriteLine("It looks like it's a tie game! Better luck next time.");
                return;
            }
            Console.WriteLine("Congratulations, " + winner.Name + ", you won!\n");
        }
    }
}
