using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuSample.Models.Sudoku
{
    public class Row
    {
        /// <summary>
        /// Row value
        /// </summary>
        public int? Value { get; set; }

        /// <summary>
        /// List of column for this row
        /// </summary>
        public Column[] Columns { get; set; }
    }
}
