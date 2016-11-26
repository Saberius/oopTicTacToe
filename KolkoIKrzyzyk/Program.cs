using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolkoIKrzyzyk
{
    class Program
    {
        public enum TicOrTac
        {
            Kolko = '0',
            Krzyzyk = '1',
            Empty = '2',
        }

        static void Main(string[] args)
        {
            TicTacBoard board = new TicTacBoard();

            board.GetBoard();

            TicTacPlayer player1 = new TicTacPlayer(TicOrTac.Kolko);
            TicTacPlayer player2 = new TicTacPlayer(TicOrTac.Krzyzyk);

            player1.GetPosForBoard(board);
            board.GetBoard();
            player2.GetPosForBoard(board);
            board.GetBoard();

            Console.ReadLine();

        }

        public class TicTacPlayer
        {
            public TicOrTac PlayerType { get; set; }

            public TicTacPlayer(TicOrTac player)
            {
                PlayerType = player;
            }

            public void GetPosForBoard(TicTacBoard board)
            {
                string plr = "";
                int[] xPosyPos = new int[2];
                switch (PlayerType)
                {
                    case TicOrTac.Kolko:
                        plr = "kolka";
                        break;
                    case TicOrTac.Krzyzyk:
                        plr = "krzyzyka";
                        break;
                    default:
                        Console.WriteLine("Błąd gracza.");
                        break;
                }
                Console.WriteLine("Podaj pozycje X dla {0} (1-3):", plr);
                xPosyPos[0] = GetPos();
                Console.WriteLine("Podaj pozycje Y dla {0} (1-3):", plr);
                xPosyPos[1] = GetPos();
                SetBoardMark(xPosyPos, board);
            }

            private int GetPos()
            {
                int pos;
                do
                {
                    Console.WriteLine("(1-3):");
                    pos = int.Parse(Console.ReadLine()) - 1;
                } while (pos > 2 || pos < 0);

                return pos;
            }

            private void SetBoardMark(int[] mark, TicTacBoard board)
            {
                if (board.GetBoardMarkState(mark[0], mark[1]) == TicOrTac.Empty)
                {
                    board.SetBoardMarkState(mark[0], mark[1], PlayerType);
                }
            }
        }

        public class TicTacBoard
        {
            public TicOrTac[,] board = new TicOrTac[3, 3];

            public TicTacBoard()
            {
                InitiateBoard();
            }

            private void InitiateBoard()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        board[j, i] = TicOrTac.Empty;
                    }
                }
            }

            public void GetBoard()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(board[j, i]);
                    }
                    Console.WriteLine();
                }
            }

            public TicOrTac GetBoardMarkState(int x, int y)
            {
                return board[x, y];
            }

            public void SetBoardMarkState(int x, int y, TicOrTac state)
            {
                board[x, y] = state;
            }
        }

    }
}
