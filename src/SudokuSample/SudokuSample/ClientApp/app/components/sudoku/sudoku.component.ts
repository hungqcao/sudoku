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

    private isValidNumber(num: number | null): boolean {
        if (this.problem && num) {
            // only allow value from 1 -> problem's size
            return num > 0 && num <= this.problem.size;
        }
        else if (num == null) {
            // empty cell
            return true;
        } {
            return false;
        }
    }

    /**
     * This function will validate current sudoku is valid or not
     * */
    private validateCurrentSudoku(): boolean {
        let set: any = {};
        if (this.problem) {
            let sqrt = Math.sqrt(this.problem.size);
            for (let i = 0; i < this.problem.size - 1; i++) {
                for (let j = 0; j < this.problem.size - 1; j++) {
                    if (this.problem.rows[i] && this.problem.rows[i].columns[j] != null && this.problem.rows[i].columns[j].value != null) {
                        if (!this.isValidNumber(this.problem.rows[i].columns[j].value)) {
                            // Out of range
                            return false;
                        } else {
                            // We use a hashmap to check if the value is already existed in the current row/column/square
                            let rowStr = `R${i}${this.problem.rows[i].columns[j].value}`;
                            let colStr = `C${j}${this.problem.rows[i].columns[j].value}`;
                            let squareStr = `S${i / sqrt * sqrt + j / sqrt}${this.problem.rows[i].columns[j].value}`;
                            if (set[rowStr] || set[colStr] || set[squareStr]) return false;
                            set[rowStr] = true;
                            set[colStr] = true;
                            set[squareStr] = true;
                        }
                    }
                }
            }
        }

        return true;
    }
}
