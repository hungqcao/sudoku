using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuSample.Models.Sudoku
{
    public class Column
    {
        /// <summary>
        /// Column value
        /// </summary>
        public int? Value { get; set; }

        public Column(int? valId)
        {
            Value = valId;
        }
    }
}
