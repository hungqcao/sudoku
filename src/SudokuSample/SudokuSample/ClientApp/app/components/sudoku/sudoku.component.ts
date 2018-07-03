import { Component } from '@angular/core';
import { SudokuService } from '../services/sudoku.service';
import { Row, SudokuProblem } from '../models/sudoku.model';

@Component({
    selector: 'sudoku',
    templateUrl: './sudoku.component.html',
    styleUrls: ['./sudoku.component.css']
})
export class SudokuComponent {
    private problem: SudokuProblem | undefined;
    private isProblemValid: boolean = true;

    constructor(private sudokuService: SudokuService) {
        this.sudokuService.getCurrentSudokuProblem().subscribe(problem => {
            this.problem = problem;            
        });
    }

    private getRowClass(rowIndex: number): string {
        return rowIndex > 0 && rowIndex % 3 == 2 ? 'margin_bottom_60' : '';
    }

    private getColumnClass(colIndex: number): string {
        return colIndex > 0 && colIndex % 3 == 0 ? 'margin_left_60' : '';
    }

    /**
     * This function will validate current sudoku is valid or not
     * */
    private validateCurrentSudoku(): void {
        if (this.problem) {
            this.sudokuService.validateSudokuProblem(this.problem).subscribe(res => {
                this.isProblemValid = res;
            })
        }
    }
}
