# ChessLibraryCSharp
Использование библиотеки на примере одиночной шахматной игры:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ChessLib;
namespace ChessDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chess chess = new Chess();
            List<string> list;
            while (true)
            {
                Random random = new Random();
                list = chess.GetAllMoves();
                Console.WriteLine(chess.fen);
                Print(ChessToAscii(chess));
                if (chess.isCheck())
                {
                    if (chess.GetAllMoves().Count != 0)
                    {
                        Console.WriteLine("CHECK");
                    }
                    else
                    {
                        Console.WriteLine("MATE");
                    }
                }
                else
                {
                    if (chess.GetAllMoves().Count == 0)
                    {
                        Console.WriteLine("DRAW");
                    }
                    else
                    {
                        Console.WriteLine("-");
                    }
                }
                foreach (string moves in chess.GetAllMoves())
                    Console.Write(moves + "\t");
                Console.WriteLine();
                Console.Write("> ");
                string move = Console.ReadLine();
                if (move == "q") break;
                if (move == "") move = list[random.Next(list.Count)];
                chess = chess.Move(move);
            }
        }

        static string ChessToAscii(Chess chess)
        {
            string text = " +-----------------+\n";
            for (int y = 7; y >= 0; y--)
            {
                text += y + 1;
                text += " | ";
                for (int x = 0; x < 8; x++)
                    text += chess.GetFigureAt(x, y) + " ";
                text += "|\n";
            }
            text += " +-----------------+\n";
            text += "    a b c d e f g h\n";
            return text;
        }
        static void Print(string text)
        {
            ConsoleColor oldForeColor = Console.ForegroundColor;
            foreach (char x in text)
            {
                if (x >= 'a' && x <= 'z')
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (x >= 'A' && x <= 'Z')
                    Console.ForegroundColor = ConsoleColor.White;
                else Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(x);
            }
        }
    }
}
