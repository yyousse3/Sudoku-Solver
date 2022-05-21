using System;
namespace practice.cs
{
    public class SudokuSolver
    {
        private int[][] board =  {
            new int[]{ 7, 8, 0, 4, 0, 0, 1, 2, 0 },
            new int[]{ 6, 0, 0, 0, 7, 5, 0, 0, 9 },
            new int[]{ 0, 0, 0, 6, 0, 1, 0, 7, 8 },
            new int[]{ 0, 0, 7, 0, 4, 0, 2, 6, 0 },
            new int[]{ 0, 0, 1, 0, 5, 0, 9, 3, 0 },
            new int[]{ 9, 0, 4, 0, 0, 0, 0, 0, 5 },
            new int[]{ 0, 7, 0, 3, 0, 0, 0, 1, 2 },
            new int[]{ 1, 2, 0, 0, 0, 7, 4, 0, 0},
            new int[]{ 0, 4, 9, 2, 0, 6, 0, 0, 7 }
                                };

        public SudokuSolver()
        {

        }

        public Boolean solve()
        {
            int[] find = findEmpty();
            if (find == null) return true;
            int row = find[0];
            int col = find[1];

            for (int i = 1; i < board.Length + 1; i++)
            {
                int[] pos = {row, col};
                if (valid(i, pos))
                {
                    board[row][col] = i;
                    if (solve()) return true;

                    
                }
                board[row][col] = 0;
            }
            return false;


        }

        private Boolean valid(int num, int[] pos)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[pos[0]][i] == num && pos[1] != i)
                {
                    return false;
                }
                if (board[i][pos[1]] == num && pos[0]!= i)
                {
                    return false;
                }
                        
            }
            int boxX = pos[1] / 3;
            int boxY = pos[0] / 3;

            for (int i = boxY*3; i <  boxY*3 + 3; i++)
            {
                for (int y = boxX * 3; y < boxX * 3 + 3; y++)
                {
                    if (board[i][y] == num && i != pos[0] && y != pos[1]) return false;
                }
            }
            return true;
        }

        private int[] findEmpty()
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int y = 0; y < board[0].Length; y++)
                {
                    if (board[i][y] == 0) return new int[]{i,y} ;
                }
            }
            return null;
        }

        public void printBoard() {
            for (int i = 0; i < board.Length+1; i++)
            {
                string row = "";
                if (i % 3 == 0)
                {
                    Console.WriteLine("- - - - - - - - - - -");
                }
                if (i == 9) break;
            
                for (int y = 0; y < board[0].Length+1; y++) {
                    if (y % 3 == 0)
                    {
                        row += "|";
                        if (y == 9) break;
                    }

                    row += board[i][y].ToString() + " ";
                    


                }
                Console.WriteLine(row);

            }

        }


    }
}
