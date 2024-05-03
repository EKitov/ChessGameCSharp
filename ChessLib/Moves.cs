using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    internal class Moves
    {
        FigureMoving fm;
        Board board;
        public Moves(Board board)
        {
            this.board = board;
        }
        public bool CanMove(FigureMoving fm)
        {
            this.fm = fm;
            return CanMoveFrom() && CanMoveTo() && CanFigureMove();
        }
        bool CanMoveFrom()
        {
            return fm.from.OnBoard() && fm.figure.getColor() == board.moveColor;
        }
        bool CanMoveTo()
        {
            return fm.to.OnBoard() && fm.from.Name != fm.to.Name && board.GetFigureAt(fm.to).getColor() != board.moveColor;
        }
        bool CanFigureMove()
        {
            switch(fm.figure)
            {
                case Figure.whiteKing:
                case Figure.blackKing:
                    return CanKingMove();

                case Figure.whiteQueen:
                case Figure.blackQueen:
                    return CanStraightMove();

                case Figure.whiteKnight:
                case Figure.blackKnight:
                    return CanKnightMove();

                case Figure.whiteBishop:
                case Figure.blackBishop:
                    return (fm.SignDeltaX != 0 && fm.SignDeltaY != 0) && CanStraightMove();

                case Figure.whiteRook:
                case Figure.blackRook:
                    return (fm.SignDeltaX == 0 || fm.SignDeltaY == 0)&& CanStraightMove();

                case Figure.whitePawn:
                case Figure.blackPawn:
                    return CanPawnMove();

                default: return false;
            }
        }

        private bool CanStraightMove()
        {
            Square at = fm.from;
            do
            {
                at = new Square(at.x + fm.SignDeltaX, at.y + fm.SignDeltaY);
                if (at == fm.to)
                    return true;
            } while (at.OnBoard() && board.GetFigureAt(at) == Figure.none);
            return false;
        }

        private bool CanKnightMove()
        {
            if (fm.AbsDeltaX == 1 && fm.AbsDeltaY == 2)
                return true;
            if (fm.AbsDeltaX == 2 && fm.AbsDeltaY == 1)
                return true;
            return false;
        }
        private bool CanKingMove()
        {
            if (fm.AbsDeltaX <= 1 && fm.AbsDeltaY <= 1)
                return true;
            return false;
        }
        private bool CanPawnMove()
        {
            if (fm.from.y < 1 || fm.from.y > 6)
                return false;
            int stepY = fm.figure.getColor() == Color.white ? 1 : -1;
            if(fm.to.y == 7)
            {
                fm.promotion = Figure.whiteQueen;
            }
            if(fm.to.y == 0)
            {
                fm.promotion = Figure.blackQueen;
            }
            return CanPawnGo(stepY) || CanPawnJump(stepY) || CanPawnEat(stepY);
        }

        private bool CanPawnEat(int stepY)
        {
            if (board.GetFigureAt(fm.to) != Figure.none)
                if (fm.AbsDeltaX == 1)
                    if (fm.DeltaY == stepY)
                        return true;
            return false;
        }

        private bool CanPawnJump(int stepY)
        {
            if (board.GetFigureAt(fm.to) == Figure.none)
                if (fm.DeltaX == 0)
                    if (fm.DeltaY == 2 * stepY)
                        if (fm.from.y == 1 || fm.from.y == 6)
                            if (board.GetFigureAt(new Square(fm.from.x, fm.from.y + stepY)) == Figure.none)
                                    return true;
            return false;
        }

        private bool CanPawnGo(int stepY)
        {
            if (board.GetFigureAt(fm.to) == Figure.none)
                if (fm.DeltaX == 0)
                    if (fm.DeltaY == stepY)
                        return true;
            return false;
        }
    }
}
