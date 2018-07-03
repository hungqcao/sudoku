using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SudokuSample.Managers;
using SudokuSample.Models.Sudoku;

namespace SudokuSample.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SudokuController : Controller
    {
        private ISudokuService sudokuService;
        public SudokuController(ISudokuService service)
        {
            this.sudokuService = service;
        }

        [HttpGet]
        public async Task<SudokuProblem> GetCurrentProblem()
        {
            return await this.sudokuService.GenerateNewProblem();
        }

        [HttpPut("status")]
        public bool ValidateProblem([FromBody]SudokuProblem sudokuProblem)
        {
            return this.sudokuService.ValidateProblem(sudokuProblem);
        }
    }
}