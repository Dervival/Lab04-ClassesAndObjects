using System;
using Lab04_TicTacToe.Classes;

namespace Lab04_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Player a = new Player();
            a.Name = "a";
            a.Marker = "X";
            Player b = new Player();
            b.Name = "b";
            b.Marker = "O";
            Game testGame = new Game(a,b);
            Player winner = testGame.Play();
            Console.WriteLine("Player 1, " + winner.Name + " was the winner");
        }
    }
}
