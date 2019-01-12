using System;
using Xunit;
using Lab04_TicTacToe;
using Lab04_TicTacToe.Classes;

namespace TicTacToeUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void DetectIfAHorizontallyWinningGameBoardIsCaught()
        {
            Player playerStub = new Player();
            Game gameStub = new Game(playerStub, playerStub);
            Position positionStub = new Position(0,0);
            //act
            playerStub.Marker = "X";
            gameStub.Board.GameBoard[positionStub.Row, positionStub.Column] = playerStub.Marker;
            positionStub.Column = 1;
            gameStub.Board.GameBoard[positionStub.Row, positionStub.Column] = playerStub.Marker;
            positionStub.Column = 2;
            gameStub.Board.GameBoard[positionStub.Row, positionStub.Column] = playerStub.Marker;
            //assert
            Assert.True(gameStub.CheckForWinner(gameStub.Board));
        }
        [Fact]
        public void DetectIfAVerticallyWinningGameBoardIsCaught()
        {
            Player playerStub = new Player();
            Game gameStub = new Game(playerStub, playerStub);
            Position positionStub = new Position(0, 0);
            //act
            playerStub.Marker = "X";
            gameStub.Board.GameBoard[positionStub.Row, positionStub.Column] = playerStub.Marker;
            positionStub.Row = 1;
            gameStub.Board.GameBoard[positionStub.Row, positionStub.Column] = playerStub.Marker;
            positionStub.Row = 2;
            gameStub.Board.GameBoard[positionStub.Row, positionStub.Column] = playerStub.Marker;
            //assert
            Assert.True(gameStub.CheckForWinner(gameStub.Board));
        }
        [Fact]
        public void DetectIfADiagonallyWinningGameBoardIsCaught()
        {
            Player playerStub = new Player();
            Game gameStub = new Game(playerStub, playerStub);
            Position positionStub = new Position(0, 0);
            //act
            playerStub.Marker = "X";
            gameStub.Board.GameBoard[positionStub.Row, positionStub.Column] = playerStub.Marker;
            positionStub.Row = 1;
            positionStub.Column = 1;
            gameStub.Board.GameBoard[positionStub.Row, positionStub.Column] = playerStub.Marker;
            positionStub.Column = 2;
            positionStub.Row = 2;
            gameStub.Board.GameBoard[positionStub.Row, positionStub.Column] = playerStub.Marker;
            //assert
            Assert.True(gameStub.CheckForWinner(gameStub.Board));
        }
        [Fact]
        public void DetectIfANonWinningGameBoardIsCaught()
        {
            Player playerStub = new Player();
            Game gameStub = new Game(playerStub, playerStub);
            Position positionStub = new Position(0, 0);
            //act
            playerStub.Marker = "X";
            gameStub.Board.GameBoard[positionStub.Row, positionStub.Column] = playerStub.Marker;
            positionStub.Row = 1;
            positionStub.Column = 2;
            gameStub.Board.GameBoard[positionStub.Row, positionStub.Column] = playerStub.Marker;
            positionStub.Column = 2;
            positionStub.Row = 1;
            gameStub.Board.GameBoard[positionStub.Row, positionStub.Column] = playerStub.Marker;
            //assert
            Assert.False(gameStub.CheckForWinner(gameStub.Board));
        }

        [Fact]
        public void EnsureSwitchPlayerSwitchesPlayers()
        {
            Player playerOneStub = new Player();
            playerOneStub.IsTurn = true;
            Player playerTwoStub = new Player();
            Game gameStub = new Game(playerOneStub, playerTwoStub);
            gameStub.SwitchPlayer();
            Assert.True(playerTwoStub.IsTurn);
        }

        [Fact]
        public void EnsureNextPlayerReturnsNextPlayer()
        {
            Player playerOneStub = new Player();
            playerOneStub.IsTurn = true;
            Player playerTwoStub = new Player();
            Game gameStub = new Game(playerOneStub, playerTwoStub);
            Player actualPlayer = gameStub.NextPlayer();
            Player.Equals(playerTwoStub, actualPlayer);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        public void EnsureCorrectTileIsSelectedByIndex(int index)
        {
            //assign
            int zeroIndex = index-1;
            //act
            Position selectedPosition = Player.PositionForNumber(index);
            //assert
            Assert.Equal(zeroIndex%3, selectedPosition.Column);
            Assert.Equal(zeroIndex/3, selectedPosition.Row);
        }
    }
}
