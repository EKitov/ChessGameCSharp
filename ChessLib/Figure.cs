using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    enum Figure
    {
        none,

        whiteKing = 'K',
        whiteQueen = 'Q',
        whiteRook = 'R',
        whiteBishop = 'B',
        whiteKnight = 'N',
        whitePawn = 'P',

        blackKing = 'k',
        blackQueen = 'q',
        blackRook = 'r',
        blackBishop = 'b',
        blackKnight = 'n',
        blackPawn = 'p'
    }
    static class FigureMethods
    {
        public static Color getColor(this Figure figure)
        {
            if (figure == Figure.none)
                return Color.none;
            return (figure == Figure.whiteKnight || figure == Figure.whiteKing ||
                figure == Figure.whitePawn || figure == Figure.whiteBishop ||
                figure == Figure.whiteRook || figure == Figure.whiteQueen)
                ? Color.white : Color.black;
        }
    }
}
