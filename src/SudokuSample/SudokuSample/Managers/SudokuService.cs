using SudokuSample.DataAccess;
using SudokuSample.Models.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuSample.Managers
{
    public class SudokuService : ISudokuService
    {
        ISudokuDataAccess dataAccess;

        public SudokuService(ISudokuDataAccess sudokuDataAccess)
        {
            dataAccess = sudokuDataAccess;
        }

        public Task<SudokuProblem> GenerateNewProblem()
        {
            throw new NotImplementedException();
        }
    }
}
