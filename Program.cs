using System;

namespace practice.cs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SudokuSolver sudoku = new SudokuSolver();
            sudoku.printBoard();
            sudoku.solve();
            sudoku.printBoard();



        }
    }
}
