# ChessLibraryCSharp
Использование библиотеки на примере одиночной шахматной игры:

```
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
```
