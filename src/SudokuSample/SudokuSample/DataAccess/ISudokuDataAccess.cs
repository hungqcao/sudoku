using SudokuSample.Models.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuSample.DataAccess
{
    public interface ISudokuDataAccess
    {
        Task<SudokuProblem> Get(int id);
        Task<bool> Save(SudokuProblem problem);
    }
}
