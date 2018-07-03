using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuSample.Models.Sudoku
{
    public class SudokuProblem
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// List of row
        /// </summary>
        public IList<Row> Rows { get; }

        public SudokuProblem(IList<Row> rows)
        {
            this.Rows = rows;
        }
    }
}
