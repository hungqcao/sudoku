import { Injectable, Inject } from "@angular/core";
import 'rxjs/add/operator/map';
import { Http } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Row, SudokuProblem } from "../models/sudoku.model";
import { forEach } from "@angular/router/src/utils/collection";

@Injectable()
export class SudokuService {
    private endpoint: string;
    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.endpoint = baseUrl;
    }

    public getCurrentSudokuProblem(): Observable<SudokuProblem> {
        return this.http.get(this.endpoint + 'api/v1/sudoku').map(result => {
            let obj = result.json() as SudokuProblem;
            obj.rows.forEach(row => {
                row.columns.forEach(column => {
                    if (column.value) column.isReadonly = true;
                })
            })
            return obj;
        });
    }

    public validateSudokuProblem(problem: SudokuProblem): Observable<boolean> {
        return this.http.put(this.endpoint + 'api/v1/sudoku/status', problem).map(result => result.json());
    }
}