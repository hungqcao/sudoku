using SudokuSample.Models.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuSample.Managers
{
    public interface ISudokuService
    {
        Task<SudokuProblem> GenerateNewProblem();
        bool ValidateProblem(SudokuProblem problem);
    }
}
