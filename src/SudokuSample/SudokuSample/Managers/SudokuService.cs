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
        private readonly int SudokuSize = 9;

        public SudokuService(ISudokuDataAccess sudokuDataAccess)
        {
            dataAccess = sudokuDataAccess;
        }

        public Task<SudokuProblem> GenerateNewProblem()
        {
            SudokuProblem problem = null;
            // Poor man version of implementation
            do
            {
                problem = new SudokuProblem(this.GenerateRowsRandomly());
            }
            while (!this.ValidateProblem(problem));

            return Task.FromResult(problem);
        }

        private IList<Row> GenerateRowsRandomly()
        {
            var random = new Random();
            var rows = Enumerable.Range(1, this.SudokuSize).Select(index => new Row
            {
                Value = index,
                Columns = new Column[]
                {
                    new Column(null),
                    new Column(null),
                    new Column(null),
                    new Column(null),
                    new Column(null),
                    new Column(null),
                    new Column(null),
                    new Column(null),
                    new Column(null),
                }
            }).ToList();

            int numOfNumber = 6;
            while(numOfNumber > 0)
            {
                var rowIdx = random.Next(0, this.SudokuSize);
                var colIdx = random.Next(0, this.SudokuSize);
                rows[rowIdx].Columns[colIdx].Value = random.Next(1, this.SudokuSize);
                numOfNumber--;
            }

            return rows;
        }

        public bool ValidateProblem(SudokuProblem problem)
        {
            if (problem == null) throw new ArgumentNullException(nameof(problem));

            var set = new HashSet<string>();
            for (var i = 0; i < this.SudokuSize - 1; i++)
            {
                for (var j = 0; j < this.SudokuSize - 1; j++)
                {
                    if (problem.Rows[i] != null && problem.Rows[i].Columns != null && problem.Rows[i].Columns[j] != null && problem.Rows[i].Columns[j].Value != null)
                    {
                        if (!this.isValidNumber(problem.Rows[i].Columns[j].Value))
                        {
                            // Out of range
                            return false;
                        }
                        else
                        {
                            // We use a hashmap to check if the value is already existed in the current row/column/square
                            var rowStr = $"R{i}{problem.Rows[i].Columns[j].Value}";
                            var colStr = $"C{j}{problem.Rows[i].Columns[j].Value}";
                            var squareStr = $"S{i / Math.Sqrt(this.SudokuSize) * Math.Sqrt(this.SudokuSize) + j / Math.Sqrt(this.SudokuSize)}{ problem.Rows[i].Columns[j].Value}";
                            if (set.Contains(rowStr) || set.Contains(colStr) || set.Contains(squareStr)) return false;
                            set.Add(rowStr);
                            set.Add(colStr);
                            set.Add(squareStr);
                        }
                    }
                }
            }

            return true;
        }

        private bool isValidNumber(int? num)
        {
            if (num != null)
            {
                // only allow value from 1 -> problem's size
                return num > 0 && num <= this.SudokuSize;
            }
            else
            {
                // empty cell
                return true;
            }
        }
    }
}
