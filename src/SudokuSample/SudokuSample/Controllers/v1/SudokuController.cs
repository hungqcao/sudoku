using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SudokuSample.Models.Sudoku;

namespace SudokuSample.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SudokuController : Controller
    {
        [HttpGet]
        public SudokuProblem GetCurrentProblem()
        {
            var rows = Enumerable.Range(1, 9).Select(index => new Row
            {
                Value = index,
                Columns = new Column[9]
                {
                    new Column(1),
                    new Column(4),
                    new Column(7),
                    new Column(null),
                    new Column(null),
                    new Column(null),
                    new Column(null),
                    new Column(null),
                    new Column(null),
                }
            }).ToList();

            return new SudokuProblem(rows, 9);
        }
    }
}