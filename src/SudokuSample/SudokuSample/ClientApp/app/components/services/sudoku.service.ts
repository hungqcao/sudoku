import { Injectable, Inject } from "@angular/core";
import 'rxjs/add/operator/map';
import { Http } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Row, SudokuProblem } from "../models/sudoku.model";

@Injectable()
export class SudokuService {
    private endpoint: string;
    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.endpoint = baseUrl;
    }

    public getCurrentSudokuProblem(): Observable<SudokuProblem> {
        return this.http.get(this.endpoint + 'api/v1/sudoku').map(result => result.json());
    }
}