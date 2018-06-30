export class SudokuProblem {
    rows: Row[] = [];
    size: number = 0;
}

export class Row {
    value: number | null = null;
    columns: Column[] = [];
}

export class Column {
    value: number | null = null;
}