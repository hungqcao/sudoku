using SudokuSample.Models.Sudoku;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuSample.DataAccess
{
    public class SudokuDataAccess : ISudokuDataAccess
    {
        private ConcurrentDictionary<int, SudokuProblem> storage;

        public SudokuDataAccess()
        {
            storage = new ConcurrentDictionary<int, SudokuProblem>();
        }

        public Task<SudokuProblem> Get(int id)
        {
            return Task.FromResult(storage[id]);
        }

        public Task<bool> Save(SudokuProblem problem)
        {
            return Task.FromResult(storage.TryAdd(storage.Count, problem));
        }
    }
}
